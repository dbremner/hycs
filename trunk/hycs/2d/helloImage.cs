using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

public class HelloImage : Form
{
    HelloImage()
    {
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(430, 400);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Name = "HelloImage";
        this.Text = "HelloImage";
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Bitmap bmp = new Bitmap("back.jpg");
        Rectangle r = new Rectangle(0, 0, bmp.Width, bmp.Height);
        g.DrawImage(bmp, r, r, GraphicsUnit.Pixel);
    }

    public static void Main()
    {
        Application.Run(new HelloImage());
    }
}
