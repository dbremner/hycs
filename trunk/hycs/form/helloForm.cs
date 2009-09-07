using System;
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

    private Button btnOK;
    private Label lblPhones;
    private RichTextBox rtbInfo;

    public HelloForm()
    {
        this.Text = "Hello Form";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ControlBox = true;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        btnOK = new Button();
        btnOK.Text = "OK";
        btnOK.Left = this.ClientRectangle.Width-btnOK.Width-10;
        btnOK.Top = this.ClientRectangle.Height-btnOK.Height-10;
        btnOK.Visible = true;
        btnOK.Click += new EventHandler(btnOK_Click);
        this.Controls.Add(btnOK);

        lblPhones = new Label();
        lblPhones.Left = 0;
        lblPhones.Width = this.Width;
        lblPhones.Top = this.Height/6;
        lblPhones.Font = new Font(lblPhones.Font, FontStyle.Bold);
        lblPhones.TextAlign = ContentAlignment.MiddleCenter;
        lblPhones.Text = "P H O N E S";
        lblPhones.Visible = true;
        this.Controls.Add(lblPhones);

        rtbInfo=new RichTextBox();
        rtbInfo.Left = 20;
        rtbInfo.Top = this.Height/3;
        rtbInfo.Width = this.Width-40;
        rtbInfo.Lines = strLines;
        rtbInfo.ReadOnly = true;
        rtbInfo.Visible = true;
        this.Controls.Add(rtbInfo);

        this.Load += new EventHandler(Form_Load);
        this.Click += new EventHandler(Form_Click);
    }

    private void btnOK_Click(object sender, EventArgs eArgs)
    {
        this.Close();
    }

    private void Form_Load(object sender, EventArgs e)
    {
        this.Opacity = 0.50;
    }

    private void Form_Click(object sender, EventArgs e)
    {
        MessageBox.Show("You Click me!", "hello", MessageBoxButtons.OK);
    }

    public static void Main()
    {
        Application.Run(new HelloForm());
    }
}
