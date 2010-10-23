using System;
using System.Windows.Forms;

class MessageBoxHelloWorld
{
    public static void Main()
    {
        MessageBox.Show("Hello World!", "info");
        
        MessageBox.Show("Hello World!", "info",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        
        MessageBox.Show(Environment.GetFolderPath(Environment.SpecialFolder.Personal),
            "My Document Folder");
    }
}
