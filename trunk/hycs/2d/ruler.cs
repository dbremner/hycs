using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

class PrintableForm : Form
{
    //public static void Main()
    //{
    //    Application.Run(new PrintableForm());
    //}   

    public PrintableForm()
    {
        this.Text = "Printable Form";
        this.BackColor = SystemColors.Window;
        this.ForeColor = SystemColors.WindowText;
        this.ResizeRedraw = true;
    }
    
    protected override void OnPaint(PaintEventArgs pea)
    {
        DoPage(pea.Graphics, ForeColor, ClientSize.Width, ClientSize.Height);
    }
    
    protected override void OnClick(EventArgs ea)
    {
        PrintDocument prndoc = new PrintDocument();
        prndoc.DocumentName = Text;
        prndoc.PrintPage += new PrintPageEventHandler(PrintDocumentOnPrintPage);
        prndoc.Print();
    }

    void PrintDocumentOnPrintPage(object obj, PrintPageEventArgs ppea)
    {
        Graphics grfx = ppea.Graphics;
        SizeF sizef = grfx.VisibleClipBounds.Size;
        
        DoPage(grfx, Color.Black, (int)sizef.Width, (int)sizef.Height);
    }
    
    protected virtual void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {

    }
} 

class Ruler : PrintableForm
{
    public static void Main()
    {
        Application.Run(new Ruler());
    }
    
    public Ruler()
    {
        this.Text = "Ruler";
        this.ClientSize = new Size(480, 320);
    }
    
    protected override void DoPage(Graphics grfx, Color clr, int cx, int cy)
    {
        Pen pen = new Pen(clr);
        Brush brush = new SolidBrush(clr);
        const int xOffset = 10;
        const int yOffset = 10;
        
        grfx.DrawPolygon(pen, new PointF[]
            {
                MMConv(grfx, new PointF(xOffset, yOffset)),
                MMConv(grfx, new PointF(xOffset+100, yOffset)),
                MMConv(grfx, new PointF(xOffset+100, yOffset+10)),
                MMConv(grfx, new PointF(xOffset, yOffset+10))  
            });
        StringFormat strfmt = new StringFormat();
        strfmt.Alignment = StringAlignment.Center;
        
        for (int i=1; i<100; i++)
        {
            if (i%10 == 0)
            {
                grfx.DrawLine(pen,
                    MMConv(grfx, new PointF(xOffset+i, yOffset)),
                    MMConv(grfx, new PointF(xOffset+i, yOffset+5)));
                    
                grfx.DrawString((i/10).ToString(), Font, brush,
                    MMConv(grfx, new PointF(xOffset+i, yOffset+5)),
                    strfmt);
            }
            else if (i%5 == 0)
            {
                grfx.DrawLine(pen,
                    MMConv(grfx, new PointF(xOffset+i, yOffset)),
                    MMConv(grfx, new PointF(xOffset+i, yOffset+3)));  
            }
            else
            {
                grfx.DrawLine(pen,
                    MMConv(grfx, new PointF(xOffset+i, yOffset)),
                    MMConv(grfx, new PointF(xOffset+i, yOffset+2.5f)));
            }
        
        }
    }
    
    PointF MMConv(Graphics grfx, PointF pointf)
    {
        pointf.X *= grfx.DpiX / 25.4f;
        pointf.Y *= grfx.DpiY / 25.4f;
        
        return pointf;
    }
}