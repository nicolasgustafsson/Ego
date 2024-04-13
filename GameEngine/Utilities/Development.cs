
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
                Console.WriteLine(e);
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
                Console.WriteLine(e);
            }
        }
    }
}