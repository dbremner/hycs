using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;

class HelloGDIPlus : Form
{
    private System.ComponentModel.Container components = null;

    public HelloGDIPlus()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(408, 273);
        this.Name = "GDICooridinate";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "GDI+ Coordinate";
        this.Resize += new System.EventHandler(this.OnResize);
        this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);

    }
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    protected void OnPaint(object sender, PaintEventArgs e)
    {
        GraphicsUnit gUnit = GraphicsUnit.Pixel;

        Point renderingOrgPt = new Point(0, 0);
        renderingOrgPt.X = 100;
        renderingOrgPt.Y = 100;

        Graphics g = e.Graphics;

        g.PageUnit = gUnit;

        g.TranslateTransform(renderingOrgPt.X, renderingOrgPt.Y);
        g.DrawRectangle(new Pen(Color.Red, 1), 0, 0, 100, 100);

        this.Text = string.Format("PageUnit: {0}, Origin: {1}", gUnit, renderingOrgPt.ToString());
    }

    protected void OnResize(object sender, System.EventArgs e)
    {
        Invalidate();
    }

    [STAThread]
    static void Main()
    {
        Application.Run(new HelloGDIPlus());
    }
}
