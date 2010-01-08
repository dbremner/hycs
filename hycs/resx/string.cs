using System;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
public class Test
{
   
    public static void Main(String[] a)
    {
        ResourceManager FormResources = new ResourceManager("StringTable", Assembly.GetExecutingAssembly());
        string Message;
        
        Message = FormResources.GetString("Message");
        MessageBox.Show(Message);
    }
}
