using System;
using System.Windows.Forms;

public class MyForm : Form {

    void btn1_onclick(object sender, EventArgs e)
    {
        Text = "Sender: " + sender.ToString() + " - Event: " + e.ToString();
    }

    void btn1_onclick2(object sender, EventArgs e){
        Console.WriteLine(String.Format("Sender: {0} - Event: {1}", sender.ToString(), e.ToString()));
    }

    public MyForm() {
        Text = "Hello World";

        Button btn1 = new Button();
        btn1.Text = "Click Me";
        this.Controls.Add(btn1);

        btn1.Click += new EventHandler(btn1_onclick);
        btn1.Click += new EventHandler(btn1_onclick2);
    }

    public static void Main()
    {
        Application.Run(new MyForm());
    }

}

