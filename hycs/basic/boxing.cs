public class EntryPoint 
{ 
    public static void Main() { 
        int employeeID = 303; 
        object boxedID = employeeID; 
         
        employeeID = 404; 
        int unboxedID = (int) boxedID; 
 
        System.Console.WriteLine( employeeID.ToString() ); 
        System.Console.WriteLine( unboxedID.ToString() );

        System.Console.WriteLine("Press any key to continue...");
        System.Console.ReadKey();
    } 
}
