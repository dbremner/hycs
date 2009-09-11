using System;
using System.Windows.Forms;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;

class HelloDXForm : Form
{
    private Device m_device = null;

    public HelloDXForm()
    {
        this.Text = "Managed DirectX";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.ControlBox = true;
        this.MaximizeBox = false;
        this.MinimizeBox = false;

        this.Load += new EventHandler(Form_Load);
    }

    void InitGraphics()
    {
       PresentParameters present_params = new PresentParameters();

       present_params.Windowed = true;
       present_params.SwapEffect = SwapEffect.Discard;


       m_device = new Device(0, DeviceType.Hardware, this,
            CreateFlags.SoftwareVertexProcessing, present_params);
    }

    private void Form_Load(object sender, EventArgs e)
    {
        this.Opacity = 0.50;
    }

    public static void Main()
    {
        HelloDXForm MainForm = new HelloDXForm();
        MainForm.InitGraphics();
        Application.Run(MainForm);
    }
}
