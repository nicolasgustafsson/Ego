using System.Collections.Concurrent;
using Rendering;

namespace Ego;

public sealed class EgoSynchronizationContext : SynchronizationContext
{
    private readonly BlockingCollection<(SendOrPostCallback Callback, object State)> MainThreadQueue = new();
    private readonly BlockingCollection<(RendererAwaitable.RendererSendOrPostCallback Callback, object State)> RendererQueue = new();
    private readonly BlockingCollection<(GpuTransferAwaitable.TransfererSendOrPostCallback Callback, object State)> TransferQueue = new();

    public override void Send(SendOrPostCallback d, object? state)
    {
        // Shortcut if we're already on this context
        // Also necessary to avoid a deadlock, since Send is blocking
        if (Current == this)
        {
            d(state);
            return;
        }

        var source = new TaskCompletionSource();

        MainThreadQueue.Add((st =>
        {
            try
            {
                d(st);
            }
            finally
            {
                source.SetResult();
            }
        }, state!));

        source.Task.Wait();
    }

    public override void Post(SendOrPostCallback d, object? state)
    {
        MainThreadQueue.Add((d, state!));
    }
    
    public void PostRenderer(RendererAwaitable.RendererSendOrPostCallback d, object? state)
    {
        RendererQueue.Add((d, state!));
    }
    
    public void PostTransferer(GpuTransferAwaitable.TransfererSendOrPostCallback d, object? state)
    {
        TransferQueue.Add((d, state!));
    }

    public void ExecuteMainThreadContinuations()
    {
        while (MainThreadQueue.TryTake(out var workItem))
        {
            workItem.Callback(workItem.State);
        }
    }

    public void ExecuteRendererContinuations(Renderer aRenderer)
    {
        while (RendererQueue.TryTake(out var workItem))
        {
            workItem.Callback(aRenderer, workItem.State);
        }
    }

    public void ExecuteGpuTransferContinuations(GpuDataTransferer aTransferer)
    {
        while (TransferQueue.TryTake(out var workItem))
        {
            workItem.Callback(aTransferer, workItem.State);
        }
    }
}