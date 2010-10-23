using System;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Text; 

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        System.Net.Sockets.TcpClient clientSocket = new System.Net.Sockets.TcpClient();

        private Button btn1;
        private Button btn2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;

        public Form1()
        {
            this.Text = "Chat Client Form";

            textBox1 = new TextBox();
            textBox1.Left = 20;
            textBox1.Top = 20;
            textBox1.Width = this.ClientRectangle.Width - 40;

            btn1 = new Button();
            btn1.Text = "Send";
            btn1.Top = textBox1.Bottom + 10;
            btn1.Left = 20;
            btn1.Click += new EventHandler(button1_Click);

            textBox2 = new TextBox();
            textBox2.Top = btn1.Bottom + 20;
            textBox2.Left = 20;
            textBox2.Width = this.ClientRectangle.Width - 40;

            btn2 = new Button();
            btn2.Text = "Recv";
            btn2.Top = textBox2.Bottom + 10;
            btn2.Left = 20;
            //btn2.Click += new EventHandler(button2_Click);

            textBox3 = new TextBox();
            textBox3.Top = btn2.Bottom + 20;
            textBox3.Left = 20;
            textBox3.Width = this.ClientRectangle.Width - 40;

            this.Controls.Add(textBox1);
            this.Controls.Add(btn1);
            this.Controls.Add(textBox2);
            this.Controls.Add(btn2);
            this.Controls.Add(textBox3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            msg("Client Started");
            clientSocket.Connect("127.0.0.1", 8888);
            textBox1.Text = "Client Socket Program - Server Connected ...";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkStream serverStream = clientSocket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes("Message from Client$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)clientSocket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            msg("Data from Server : " + returndata);
        }

        public void msg(string mesg)
        {
            textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + mesg;
        }

        public static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}