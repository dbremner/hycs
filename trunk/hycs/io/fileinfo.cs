using System;
using System.IO;

public class FileInfoDemo
{
    public static void Main()
    {
        // Create an instance of File and query it 
        FileInfo fileInfo = new FileInfo(@"Makefile");
        long length = fileInfo.Length;
        DateTime lastAccessTime = fileInfo.LastAccessTime;
        
        Console.WriteLine("File size : " + length);
        Console.WriteLine("Last access : " + lastAccessTime);
        
        // Get the last access time of a file transiently
        DateTime lastAccessTime2 = File.GetLastAccessTime(@"Makefile");
        Console.WriteLine("Last access : " + lastAccessTime2);
        
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}
