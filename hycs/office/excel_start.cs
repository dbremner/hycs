using System;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ConsoleApplication
{
    class Program
    {
        static bool exit = false;

        static void Main(string[] args)
        {
            Excel.Application myExcelApp = new Excel.Application();
            myExcelApp.Visible = true;
            myExcelApp.StatusBar = "Hello World";
            myExcelApp.Workbooks.Add(System.Type.Missing);

            myExcelApp.SheetBeforeDoubleClick +=
              new Excel.AppEvents_SheetBeforeDoubleClickEventHandler(myExcelApp_SheetBeforeDoubleClick);

            while (exit == false)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        static void myExcelApp_SheetBeforeDoubleClick(object Sh, Excel.Range Target, ref bool Cancel)
        {
            exit = true;
        }
    }
}
