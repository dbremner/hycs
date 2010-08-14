using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Excel.Application m_objExcel = null;
            Excel._Workbook m_objBook = null;
            Excel.Sheets m_objSheets = null;
            Excel._Worksheet m_objSheet = null;
            Excel.Range m_objRange = null;
            object m_objOpt = System.Reflection.Missing.Value;

            try
            {
                m_objExcel = new Excel.Application();
                m_objBook = m_objExcel.Workbooks.Open("Book1.xls",
                    m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, 
                    m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, 
                    m_objOpt, m_objOpt);
                m_objSheets = (Excel.Sheets)m_objBook.Worksheets;
                m_objSheet = (Excel._Worksheet)(m_objSheets.get_Item(1));
                string[] info = new string[5] { "编号", "名字", "性别", "时间", "迟到与否" };
                m_objRange = m_objSheet.get_Range("A1", m_objOpt);
                m_objRange.set_Value(m_objOpt, info[0]);
                m_objRange = m_objSheet.get_Range("B1", m_objOpt);
                m_objRange.set_Value(m_objOpt, info[1]);
                m_objRange = m_objSheet.get_Range("C1", m_objOpt);
                m_objRange.set_Value(m_objOpt, info[2]);
                m_objRange = m_objSheet.get_Range("D1", m_objOpt);
                m_objRange.set_Value(m_objOpt, info[3]);
                m_objRange = m_objSheet.get_Range("E1", m_objOpt);
                m_objRange.set_Value(m_objOpt, info[4]);
                m_objExcel.DisplayAlerts = false;
                m_objBook.SaveAs("Book2.xls", 
                    m_objOpt, m_objOpt,
                    m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange,
                    m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                m_objBook.Close(m_objOpt, m_objOpt, m_objOpt);
                m_objExcel.Workbooks.Close();
                m_objExcel.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objBook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(m_objExcel);
                m_objBook = null;
                m_objExcel = null;
                GC.Collect();
            }
        }
    }
}
