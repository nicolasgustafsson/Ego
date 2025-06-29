using System.Runtime.CompilerServices;

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