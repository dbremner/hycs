using System;
using System.ServiceProcess;

class MainClass {
    public static void StartService(string server, string service) {
            Console.WriteLine("About to start the {0} Service", service);
            ServiceController svcCtrl;

            if (server.Length != 0)
                svcCtrl = new ServiceController(server, service);
            else
                svcCtrl = new ServiceController(service);

            svcCtrl.Start();
    }

    public static void StopService(string server, string service) {
            Console.WriteLine("About to stop the {0} Service", service);
            ServiceController svcCtrl;

            if (server.Length != 0)
                svcCtrl = new ServiceController(server, service);
            else
                svcCtrl = new ServiceController(service);

            svcCtrl.Stop();
    }

    public static void ShowServices(string server) {
            ServiceController[] services;
            if (server.Length != 0)
                services = ServiceController.GetServices(server);
            else
                services = ServiceController.GetServices();

            foreach (ServiceController svc in services) {
                Console.WriteLine("Found service : {0}", svc.DisplayName);
            }
    }


    public static void Main(string[] args) {
        StartService(args[0], args[2]);
        StopService(args[0], args[2]);
        ShowServices(args[0]);
    }
}
