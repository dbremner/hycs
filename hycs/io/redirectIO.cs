using System;
using System.IO;

public class Redirect
{
    public static void Main()
    {
        StreamReader sr = new StreamReader(
            new BufferedStream(
                new FileStream("redirectIO.cs", FileMode.Open)));
        StreamWriter sw = new StreamWriter(
            new BufferedStream(
                new FileStream("redirect.dat", FileMode.Create)));
        System.Console.SetIn(sr);
        System.Console.SetOut(sw);
        System.Console.SetError(sw);

        String s;
        while((s = System.Console.In.ReadLine()) != null)
        {
            System.Console.Out.WriteLine(s);
        }
        System.Console.Out.Close(); // Remember this!

        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    }
}
