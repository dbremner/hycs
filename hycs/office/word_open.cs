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
            //���������
            WordApp.ActiveWindow.View.SeekView = Word.WdSeekView.wdSeekMainDocument;
        }

        public static void AddSimpleHeader(Application WordApp, string HeaderText, WdParagraphAlignment wdAlign)
        {
            WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(HeaderText);
            WordApp.Selection.Font.Color = WdColor.wdColorDarkRed;//����������ɫ
            WordApp.Selection.ParagraphFormat.Alignment = wdAlign;//���������
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        }

        public static void AddSimpleHeader(Application WordApp, string HeaderText, WdParagraphAlignment wdAlign,WdColor fontcolor,float fontsize)
        {
            WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
            WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(HeaderText);
            WordApp.Selection.Font.Color =fontcolor;//����������ɫ
            WordApp.Selection.Font.Size = fontsize;//���������С
            WordApp.Selection.ParagraphFormat.Alignment = wdAlign;//���ö��뷽ʽ
            WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument;
        }

        public static void AddSimplePic(Word.Document WordDoc, string FName,
            float Width, float Height, object An, Word.WdWrapType wdWrapType)
        {
            string FileName = @FName;//ͼƬ����·�� object
            object LinkToFile = false;
            object SaveWithDocument = true;
            object Anchor = An;
            WordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref LinkToFile, ref SaveWithDocument, ref Anchor);
            WordDoc.Application.ActiveDocument.InlineShapes[1].Width = Width;//ͼƬ���
            WordDoc.Application.ActiveDocument.InlineShapes[1].Height =  Height;//ͼƬ�߶� //��ͼƬ����Ϊ���ܻ�����
            Microsoft.Office.Interop.Word.Shape s = WordDoc.Application.ActiveDocument.InlineShapes[1].ConvertToShape();
            s.WrapFormat.Type = wdWrapType;
        }

        public static void  AddSimpleTable(Word.Application WordApp, Word.Document WordDoc, int numrows,
            int  numcolumns, Word.WdLineStyle outStyle, Word.WdLineStyle intStyle)
        {
            Object Nothing = System.Reflection.Missing.Value;
            //�ĵ��д������
            Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, numrows, numcolumns, ref  Nothing,  ref  Nothing);
            //���ñ����ʽ
            newTable.Borders.OutsideLineStyle = outStyle;
            newTable.Borders.InsideLineStyle = intStyle;
            newTable.Columns[1].Width = 100f;
            newTable.Columns[2].Width = 220f;
            newTable.Columns[3].Width = 105f;

            //���������
            newTable.Cell(1, 1).Range.Text = "��Ʒ��ϸ��Ϣ��" ;
            newTable.Cell(1, 1).Range.Bold = 2;//���õ�Ԫ��������Ϊ����
            //�ϲ���Ԫ��
            newTable.Cell(1, 1).Merge(newTable.Cell(1, 3));
            WordApp.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;//��ֱ����
            WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;//ˮƽ����

            //���������
            newTable.Cell(2, 1).Range.Text = "��Ʒ������Ϣ" ;
            newTable.Cell(2, 1).Range.Font.Color = Word.WdColor.wdColorDarkBlue;//���õ�Ԫ����������ɫ
            //�ϲ���Ԫ��
            newTable.Cell(2, 1).Merge(newTable.Cell(2, 3));
            WordApp.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

            //���������
            newTable.Cell(3, 1).Range.Text = "Ʒ�����ƣ�" ;
            newTable.Cell(3, 2).Range.Text = "Ʒ�����ƣ�" ;
            //����ϲ���Ԫ��
            newTable.Cell(3, 3).Select();//ѡ��һ��
            object  moveUnit = Word.WdUnits.wdLine;
            object  moveCount = 5;
            object  moveExtend = Word.WdMovementType.wdExtend;
            WordApp.Selection.MoveDown(ref  moveUnit,  ref  moveCount,  ref  moveExtend);
            WordApp.Selection.Cells.Merge();


            //����ͼƬ
            string  FileName = @"C:\1.jpg" ; //ͼƬ����·��
            object Anchor = WordDoc.Application.Selection.Range;
            float  Width = 200f; //ͼƬ���
            float  Height = 200f; //ͼƬ�߶�

            //��ͼƬ����Ϊ���ܻ�����
            Word.WdWrapType wdWrapType = Word.WdWrapType.wdWrapSquare;
            //AddSimplePic(WordDoc, FileName, Width, Height, Anchor, wdWrapType);

            newTable.Cell(12, 1).Range.Text = "��Ʒ��������" ;
            newTable.Cell(12, 1).Merge(newTable.Cell(12, 3));
            //�ڱ����������
            WordDoc.Content.Tables[1].Rows.Add(ref  Nothing);
        }
    }
}
