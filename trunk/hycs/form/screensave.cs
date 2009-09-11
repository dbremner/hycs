
// This Article is a simple one to show the usage of KeyEvent and MouseEvent.

// Please move the mouse or press a key to Exit this Program.
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace ScreenSave
{
    public class KeyEventandMouseEvent : System.Windows.Forms.Form {
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;
        private Boolean boolFlag;
        private int ixStart;
        private int iyStart;

        public KeyEventandMouseEvent() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing ) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // timer1
            //
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            //
            // label1
            //
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(8, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Roller - Developed in C-Sharp";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            //
            // KeyEventandMouseEvent
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
            this.ClientSize = new System.Drawing.Size(568, 32);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.label1});
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "KeyEventandMouseEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KeyEventandMouseEvent";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPressEvent);
            this.Load += new System.EventHandler(this.KeyEventandMouseEvent_Load);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMoveEvent);
            this.ResumeLayout(false);
        }
        #endregion
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new KeyEventandMouseEvent());
        }
        private void timer1_Tick(object sender, System.EventArgs e)
        {
            int i;

            i = label1.Location.X;
            if (i >= 750)
            i = 0;
            else
            i = label1.Location.X + 5;

            label1.Location = new Point(i,280);
        }
        private void KeyEventandMouseEvent_Load(object sender, System.EventArgs e)
        {

        }
        private void OnMouseMoveEvent(object sender,MouseEventArgs e)
        {
            //Application.Exit();
            if (ixStart == 0 && iyStart == 0)
            {
                ixStart = e.X;
                iyStart = e.Y;
            }
            else if (e.X != ixStart || e.Y != iyStart)
                Application.Exit();

        }
        private void OnKeyPressEvent(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            Application.Exit();
        }
        private void label1_Click(object sender, System.EventArgs e)
        {
        }
    }
}
