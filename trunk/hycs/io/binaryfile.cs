using System;
using System.IO;

public class BinaryFileIO
{
    public static void Main()
    {
        string fn = "ccc";
        
        write2file(fn);
        
        read4file(fn);

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();  
    }
    
    public static void read4file(string fn)
    {
        BinaryReader br = new BinaryReader(File.Open(fn, FileMode.Open));
        int num;
        string text;
        
        num = br.ReadInt32();
        Console.WriteLine(num);
        
        num = br.ReadInt32();
        Console.WriteLine(num);

        text = br.ReadString();
        Console.WriteLine(text);

        num = br.ReadInt32();
        Console.WriteLine(num);
        
        br.Close();
    }
    
    public static void write2file(string fn)
    {
        BinaryWriter bw = new BinaryWriter(File.Open(fn, FileMode.Create));
        bw.Write(1);
        bw.Write(2);
        bw.Write("ABC");
        bw.Write(3);
        bw.Close();
    }
}
