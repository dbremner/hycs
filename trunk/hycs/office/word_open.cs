using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;

namespace WordMan
{
    class Program
    {
        static void Main(string[] args)
        {
            object omissing = System.Reflection.Missing.Value;
            Word.Application oword;
            Word.Document odoc;

            oword = new Word.Application();
            oword.Visible = true;

            odoc = oword.Documents.Add(ref omissing, ref omissing, ref omissing, ref omissing);

            AddSimpleHeader(oword, "Hello From C#", WdParagraphAlignment.wdAlignParagraphCenter);

            //AddSimpleTable

        }

        public static void AddSimpleHeader(Word.Application WordApp, string HeaderText)
        {
            WordApp.ActiveWindow.View.Type = Word.WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekPrimaryHeader;
            WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(HeaderText);
            WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
            //设置左对齐
            WordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
        }

        public static void AddSimpleHeader(Application WordApp, string HeaderText, WdParagraphAlignment wdAlign)
        {
            WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(HeaderText);
            WordApp.Selection.Font.Color = WdColor.wdColorDarkRed;//设置字体颜色
            WordApp.Selection.ParagraphFormat.Alignment = wdAlign;//设置左对齐
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        }

        public static void AddSimpleHeader(Application WordApp, string HeaderText, WdParagraphAlignment wdAlign,WdColor fontcolor,float fontsize)
        {
            WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(HeaderText);
            WordApp.Selection.Font.Color =fontcolor;//设置字体颜色
            WordApp.Selection.Font.Size = fontsize;//设置字体大小
            WordApp.Selection.ParagraphFormat.Alignment = wdAlign;//设置对齐方式
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        }

        public static void AddSimplePic(Word.Document WordDoc, string FName,
            float Width, float Height, object An, Word.WdWrapType wdWrapType)
        {
            string FileName = @FName;//图片所在路径 object
            object LinkToFile = false;
            object SaveWithDocument = true;
            object Anchor = An;
            WordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
            WordDoc.Application.ActiveDocument.InlineShapes[1].Width = Width;//图片宽度
            WordDoc.Application.ActiveDocument.InlineShapes[1].Height =  Height;//图片高度 //将图片设置为四周环绕型
            Microsoft.Office.Interop.Word.Shape s = WordDoc.Application.ActiveDocument.InlineShapes[1].ConvertToShape();
            s.WrapFormat.Type = wdWrapType;
        }

        public static void  AddSimpleTable(Word.Application WordApp, Word.Document WordDoc, int numrows,
            int  numcolumns, Word.WdLineStyle outStyle, Word.WdLineStyle intStyle)
        {
            Object Nothing = System.Reflection.Missing.Value;
            //文档中创建表格
            Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, numrows, numcolumns, ref  Nothing,  ref  Nothing);
            //设置表格样式
            newTable.Borders.OutsideLineStyle = outStyle;
            newTable.Borders.InsideLineStyle = intStyle;
            newTable.Columns[1].Width = 100f;
            newTable.Columns[2].Width = 220f;
            newTable.Columns[3].Width = 105f;

            //填充表格内容
            newTable.Cell(1, 1).Range.Text = "产品详细信息表" ;
            newTable.Cell(1, 1).Range.Bold = 2;//设置单元格中字体为粗体
            //合并单元格
            newTable.Cell(1, 1).Merge(newTable.Cell(1, 3));
            WordApp.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//垂直居中
            WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//水平居中

            //填充表格内容
            newTable.Cell(2, 1).Range.Text = "产品基本信息" ;
            newTable.Cell(2, 1).Range.Font.Color = Word.WdColor.wdColorDarkBlue;//设置单元格内字体颜色
            //合并单元格
            newTable.Cell(2, 1).Merge(newTable.Cell(2, 3));
            WordApp.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            //填充表格内容
            newTable.Cell(3, 1).Range.Text = "品牌名称：" ;
            newTable.Cell(3, 2).Range.Text = "品牌名称：" ;
            //纵向合并单元格
            newTable.Cell(3, 3).Select();//选中一行
            object  moveUnit = Word.WdUnits.wdLine;
            object  moveCount = 5;
            object  moveExtend = Word.WdMovementType.wdExtend;
            WordApp.Selection.MoveDown(ref  moveUnit,  ref  moveCount,  ref  moveExtend);
            WordApp.Selection.Cells.Merge();


            //插入图片
            string  FileName = @"C:\1.jpg" ; //图片所在路径
            object Anchor = WordDoc.Application.Selection.Range;
            float  Width = 200f; //图片宽度
            float  Height = 200f; //图片高度

            //将图片设置为四周环绕型
            Word.WdWrapType wdWrapType = Word.WdWrapType.wdWrapSquare;
            //AddSimplePic(WordDoc, FileName, Width, Height, Anchor, wdWrapType);

            newTable.Cell(12, 1).Range.Text = "产品特殊属性" ;
            newTable.Cell(12, 1).Merge(newTable.Cell(12, 3));
            //在表格中增加行
            WordDoc.Content.Tables[1].Rows.Add(ref  Nothing);
        }
    }
}
