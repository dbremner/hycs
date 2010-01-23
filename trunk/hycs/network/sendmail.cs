using System;
using System.Windows.Forms;
using System.Net.Mail;

namespace WindowsApplication1
{
    public partial class Form1 : Form
    {
        private Button btnOK;
    
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sendmail Form";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.BackColor = Color.Red;
        
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Left = this.ClientRectangle.Width-btnOK.Width-10;
            btnOK.Top = this.ClientRectangle.Height-btnOK.Height-10;
            btnOK.Visible = true;
            btnOK.Click += new EventHandler(btnOK_Click);
            this.Controls.Add(btnOK);
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("huys03@gmail.com");
                mail.To.Add("fox000002@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("fox000002", "090200***");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }
    }
}
