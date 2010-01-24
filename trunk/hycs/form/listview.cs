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

    private ListView lv;



    public HelloForm()
    {
        this.Text = "Hello Form";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ControlBox = true;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.BackColor = Color.Red;

        lv = new ListView();
        lv.Bounds = new Rectangle(new Point(10, 10), new Size(230, 200));


        lv.View = View.Details;
        lv.CheckBoxes = true;
        lv.GridLines = true;

        lv.Columns.Add("Column 1", -2, HorizontalAlignment.Left);
        lv.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
        lv.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
        lv.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

        ListViewItem item1 = new ListViewItem("name", 0);
        item1.Checked = true;
        item1.SubItems.Add("1");
        item1.SubItems.Add("2");
        item1.SubItems.Add("3");
        lv.Items.Add(item1);

        this.Controls.Add(lv);
    }

    public static void Main()
    {
        Application.Run(new HelloForm());
    }
}
