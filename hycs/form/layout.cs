using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace LayoutManager
{
    /// <summary>
    /// Summary description for LayoutManager.
    /// </summary>
    public class LayoutManager : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.TabControl tabControl1;
        internal System.Windows.Forms.TabPage tabPage1;
        internal System.Windows.Forms.TabPage tabPage2;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public LayoutManager()
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right);
            this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                                      this.tabPage1,
                                                                                      this.tabPage2});
            this.tabControl1.Location = new System.Drawing.Point(6, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(280, 260);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(272, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(272, 234);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TabPage2";
            this.tabPage2.Visible = false;
            // 
            // LayoutManager
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.tabControl1});
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.Name = "LayoutManager";
            this.Text = "LayoutManager";
            this.Load += new System.EventHandler(this.LayoutManager_Load);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new LayoutManager());
        }

        private void LayoutManager_Load(object sender, System.EventArgs e)
        {
            // Create and attach the layout manager.
            SingleLineFlow layoutManager = new SingleLineFlow(tabPage1, 20);

            // Add 10 sample checkboxes.
            CheckBox chkbox;

            for (int i = 1; i < 11; i++)
            {
                chkbox = new CheckBox();
                chkbox.Text = "Setting " + i.ToString();
                tabPage1.Controls.Add(chkbox);
            }

        }
    }
    public class SingleLineFlow
    {
        private Control container;
        private int margin;

        public SingleLineFlow(Control parent, int margin)
        {
            this.container = parent;
            this.margin = margin;

            // Attach the event handler.
            container.Layout += new LayoutEventHandler(UpdateLayout);

            // Refresh the layout.
            UpdateLayout(this, null);
        }

        public int Margin
        {
            get
            {
                return margin;
            }
            set
            {
                margin = value;
            }
        }

        // This is public so it can be triggered manually if needed.
        public void UpdateLayout(object sender,
            System.Windows.Forms.LayoutEventArgs e)
        {
            int y = 0;
            foreach (Control ctrl in container.Controls)
            {
                y += Margin;
                ctrl.Left = Margin;
                ctrl.Top = y;
                ctrl.Width = container.Width;
                ctrl.Height = Margin;
            }
        }

    }

}

