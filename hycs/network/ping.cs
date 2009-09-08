using System;
using System.Net.NetworkInformation;

class MainClass
{
    public static void Main(string[] args)
    {
        using (Ping ping = new Ping())
        {
            try
            {
                PingReply reply = ping.Send("127.0.0.1", 100);

                if (reply.Status == IPStatus.Success)
                {
                    Console.WriteLine("Success - IP Address:{0} Time:{1}ms",
                        reply.Address, reply.RoundtripTime);
                }
                else
                {
                    Console.WriteLine(reply.Status);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error ({0})", ex.InnerException.Message);
            }
        }
    }
}
