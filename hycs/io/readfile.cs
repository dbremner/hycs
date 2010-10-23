using System;
using System.IO;
using System.Text;

public class ReadFileDemo
{
    public static void Main()
    {
        string cwd = Directory.GetCurrentDirectory();
        string fn = cwd + "\\Makefile";
        
        Console.WriteLine("==============Method One================");
        readFileMethod1(fn);
        
        Console.WriteLine("==============Method Two================");
        readFileMethod2(fn);

        Console.WriteLine("==============Method Three===============");
        readFileMethod3(fn);
        
        Console.WriteLine("==============Method Four===============");
        readFileMethod4(fn);
        
        Console.WriteLine("==============Method Five===============");
        readFileMethod5(fn);
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();   
    }
    
    
    public static void readFileMethod1(string fn)
    {
        string content = System.IO.File.ReadAllText(fn);
        Console.Out.WriteLine("=== content ===");
        Console.WriteLine(content);
    }
    
    public static void readFileMethod2(string fn)
    {
        Stream stream = File.OpenRead(fn);
        int bytesToRead = 1024;
        int bytesRead = 0;
        byte[] buffer = new byte [bytesToRead];

        // Fill up the buffer repeatedly until we reach the end of file
        do {
            bytesRead = stream.Read(buffer, 0, bytesToRead);
            Console.Write(Encoding.ASCII.GetChars(buffer,0, bytesRead));
        } while (bytesToRead == bytesRead);
        stream.Close( );
    }
    
    public static void readFileMethod3(string fn)
    {
        TextReader reader = File.OpenText(fn);

        string line;
        
        // Read a line at a time until we reach the end of file
        while (reader.Peek() != -1) {
            line = reader.ReadLine();
            Console.WriteLine(line);
        }
        reader.Close();
    }
    
    public static void readFileMethod4(string fn)
    {
        StreamReader sr = new StreamReader(fn);
        string content = sr.ReadToEnd();
        Console.WriteLine(content);
        sr.Close();
        // You should call Dispose on 'reader' here, too.
        sr.Dispose();
    }
    
    public static void readFileMethod5(string fn)
    {
        FileStream fs = new FileStream(fn, FileMode.Open);
        int bytesToRead = 1024;
        int bytesRead = 0;
        byte[] buffer = new byte [bytesToRead];

        // Fill up the buffer repeatedly until we reach the end of file
        do {
            bytesRead = fs.Read(buffer, 0, bytesToRead);
            Console.Write(Encoding.ASCII.GetChars(buffer,0, bytesRead));
        } while (bytesToRead == bytesRead);
        fs.Close( );
    }
}
