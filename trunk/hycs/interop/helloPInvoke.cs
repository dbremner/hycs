using System;
using System.Runtime.InteropServices;

class HelloPlatformInvoke
{
    [DllImport("msvcrt.dll")]
    public static extern int puts(string c);
    [DllImport("msvcrt.dll")]
    internal static extern int _flushall();

    public static void Main()
    {
        puts("Test");
        _flushall();

        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }
}
