using System.Runtime.InteropServices;
using System;
using huys.DLL;

class TestDLL
{
    [DllImport("nativeDLL.dll", CallingConvention = CallingConvention.StdCall)]
    private static extern int add(int a, int b);

    static void Main(string[] args)
    {
        long x = 1;
        long y = 1;
        try {
            System.Console.WriteLine("From csharp DLL: {0} + {1} = {2}", x, y, HelloDLL.add(x,y));
            System.Console.WriteLine("From native DLL: {0} + {1} = {2}", x, y, add((int)x,(int)y));
        } catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        System.Console.ReadKey();
    }
}
