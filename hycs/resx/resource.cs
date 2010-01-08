using System;
using System.Collections;
using System.IO;
using System.Resources;

class MainClass
{
    static void Main(string[] args)
    {
        string resXFile = "test.resx";
        string resKey = "myKey";
        string resValueFile = "myValue";

        using (ResXResourceWriter writer = new ResXResourceWriter(resXFile))
        {
            Console.WriteLine("Associating {0} with {1}'s contents", resKey, resValueFile);
            Console.Write("To {0}...", resXFile);

            using (ResXResourceReader reader = new ResXResourceReader(resXFile))
            {
                foreach (DictionaryEntry node in reader)
                    writer.AddResource((string)node.Key, node.Value);
            }

            writer.AddResource(resKey, File.ReadAllBytes(resValueFile));
        }
    }
}
