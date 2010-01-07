using System;
using System.Text.RegularExpressions;

class MainClass
{
    public static void Main()
    {
        string s = "A, B,cCCC, D";
        Regex regex = new Regex(@" |, ");
        foreach (string sub in regex.Split(s))
        {
            Console.WriteLine("Word: {0}", sub);
        }
    }
}
