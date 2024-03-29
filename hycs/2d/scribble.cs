using System;
using System.Drawing;
using System.Windows.Forms;

class Scribble : Form
{
    bool bTracking;
    Point ptLast;
    
    public static void Main()
    {
        Application.Run(new Scribble());
    }
    
    public Scribble()
    {
        this.Text = "Scribble";
        this.BackColor = SystemColors.Window;
        this.ForeColor = SystemColors.WindowText;
    }
    
    protected override void OnMouseDown(MouseEventArgs mea)
    {
        if (mea.Button != MouseButtons.Left)
            return;
        
        ptLast = new Point(mea.X, mea.Y);
        bTracking = true;
    }
    
    protected override void OnMouseMove(MouseEventArgs mea)
    {
        if (!bTracking)
            return;
            
        Point ptNew = new Point(mea.X, mea.Y);
        
        Graphics grfx = CreateGraphics();
        grfx.DrawLine(new Pen(ForeColor), ptLast, ptNew);
        grfx.Dispose();
        
        ptLast = ptNew;
    }
    
    protected override void OnMouseUp(MouseEventArgs mea)
    {
        bTracking = false;
    }
}
