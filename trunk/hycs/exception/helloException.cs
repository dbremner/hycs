using System;
using System.IO;

class SimpleException : ApplicationException {}

public class HelloException
{
    public void Foo() {
        System.Console.WriteLine("Throwing SimpleException from Foo()");
        throw new SimpleException();
    }

    static void Main(string[] args)
    {
        HelloException he = new HelloException();

        try {
            he.Foo();
        } catch (SimpleException ) {
            System.Console.WriteLine("Caught it!");
        }

        try
        {
            File.OpenRead("NonExistentFile");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        FileStream outStream = null;
        FileStream inStream = null;
        try
        {
            outStream = File.OpenWrite("DestinationFile.txt");
            inStream = File.OpenRead("BogusInputFile.txt");
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            if (outStream != null)
            {
                outStream.Close();
                Console.WriteLine("outStream closed.");
            }
            if (inStream != null)
            {
                inStream.Close();
                Console.WriteLine("inStream closed.");
            }
        }

        System.Console.ReadKey();
    }
}
