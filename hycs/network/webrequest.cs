using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private Button btn1;
        private TextBox textBox1;
        private TextBox textBox2;

        public Form1()
        {
            btn1 = new Button();
            btn1.Text = "Send";
            btn1.Top =  10;
            btn1.Left = 20;
            btn1.Click += new EventHandler(button1_Click);

            this.Text = "Chat Client Form";

            textBox1 = new TextBox();
            textBox1.Left = 20;
            textBox1.Top = 80;
            textBox1.Width = this.ClientRectangle.Width - 40;

            textBox2 = new TextBox();
            textBox2.Top = 120;
            textBox2.Left = 20;
            textBox2.Width = this.ClientRectangle.Width - 40;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader inStream ;
                WebRequest webRequest ;
                WebResponse webresponse ;
                
                webRequest = WebRequest.Create(textBox1.Text);
                webresponse = webRequest.GetResponse();
                inStream = new StreamReader(webresponse.GetResponseStream());
                textBox2.Text = inStream.ReadToEnd();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}