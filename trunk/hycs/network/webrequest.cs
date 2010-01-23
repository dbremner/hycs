using System;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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
                Console.WriteLine(ex.ToString());
            }
        }
    }
}