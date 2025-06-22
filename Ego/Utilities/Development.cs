using ZLogger;

namespace Utilities;

public static class Development
{
    public static void TryUntilSuccess(Action aAction)
    {
        while(true)
        {
            try
            {
                aAction();
                break;
            }
            catch (Exception e)
            {
                Log.Info(e, $"");
            }
        }
    }
    
    public static void TryForever(Action aAction)
    {
        while(true)
        {
            try
            {
                aAction();
            }
            catch (Exception e)
            {
                Log.Info(e, $"");
            }
        }
    }
}