using System;
using System.IO;

public class ReadFileDemo
{
    public static void Main()
    {
        string cwd = Directory.GetCurrentDirectory();
        string content = System.IO.File.ReadAllText(cwd + "\\Makefile");
        Console.Out.WriteLine("=== content ===");
        Console.WriteLine(content);
    }
}
