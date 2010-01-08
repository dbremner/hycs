using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;

/// <summary>
///    Summary description for Win32Form2.
/// </summary>
public class Win32Form2 : System.Windows.Forms.Form {

    /// <summary>
    ///    Required by the Win Forms designer
    /// </summary>
    private System.ComponentModel.Container components;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.ProgressBar progressBar1;

    public Win32Form2() {
        // Required for Win Form Designer support
        InitializeComponent();
    }

    /// <summary>
    ///    The main entry point for the application.
    /// </summary>
    public static void Main(string[] args) {
        Application.Run(new Win32Form2());
    }

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with an editor
    /// </summary>
    private void InitializeComponent() {
        this.components = new System.ComponentModel.Container();
        this.label1 = new System.Windows.Forms.Label();
        this.progressBar1 = new System.Windows.Forms.ProgressBar();
        this.button1 = new System.Windows.Forms.Button();
        this.textBox1 = new System.Windows.Forms.TextBox();
        
        //@design this.TrayHeight = 0;
        //@design this.TrayLargeIcon = false;
        //@design this.TrayAutoArrange = true;
        label1.Location = new System.Drawing.Point(32, 40);
        label1.Text = "Progress Value";
        label1.Size = new System.Drawing.Size(88, 24);
        label1.TabIndex = 2;
        
        progressBar1.Maximum = 10;
        progressBar1.Location = new System.Drawing.Point(8, 312);
        progressBar1.Minimum = 0;
        progressBar1.TabIndex = 0;
        progressBar1.Value = 0;
        
        //We have calculated the excat size which will result in only 20 boxes to be drawn
        
        progressBar1.Size = new System.Drawing.Size(520, 40);
        progressBar1.Step = 1;
        
        button1.Location = new System.Drawing.Point(152, 168);
        button1.Size = new System.Drawing.Size(144, 48);
        button1.TabIndex = 1;
        button1.Text = "button1";
        button1.Click += new System.EventHandler(button1_Click);
        
        textBox1.Location = new System.Drawing.Point(136, 40);
        textBox1.Text = "0";
        textBox1.TabIndex = 3;
        textBox1.Size = new System.Drawing.Size(184, 20);
        this.Text = "Win32Form2";
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(616, 393);
        this.Click += new System.EventHandler(Win32Form2_Click);
        
        this.Controls.Add(textBox1);
        this.Controls.Add(label1);
        this.Controls.Add(button1);
        this.Controls.Add(progressBar1);
    }

    protected void button1_Click(object sender, System.EventArgs e) {
        
        //this checking is automatically done as stated in the Ref Documentation 
        //but it does not work , BUGssssss 
        //so we have to do it shhhhh .... 
        if (progressBar1.Value == progressBar1.Maximum){
            progressBar1.Value =  progressBar1.Minimum;
        }
        progressBar1.PerformStep();
        textBox1.Text=progressBar1.Value.ToString() ; // Displays the values of progressbar in textbox
        
    }
    protected void Win32Form2_Click(object sender, System.EventArgs e) {
    }
}


