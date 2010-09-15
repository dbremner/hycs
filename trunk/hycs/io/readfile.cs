using System;
using System.IO;

public class ReadFileDemo
{
    public static void Main()
    {
        string contents = System.IO.File.ReadAllText(@"C:\t1");
        Console.Out.WriteLine("contents = " + contents);
    }
}
