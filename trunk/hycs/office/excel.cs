using System;
using System.Runtime.InteropServices;

class MainClass
{
  [STAThread]
  static void Main(string[] args)
  {
    Excel.Application app = new Excel.ApplicationClass();
    app.Visible = true;
    app.Workbooks.Add( VarEnum.VT_NULL );
    app.ActiveCell.set_Value( Excel.XlRangeValueDataType.xlRangeValueDefault, "Hello excel" );
  }
}
