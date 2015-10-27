using System;
using System.Windows.Forms;
using ButtonGeneration;

namespace formcalctest1
{
    static class Program
    {
        private static void NewPanel(Form1 form1,string name, int l, int t, int w,int h)
        {
            var pan = new Panel
                {
                    Name = name,
                    Location = new System.Drawing.Point(l, t),
                    Size = new System.Drawing.Size(w,h),
                    BackColor = System.Drawing.SystemColors.ActiveCaption
                };
            form1.Controls.Add(pan);
        }

        private static void GenerateElements(Form1 form1)
        {
            NewPanel(form1, "panel_6", 10,  10, 280, 25);
            NewPanel(form1, "panel_1", 300, 10, 400, 25);
            NewPanel(form1, "panel_5", 10,  40, 280, 140);
            NewPanel(form1, "panel_2", 300, 40, 280, 140);
            NewPanel(form1, "panel_4", 590, 40, 50,  140);
            NewPanel(form1, "panel_3", 650, 40, 50,  140);

            //CalcButtonRender.RenderWinForm(form1.panel1, form1.textBox1);
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var form1 = new Form1();
            GenerateElements(form1);
            Application.Run(form1);
        }
    }
}
