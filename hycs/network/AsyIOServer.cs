using System;
using System.Net.Sockets;
using System.Net;

public class AsynchIOServer
{
    public static void Main()
    {
        TcpListener tcpListener = new TcpListener(10);
        tcpListener.Start(); 
        Socket socketForClient = tcpListener.AcceptSocket();
        if (socketForClient.Connected)
        {
            Console.WriteLine("Client connected");
            NetworkStream networkStream = new NetworkStream(socketForClient);
            System.IO.StreamWriter streamWriter =
            new System.IO.StreamWriter(networkStream);
            System.IO.StreamReader streamReader =
            new System.IO.StreamReader(networkStream);
            string theString = "Sending";
            streamWriter.WriteLine(theString);
            Console.WriteLine(theString);
            streamWriter.Flush();
            theString = streamReader.ReadLine();
            Console.WriteLine(theString);
            streamReader.Close();
            networkStream.Close();
            streamWriter.Close();
        }
        socketForClient.Close();
        Console.WriteLine("Exiting...");
    }
}

