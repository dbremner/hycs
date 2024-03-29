using System;

// MainApp test application 
class MainApp
{
    public static void Main()
    {
        // Create proxy and request a service 
        Proxy proxy = new Proxy();
        proxy.Request();

        // Wait for user 
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}

// "Subject" 
abstract class Subject 
{
    public abstract void Request();    
}

// "RealSubject" 
class RealSubject : Subject
{
    public override void Request()
    {
        Console.WriteLine("Called RealSubject.Request()");
    }
}

// "Proxy" 
class Proxy : Subject
{
    RealSubject realSubject;

    public override void Request()
    {
        // Use 'lazy initialization' 
        if (realSubject == null)
        {
            realSubject = new RealSubject();
        }

        realSubject.Request();
    }  
}
