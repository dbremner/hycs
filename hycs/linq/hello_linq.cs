using System;
using System.Threading;

class MainClass
{
    public static void MyHandler(ConsoleCtrl.ConsoleEvent consoleEvent)
    {
        Console.WriteLine("Event: {0}", consoleEvent);
    }
    
    public static void Main()
    {      
        
        Thread.Sleep(100);  // sleep 15 seconds
    }
}
