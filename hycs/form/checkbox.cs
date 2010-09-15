using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

class CheckBoxForm : Form
{
    private CheckBox ckbox;

    public CheckBoxForm()
    {
        this.Text = "checkbox";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ControlBox = true;

        ckbox = new CheckBox();
        ckbox.Text = "off";
        ckbox.Left = this.ClientRectangle.Width - ckbox.Width  - 100;
        ckbox.Top = this.ClientRectangle.Height - ckbox.Height - 100;
        ckbox.Appearance = Appearance.Button;
        ckbox.BackColor = Color.Red;
        ckbox.CheckState = CheckState.Unchecked;
        //ckbox.Click += new EventHandler(ckbox_Click);
        ckbox.CheckStateChanged += new EventHandler(ckbox_Click);
        this.Controls.Add(ckbox);
    }

    private void ckbox_Click(object sender, EventArgs e)
    {
        if (!ckbox.Checked)
        {
            this.ckbox.Text = "Off";
        }
        else
        {
            this.ckbox.Text = "On";
        }
    }

    public static void Main()
    {
        Application.Run(new CheckBoxForm());
    }
}

