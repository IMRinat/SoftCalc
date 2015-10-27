using System;
using System.Windows.Forms;
using ButtonGeneration;
using SoftCalc2.Core;
using SoftCalc2.Default;

namespace formcalctest1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            textBox2.Text = act.Calc(textBox1.Text,10);
            //textBox2.Text = act.Calc("2*{2+2}", 10);
            //textBox2.Text = act.Calc("10.001", 2);
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

       
    }
}
