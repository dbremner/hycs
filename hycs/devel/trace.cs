using System;
using System.IO;
using System.Diagnostics;

class MainClass
{
  [STAThread]
  static void Main(string[] args)
  {
    Trace.WriteLine("My Trace String");
    Trace.Flush();
    
    int i = 0;
    Trace.Assert((i == 1), "My Trace Assertion");
    
    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
    Trace.WriteLine("My Trace to the console");
  }
}
