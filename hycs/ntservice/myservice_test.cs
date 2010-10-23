using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TimeAppTest
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class TimeServerTest
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            int port = 48888;
            string ip = "127.0.0.1";

            TcpClient client = new TcpClient(ip, port);
            Byte[] request = Encoding.ASCII.GetBytes("request");
            
            Console.WriteLine("Sending request...");
            
            client.GetStream().Write(request, 0, request.Length);
            
            Byte[] response = new Byte[client.ReceiveBufferSize];
            int bytesRead = client.GetStream().Read(response, 0, client.ReceiveBufferSize);

            Console.WriteLine("Received response: " + Encoding.ASCII.GetString(response));
            
            client.Close();
        }
    }
}
