public struct Coordinate  //this is a value type 
{ 
    public int x;
     public int y; 
} 
 
public class EntryPoint //this is a reference type 
{ 
    public static void AttemptToModifyCoord( Coordinate coord ) { 
        coord.x = 1; 
        coord.y = 3; 
    } 
 
    public static void ModifyCoord( ref Coordinate coord ) { 
        coord.x = 10; 
        coord.y = 10; 
    } 
 
    static void Main() { 
        Coordinate location; 
        location.x = 50; 
        location.y = 50; 
 
        AttemptToModifyCoord( location ); 
        System.Console.WriteLine( "( {0}, {1} )", location.x, location.y ); 
 
        ModifyCoord( ref location ); 
        System.Console.WriteLine( "( {0}, {1} )", location.x, location.y ); 
    } 
}