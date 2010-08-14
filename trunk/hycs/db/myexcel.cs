using System;
using System.Data;
using System.Data.OleDb;
using System.Xml.Serialization;
using System.Collections;
using System.Diagnostics;

public class MyExcel {

    private OleDbConnection m_connExcel = null;
    private String m_sExcelVersion = "8.0";
    private Boolean m_fHasHeaderRow = true;
    private Boolean m_fMixRow = false;

    public Boolean Open(String dataFile)
    {
        String sConnString = null;
        Boolean fRet = false;

        if (dataFile == null || dataFile == String.Empty)
        return false;

        if (!System.IO.File.Exists(dataFile))
        return false;

        /*
        1： Excel 8.0 针对EXCEL 2000 或更高版本；Excel 5.0 FOR EXCEL 97
        2:   HDR == HEADER ROW    表示第一行是否为字段名。Yes为首行字段，No为无首行字段
        3： IMEX
                表示对同一列中有混合数据类型的列，是统一按字符型处理，
                还是将个别不同类型的值读为DBNULL。为混合，为不混合
        */
        sConnString = String.Format("Provider=Microsoft.Jet.OleDb.4.0;Data Source={0};Extended Properties='Excel {1}; HDR={2}; IMEX={3}'",
        dataFile, m_sExcelVersion, m_fHasHeaderRow ? "Yes" : "No", m_fMixRow ? 1 : 2);

        Console.WriteLine(sConnString);

        try
        {
            m_connExcel = new OleDbConnection(sConnString);
            if (m_connExcel != null)
            {
                m_connExcel.Open();
                fRet = true;
            }
        }
        catch (Exception e)
        {
            fRet = false;
            Console.WriteLine("COleDbExcelWrapper.Open: Open excel file failed! " + e.Message);
        }

        return fRet;
    }


    public ArrayList GetSheetNameList()
    {
        DataTable schemaTableView;
        ArrayList alData = null;
        DataTableReader rsResult = null;

        //'得到全部的表、视图
        schemaTableView = m_connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        if (schemaTableView != null)
        {
            rsResult = schemaTableView.CreateDataReader();
            if (rsResult != null)
            {
                alData = new ArrayList();
                if (alData != null)
                {
                    while (rsResult.Read())
                    {
                        alData.Add(rsResult.GetString(2));  // Table Name;
                    }
                }
                rsResult.Close();
                rsResult = null;
            }
            schemaTableView = null;
        }
        return alData;
    }

    public OleDbDataReader GetData(String sheetName)
    {
        OleDbCommand oCommand = null;
        OleDbDataReader rsResult = null;

        if (sheetName == null || sheetName == string.Empty)
            return null;

        if (sheetName.Substring(sheetName.Length - 1, 1) != "$")
            sheetName = sheetName + "$";

        oCommand = new OleDbCommand();
        Debug.Assert(oCommand != null);
        try
        {
            oCommand.Connection = m_connExcel;
            oCommand.CommandType = CommandType.Text;
            oCommand.CommandText = String.Format("SELECT * FROM [{0}]", sheetName);
            rsResult = oCommand.ExecuteReader(CommandBehavior.SequentialAccess);
        }
        catch (Exception e)
        {
            rsResult = null;
            Console.WriteLine("COleDbExcelWrapper.GetData: Error! " + e.Message);
        }

        oCommand = null;
        return rsResult;
    }

    public Boolean InsertData(string sql)
    {
        try
        {
            OleDbCommand myCommand = new OleDbCommand();
            myCommand.Connection = m_connExcel;
            myCommand.CommandText = sql;
            myCommand.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        return true;
    }

    public void Close()
    {
        if (m_connExcel != null)
        {
            m_connExcel.Close();
        }
    }

    public static void Main ()
    {
        MyExcel excel = new MyExcel();

        if (excel.Open("db.xls"))
        {
            ArrayList al = excel.GetSheetNameList();

            Console.WriteLine("sheet number: " + al.Count);

            Console.WriteLine("============================");
            IEnumerator etr = al.GetEnumerator();
            while (etr.MoveNext())
                Console.WriteLine(etr.Current);
            Console.WriteLine("============================");

            OleDbDataReader odr = excel.GetData("Sheet1$");
            while (odr.Read())
            {
                Console.WriteLine("{0}\t{1}\t{2}", odr.GetValue(0), odr.GetValue(1), odr.GetValue(2));
            }

            odr = excel.GetData("Sheet2$");
            Console.WriteLine("=== Origin ===");
            while (odr.Read())
            {
                Console.WriteLine("{0}\t{1}", odr.GetValue(0), odr.GetValue(1));
            }
/*
            //excel.InsertData("Delete * from [Sheet2$] where name='ema'");
            excel.InsertData("Insert into [Sheet2$] (id,name) values('5','ema')");

            odr = excel.GetData("Sheet2$");
            Console.WriteLine("=== Insert ===");
            while (odr.Read())
            {
                Console.WriteLine("{0}\t{1}", odr.GetValue(0), odr.GetValue(1));
            }

            excel.InsertData("Update [Sheet2$]  set name='Jane' where id =1");

            Console.WriteLine("=== Update ===");
            odr = excel.GetData("Sheet2$");
            while (odr.Read())
            {
                Console.WriteLine("{0}\t{1}", odr.GetValue(0), odr.GetValue(1));
            }
   */
            excel.Close();
        }

        Console.ReadKey();
    }

}
