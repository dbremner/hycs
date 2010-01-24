using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

class HelloForm : Form
{
    private string[] strLines = new string[4]
    {   "Made by Pavel Tsekov.",
        "I've just graduated from the",
        "Technical University in Varna (Bulgaria)",
        "Thank you for reading this!"
    };

    private ListBox lb;
    private ListBox lb2;
    
    List<string> _items = new List<string>(); 

    public HelloForm()
    {
        this.Text = "Hello Form";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ControlBox = true;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.Red;

        lb = new ListBox();
        lb.Left = 5;
        lb.Width = this.Width - 20;
        lb.Top = this.Height/6;
        lb.Font = new Font(lb.Font, FontStyle.Bold);

        for (int i = 0; i < strLines.Length; ++i)
        {
            lb.Items.Add(strLines[i]);
        }

        lb2 = new ListBox();
        lb2.Left = 5;
        lb2.Width = this.Width - 20;
        lb2.Top = this.Height - 140;
        lb2.Font = new Font(lb.Font, FontStyle.Bold);
        _items.Add("One"); // <-- Add these
        _items.Add("Two");
        _items.Add("Three");

        lb2.DataSource = _items;

 
        this.Controls.Add(lb);
        this.Controls.Add(lb2);
    }

    public static void Main()
    {
        Application.Run(new HelloForm());
    }
}
