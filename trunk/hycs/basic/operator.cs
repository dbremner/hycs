using System;

public class BaseType {} 
 
public class DerivedType : BaseType {}
 
public class EntryPoint 
{
    static void test_is() {
        String derivedObj = "Dummy"; 
        Object baseObj1 = new Object(); 
        Object baseObj2 = derivedObj; 
 
        Console.WriteLine( "baseObj2 {0} String", 
                           baseObj2 is String ? "is" : "isnot" ); 
        Console.WriteLine( "baseObj1 {0} String", 
                           baseObj1 is String ? "is" : "isnot" ); 
        Console.WriteLine( "derivedObj {0} Object", 
                           derivedObj is Object ? "is" : "isnot" ); 
 
        int j = 123; 
        object boxed = j; 
        object obj = new Object(); 
 
        Console.WriteLine( "boxed {0} int", 
                           boxed is int ? "is" : "isnot" ); 
        Console.WriteLine( "obj {0} int", 
                           obj is int ? "is" : "isnot" ); 
        Console.WriteLine( "boxed {0} System.ValueType", 
                           boxed is ValueType ? "is" : "isnot" );    
    }
 
    static void Main() { 

        test_is();
                           
        DerivedType derivedObj = new DerivedType(); 
        BaseType baseObj1 = new BaseType(); 
        BaseType baseObj2 = derivedObj; 
 
        DerivedType derivedObj2 = baseObj2 as DerivedType; 
        if( derivedObj2 != null ) { 
            Console.WriteLine( "Conversion Succeeded" ); 
        } else { 
            Console.WriteLine( "Conversion Failed" ); 
        } 
         
        derivedObj2 = baseObj1 as DerivedType; 
        if( derivedObj2 != null ) { 
            Console.WriteLine( "Conversion Succeeded" ); 
        } else { 
            Console.WriteLine( "Conversion Failed" ); 
        } 
         
        BaseType baseObj3 = derivedObj as BaseType; 
        if( baseObj3 != null ) { 
            Console.WriteLine( "Conversion Succeeded" ); 
        } else { 
            Console.WriteLine( "Conversion Failed" ); 
        }
    }    
}
