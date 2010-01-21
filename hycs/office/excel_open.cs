using System;
using Excel = Microsoft.Office.Interop.Excel;
//using System.Runtime.InteropServices;

class MainClass
{
    [STAThread]
    static void Main(string[] args)
    {
        Excel.Application app = new Excel.ApplicationClass();
        app.Visible = true;
        app.Workbooks.Add( System.Type.Missing );

        app.ActiveCell.set_Value( Excel.XlRangeValueDataType.xlRangeValueDefault, "Hello excel" );
    }
}
