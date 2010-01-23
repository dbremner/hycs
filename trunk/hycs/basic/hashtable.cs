using System;
using System.Collections;

namespace ConsoleApplication1
{
    class Program
    {
        static int Main(string[] args)
        {
            Hashtable Chelsea20062007 = new Hashtable();

            Chelsea20062007.Add("Michael", "Ballack");
            Chelsea20062007.Add("Didier", "Drogba");
            Chelsea20062007["Claude"] = "Makelele";

            foreach (DictionaryEntry entry in Chelsea20062007)
                Console.WriteLine("{0} {1}", entry.Key, entry.Value);

            Console.WriteLine();
            return 0;
        }
    }
}