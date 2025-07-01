using System.Runtime.CompilerServices;
using Rendering;

namespace Ego;

public class EgoTask
{
    public static WorkerThreadAwaitable WorkerThread()
    {
        return new WorkerThreadAwaitable();
    }
    
    public static MainThreadAwaitable MainThread()
    {
        return new MainThreadAwaitable();
    }
    
    public static RendererAwaitable Renderer()
    {
        return new RendererAwaitable();
    }
}

public class WorkerThreadAwaitable
{
    public WorkerThreadAwaiter GetAwaiter() => new WorkerThreadAwaiter(); 
    
    public class WorkerThreadAwaiter : INotifyCompletion
    {
        public bool IsCompleted => false;
        
        public void GetResult() { }
        
        public void OnCompleted(Action continuation)
        {
            ThreadPool.UnsafeQueueUserWorkItem(RunAction, continuation);
        }
        
        private static void RunAction(object? state) { ((Action)state!)(); }
    }
}

public class RendererAwaitable
{
    public RendererAwaiter GetAwaiter() => new RendererAwaiter(); 
    
    public delegate void RendererSendOrPostCallback(Renderer aRenderer, object? state);
    
    public class RendererAwaiter : INotifyCompletion
    {
        public bool IsCompleted => false;

        private Renderer myRenderer = null!;

        public Renderer GetResult()
        {
            return myRenderer; 
        }
        
        public void OnCompleted(Action continuation)
        {
            MultithreadingManager.EgoSynchronizationContext.PostRenderer(RunAction, continuation);
        }
        
        private void RunAction(Renderer aRenderer, object? state)
        {
            myRenderer = aRenderer;
            ((Action)state!)(); }
    }
}

public class MainThreadAwaitable
{
    public MainThreadAwaiter GetAwaiter() => new MainThreadAwaiter(); 
    
    public class MainThreadAwaiter : INotifyCompletion
    {
        public bool IsCompleted => false;
        
        public void GetResult() { }
        
        public void OnCompleted(Action continuation)
        {
            MultithreadingManager.EgoSynchronizationContext.Post(RunAction, continuation);
        }
        
        private static void RunAction(object? state) { ((Action)state!)(); }
    }
}