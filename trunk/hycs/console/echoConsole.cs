public class EchoConsole
{ 
    public static void Main(string[] args)
    { 
        string s; 
        while((s = System.Console.In.ReadLine()).Length != 0) 
        {
            System.Console.WriteLine(s);
        }
        System.Console.WriteLine("Press Any Key to Continue ...");
        System.Console.ReadKey();
    }
}
