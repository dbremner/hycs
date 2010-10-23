using System;
using System.IO;
using System.Text.RegularExpressions;

class TGrep
{
    public static void Main(string[] args)
    {
        TGrep tg = new TGrep(args[0]);
        tg.ApplyToFiles(args[1]);
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    Regex re;

    TGrep(string pattern)
    {
        re = new Regex(pattern);
    }

    void ApplyToFiles(string fPattern)
    {
        string[] fNames = Directory.GetFiles(".", fPattern);
        foreach (string fName in fNames )
        {
            StreamReader sr = null;
            try{
                sr = new StreamReader(
                    new BufferedStream(
                        new FileStream(
                            fName, FileMode.Open)));
                string line = "";
                int lCount = 0;
                while((line = sr.ReadLine()) != null)
                {
                    lCount++;
                    if(re.IsMatch(line))
                    {
                        System.Console.WriteLine(
                            "{0} {1}: {2}", fName, lCount, line);
                    }
                }
            } finally {
                sr.Close();
            }
        }
    }
}
