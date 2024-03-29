using System;
using System.ComponentModel;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Drawing;

namespace WindowsApplication1
{
    public partial class ExcelForm : Form
    {
        private Button btnOK;
        private Button btnCreate;

        public ExcelForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Excel Form";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.ControlBox = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = Color.Red;

            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Left = this.ClientRectangle.Width-btnOK.Width-10;
            btnOK.Top = this.ClientRectangle.Height-btnOK.Height-10;
            btnOK.Visible = true;
            btnOK.Click += new EventHandler(btnOK_Click);
            this.Controls.Add(btnOK);

            btnCreate = new Button();
            btnCreate.Text = "Create";
            btnCreate.Left = this.ClientRectangle.Width - btnOK.Width - 150;
            btnCreate.Top = this.ClientRectangle.Height - btnOK.Height - 10;
            btnCreate.Visible = true;
            btnCreate.Click += new EventHandler(btnCreate_Click);
            this.Controls.Add(btnCreate);
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Excel.Application xlApp ;
            Excel.Workbook xlWorkBook ;
            Excel.Worksheet xlWorkSheet ;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.ApplicationClass();
            xlWorkBook = xlApp.Workbooks.Add(misValue);

            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "id";
            xlWorkSheet.Cells[1, 2] = "name";

            xlWorkBook.SaveAs("csharp.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file csharp.xls");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new ExcelForm());
        }
    }
}
