class DataType
{
    static void Main(string[] args)
    {
        System.Console.WriteLine("Data Types in CSharp:");

        // value types
        /* 
            value-type:
                struct-type
                enum-type
            struct-type:
                type-name
                simple-type
            simple-type:
                numeric-type
                bool
            numeric-type:
                integral-type
                floating-point-type
                decimal
            integral-type:
                sbyte
                byte
                short
                ushort
                int
                uint
                long
                ulong
                char
            floating-point-type:
                float
                double
            enum-type:
                type-name 
         */
        int i = 10;
        int j = new int();

        System.Console.WriteLine("i = {0}, j = {1}", i, j);

        System.Console.ReadKey();
    }
}
