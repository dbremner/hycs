using huys.DLL;

class TestDLL
{
    static void Main(string[] args)
    {
        long x = 1;
        long y = 1;
        System.Console.WriteLine("From DLL: {0} + {1} = {2}", x, y, HelloDLL.add(x,y));
        System.Console.ReadKey();
    }
}
