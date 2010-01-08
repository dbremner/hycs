using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;

namespace HexView
{
  /// <summary>
  /// Summary description for Form1.
  /// </summary>
  public class frmHexView : System.Windows.Forms.Form
  {
    private System.Windows.Forms.MainMenu mainMenu1;
    private System.Windows.Forms.MenuItem mnuFileMenu;
    private System.Windows.Forms.MenuItem mnuFileOpen;
    private System.Windows.Forms.MenuItem mnuFileClose;
    private System.Windows.Forms.MenuItem mnuFileExit;
    private System.Windows.Forms.MenuItem mnuAboutMenu;
    private System.Windows.Forms.MenuItem mnuAboutHexView;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public frmHexView()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
      textBox1.BackColor = Color.White;
      this.openFileDialog1.Filter = "Text files (*.txt)|*.txt|Wide Character Files (*.wcs)|*.wcs|All Files (*.*)|*.*||";
      textBox1.Font = new Font ("Courier New", 12);
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.mainMenu1 = new System.Windows.Forms.MainMenu();
      this.mnuFileMenu = new System.Windows.Forms.MenuItem();
      this.mnuFileOpen = new System.Windows.Forms.MenuItem();
      this.mnuFileClose = new System.Windows.Forms.MenuItem();
      this.mnuFileExit = new System.Windows.Forms.MenuItem();
      this.mnuAboutMenu = new System.Windows.Forms.MenuItem();
      this.mnuAboutHexView = new System.Windows.Forms.MenuItem();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.SuspendLayout();
      // 
      // mainMenu1
      // 
      this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                            this.mnuFileMenu,
                                            this.mnuAboutMenu});
      // 
      // mnuFileMenu
      // 
      this.mnuFileMenu.Index = 0;
      this.mnuFileMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                            this.mnuFileOpen,
                                            this.mnuFileClose,
                                            this.mnuFileExit});
      this.mnuFileMenu.Text = "File";
      // 
      // mnuFileOpen
      // 
      this.mnuFileOpen.Index = 0;
      this.mnuFileOpen.Text = "Open";
      this.mnuFileOpen.Click += new System.EventHandler(this.OnFileOpen);
      // 
      // mnuFileClose
      // 
      this.mnuFileClose.Index = 1;
      this.mnuFileClose.Text = "Close";
      this.mnuFileClose.Click += new System.EventHandler(this.OnFileClose);
      // 
      // mnuFileExit
      // 
      this.mnuFileExit.Index = 2;
      this.mnuFileExit.Text = "Exit";
      this.mnuFileExit.Click += new System.EventHandler(this.OnFileExit);
      // 
      // mnuAboutMenu
      // 
      this.mnuAboutMenu.Index = 1;
      this.mnuAboutMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                             this.mnuAboutHexView});
      this.mnuAboutMenu.Text = "About";
      // 
      // mnuAboutHexView
      // 
      this.mnuAboutHexView.Index = 0;
      this.mnuAboutHexView.Text = "About HexView";
      this.mnuAboutHexView.Click += new System.EventHandler(this.OnAboutAbout);
      // 
      // textBox1
      // 
      this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.textBox1.Multiline = true;
      this.textBox1.Name = "textBox1";
      this.textBox1.ReadOnly = true;
      this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox1.Size = new System.Drawing.Size(592, 317);
      this.textBox1.TabIndex = 0;
      this.textBox1.Text = "";
      this.textBox1.WordWrap = false;
      // 
      // frmHexView
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(592, 317);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                      this.textBox1});
      this.Menu = this.mainMenu1;
      this.Name = "frmHexView";
      this.Text = "Hex View";
      this.ResumeLayout(false);

    }
    #endregion

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() 
    {
      Application.Run(new frmHexView());
    }

    byte [] Data;

    private void OnFileOpen(object sender, System.EventArgs e)
    {
      if (openFileDialog1.ShowDialog () == DialogResult.Cancel)
        return;
      FileStream strm;
      try
      {
        strm = new FileStream (openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
      }
      catch (Exception)
      {
        string str = "Cannot open " + openFileDialog1.FileName + " for reading";
        MessageBox.Show (str, "HexView");
        return;
      }
      if (Data != null)
        Array.Clear (Data, 0, Data.Length);
      Data = new Byte[strm.Length];
      strm.Read (Data, 0, (int) strm.Length);
      strm.Close();
      FillTextBox ();
      int index = openFileDialog1.FileName.LastIndexOf ('\\');
      this.Text = this.Text + " - " + openFileDialog1.FileName.Substring (index + 1);
    }
    private void FillTextBox ()
    {
      textBox1.Text = "";
      StringBuilder strb = new StringBuilder ();
      StringBuilder text = new StringBuilder ();
      char [] ch = new char [1];
      for (int x = 0; x < Data.Length; x += 16)
      {
        text.Length = 0;
        strb.Length = 0;
        for (int y = 0; y < 16; ++y)
        {
          if ((x + y) > (Data.Length - 1))
            break;
          ch[0] = (char) Data[x + y];
          strb.AppendFormat ("{0,0:X2} ", (int) ch[0]);
          if (((int) ch[0] < 32) || ((int) ch[0] > 127))
            ch[0] = '.';
          text.Append (ch);
        }
        text.Append ("\r\n");
        while (strb.Length < 52)
          strb.Append (" ");
        strb.Append (text.ToString());
        textBox1.Text += strb.ToString ();
      }
      textBox1.Select (0, 0);
    }

    private void OnFileClose(object sender, System.EventArgs e)
    {
      textBox1.Text = "";
      this.Text = "Hex View";
    }

    private void OnFileExit(object sender, System.EventArgs e)
    {
      Application.Exit ();
    }

    private void OnAboutAbout(object sender, System.EventArgs e)
    {
      About about = new About();
      about.ShowDialog();
    }
  }
  /// <summary>
  /// Summary description for About.
  /// </summary>
  public class About : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button button1;
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;

    public About()
    {
      //
      // Required for Windows Form Designer support
      //
      InitializeComponent();

      //
      // TODO: Add any constructor code after InitializeComponent call
      //
    }

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if(components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(148, 112);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(104, 24);
      this.button1.TabIndex = 2;
      this.button1.Text = "OK";
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
      this.label1.Location = new System.Drawing.Point(36, 16);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(344, 56);
      this.label1.TabIndex = 0;
      this.label1.Text = "A Simple Hex Viewer";
      this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.Location = new System.Drawing.Point(36, 80);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(344, 16);
      this.label2.TabIndex = 1;
      this.label2.Text = "C# Tips and Techniques";
      this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // About
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(416, 149);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                      this.button1,
                                      this.label2,
                                      this.label1});
      this.Name = "About";
      this.Text = "About Hex View";
      this.ResumeLayout(false);

    }
    #endregion

    private void button1_Click(object sender, System.EventArgs e)
    {
      this.Close ();
    }
  }

  
}
