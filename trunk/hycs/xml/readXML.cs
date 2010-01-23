using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
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
            XmlDataDocument xmldoc = new XmlDataDocument();
            XmlNodeList xmlnode ;
            int i = 0;
            string str = null;
            FileStream fs = new FileStream("product.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName("Product");
            for (i = 0; i <= xmlnode.Count - 1; i++)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                str = xmlnode[i].ChildNodes.Item(0).InnerText.Trim() + " | " + xmlnode[i].ChildNodes.Item(1).InnerText.Trim() + " | " + xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                MessageBox.Show (str);
            }
        }
    }
}