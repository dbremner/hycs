using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;

public class MainClass{

   public static void Main(){
        Regex r1 = new Regex(@"<([^>]+)>[^<]*</(\1)>");
        string s0 = "<M>S</M>";
        string s1 = "<M>S</I>";

        Console.WriteLine(r1.IsMatch(s0));
        Console.WriteLine(r1.IsMatch(s1));
   }
}

