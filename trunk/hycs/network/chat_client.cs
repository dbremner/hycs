using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets ;
using System.Threading;

namespace WindowsApplication2
{
    public partial class Form1 : Form
    {
        TcpClient clientSocket = new TcpClient();
        NetworkStream serverStream = default(NetworkStream);
        string readData = null;

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
            btn2.Click += new EventHandler(button2_Click);

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

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox2.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            readData = "Conected to Chat Server ...";
            msg();
            clientSocket.Connect("127.0.0.1", 8888);
            serverStream = clientSocket.GetStream();

            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(textBox3.Text + "$");
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            Thread ctThread = new Thread(getMessage);
            ctThread.Start();
        }

        private void getMessage()
        {
            while (true)
            {
                serverStream = clientSocket.GetStream();
                int buffSize = 0;
                byte[] inStream = new byte[10025];
                buffSize = clientSocket.ReceiveBufferSize;
                serverStream.Read(inStream, 0, buffSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);
                readData = "" + returndata;
                msg();
            }
        }

        private void msg()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(msg));
            else
                textBox1.Text = textBox1.Text + Environment.NewLine + " >> " + readData;
        } 

        public static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}
