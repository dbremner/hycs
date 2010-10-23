using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using System.ServiceProcess;
using System.Threading;

namespace TimeApp
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    class TimeServer : ServiceBase
    {
        private EventLog eventLog;
        
        private Thread ctThread;
        
        private readonly int port = 48888;
        private readonly IPAddress ip = IPAddress.Parse("127.0.0.1");

        private TcpListener listener;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {     
            //
            // TODO: Add code to start application here
            //
            //TimeServer ts = new TimeServer();
            //ts.Start();
            
            ServiceBase[] ServicesToRun = new ServiceBase[] { new TimeServer() };
            ServiceBase.Run(ServicesToRun);
        }
        
        public TimeServer()
        {
            this.ServiceName = "TimeServer";

            string source = "TimeServer";
            eventLog = new EventLog();
            eventLog.Source = source;
            
            this.listener = new TcpListener(this.ip, this.port);
            
            ctThread = new Thread(Start);
        }

        protected override void OnStart(string[] args)
        {
            eventLog.WriteEntry("starting up!");
            ctThread.Start();
        }
        
        protected override void OnStop() {
            eventLog.WriteEntry("shutting down!");
            ctThread.Abort();
        }
        
        
        public void Start()
        {
            this.listener.Start();

            Socket s;
            Byte[] incomingBuffer;
            Byte[] time;
            int bytesRead;

            while (true)
            {
                s = this.listener.AcceptSocket();
                
                incomingBuffer = new Byte[100];
                bytesRead = s.Receive(incomingBuffer);
                
                eventLog.WriteEntry("Recv : " + Encoding.ASCII.GetString(incomingBuffer));
                
                time = Encoding.ASCII.GetBytes(DateTime.Now.ToString().ToCharArray());
                s.Send(time);
            }
        }
    }
}
