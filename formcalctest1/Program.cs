using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using ClassFormCalcBind;

namespace formcalctest1
{
    static class Program
    {
        private static void NewPanel(object form,string name, int l, int t, int w,int h)
        {
            var form1 = (Form1) form;
            var pan = new Panel
                {
                    Name = name,
                    Location = new System.Drawing.Point(l, t),
                    Size = new System.Drawing.Size(w,h),
                    BackColor = System.Drawing.SystemColors.ActiveCaption
                };
            form1.Controls.Add(pan);
        }

        private static void NewButton(Form1 form,ClassWinBind classWinBind, string panelname, string name, string tex, int l, int t)
        {
            var form1 = (Form1) form;
            var newbutton = new Button
            {
                Location = new System.Drawing.Point(l,t),
                Size = new System.Drawing.Size(40, 30),
                Name = name,
                Text = tex,
                UseVisualStyleBackColor = true
            };
            newbutton.Click += classWinBind.ButtonClick;

            var panel = form1.Controls.Find(panelname, true).FirstOrDefault() as Panel;
            Debug.Assert(panel != null, "panel != null");
            panel.Controls.Add(newbutton);    
        }


        private static void NewTextbox(object form, ClassWinBind classWinBind, string panelname, string name)
        {
            var form1 = (Form1) form;
            var newtextBox = new TextBox
            {
                Location = new System.Drawing.Point(186, 4),
                Size = new System.Drawing.Size(100, 20),
                Name = name,
                Text = ""
            };

            //делаем биндинг
            newtextBox.DataBindings.Add(new Binding("Text", classWinBind, "Pole"));

            var panel = form1.Controls.Find(panelname, true).FirstOrDefault() as Panel;
            Debug.Assert(panel != null, "panel != null");
            panel.Controls.Add(newtextBox);
        }


        private static void GenerateElements(object form, ClassWinBind classWinBind)
        {
            var form1 = (Form1) form;
            form1.KeyPreview = true;
            form1.KeyDown += classWinBind.MainForm_KeyDown;
            NewPanel(form1, "panel_6", 10,  10, 280, 25);  // тут системы счисления
            NewPanel(form1, "panel_1", 300, 10, 400, 25);  // тут текстовое поле
            NewPanel(form1, "panel_5", 10,  40, 280, 140); // тут расширенные фнукции
            NewPanel(form1, "panel_2", 300, 40, 280, 140); // тут цифры
            NewPanel(form1, "panel_4", 590, 40, 50,  140); // тут простые функции
            NewPanel(form1, "panel_3", 650, 40, 50,  140); // тут спец функции

            NewButton(form1, classWinBind, "panel_5", "bcalc1", "but1", 2, 2);
            NewButton(form1, classWinBind, "panel_5", "bcalc2", "but2", 44, 2);
            NewTextbox(form1, classWinBind, "panel_1", "newtextbox1");


            
            //CalcButtonRender.RenderWinForm(Panel(form1.Controls.Find("panel_3", false)[0]), form1.textBox1);

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
            var classWinBind = new ClassWinBind();
            GenerateElements(form1, classWinBind);
            Application.Run(form1);
        }
    }
}
