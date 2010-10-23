using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

public class HelloWinService : System.ServiceProcess.ServiceBase {
    
    private EventLog eventLog;

    public HelloWinService()
    {
        this.ServiceName = "WinService1";

        string source = "Main";
        eventLog = new EventLog();
        eventLog.Source = source;
    }
    
    static void Main()
    {
        System.ServiceProcess.ServiceBase[] ServicesToRun;
        ServicesToRun = new System.ServiceProcess.ServiceBase[] { new HelloWinService() };
        System.ServiceProcess.ServiceBase.Run(ServicesToRun);
    }
    
    protected override void OnStart(string[] args)
    {
        eventLog.WriteEntry("starting up!");
    }
    
    protected override void OnStop() {
        eventLog.WriteEntry("shutting down!");
    }
}
