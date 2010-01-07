using System;
using System.Net;

class MainClass
{
    public static void Main()
    {
        IPAddress test = IPAddress.Parse("192.168.1.1");
        Console.WriteLine(test);
        
        test = IPAddress.Loopback;
        Console.WriteLine(test);
        
        test = IPAddress.Broadcast;
        Console.WriteLine(test);
        
        test = IPAddress.Any;
        Console.WriteLine(test);
 
        test = IPAddress.None;
        Console.WriteLine(test);

        if (IPAddress.IsLoopback(test))
            Console.WriteLine("The Loopback address is: {0}", test.ToString());
        else
            Console.WriteLine("Error obtaining the loopback address");
        
        test = IPAddress.Parse("192.168.1.1");
        IPEndPoint ie = new IPEndPoint(test, 8000);
    
        Console.WriteLine("The IPEndPoint is: {0}", ie.ToString());
        Console.WriteLine("The AddressFamily is: {0}", ie.AddressFamily);
        Console.WriteLine("The address is: {0}, and the port is: {1}", ie.Address, ie.Port);
        
        short test1 = 45;
        int test2 = 314159;
        long test3 = -123456789033452;
        byte[] data = new byte[1024];
        string output;

        short test1b = IPAddress.HostToNetworkOrder(test1);
        data = BitConverter.GetBytes(test1b);
        output = BitConverter.ToString(data);
        Console.WriteLine("test1 = {0}, nbo = {1}", test1b, output);

        int test2b = IPAddress.HostToNetworkOrder(test2);
        data = BitConverter.GetBytes(test2b);
        output = BitConverter.ToString(data);
        Console.WriteLine("test2 = {0}, nbo = {1}", test2b, output);

        long test3b = IPAddress.HostToNetworkOrder(test3);
        data = BitConverter.GetBytes(test3b);
        output = BitConverter.ToString(data);
        Console.WriteLine("test3 = {0}, nbo = {1}", test3b, output);
        
        Console.ReadKey();
    }
}
