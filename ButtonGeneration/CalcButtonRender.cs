using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace ButtonGeneration
{
    public static class CalcButtonRender
    {

        private static TextBox _statTextBox;
        private static IList<CalcButton> _calcButtonList;


        private static void button1_Click(object sender, EventArgs e)
        {
            var tmpButton = _calcButtonList.FirstOrDefault(button => button.Label == ((Button)sender).Text);

            if (tmpButton != null)
            {
                _statTextBox.Text = _statTextBox.Text + tmpButton.TextForEdit;
            }
        }



        public static void RenderWinForm(Panel panel, TextBox textBox)
        {
            _calcButtonList = CalcButtonList.GetCalcButtonist();
            _statTextBox = textBox;

            var row = 0;
            var col = 0;
            var index = 0;
            const int w = 40; //width
            const int h = 20; //height
            const int b = 3; // border
            foreach (var calcButton in _calcButtonList)
            {
                index++;
                if (calcButton.ButtonType == EnumCalcButtonType.Empty)
                {
                    col++;
                }
                if (calcButton.ButtonType == EnumCalcButtonType.NextRow)
                {
                    row++;
                    col = 0;
                }
                if (calcButton.ButtonType == EnumCalcButtonType.Calc)
                {
                    var newbutton = new Button();

                    panel.Controls.Add(newbutton);

                    newbutton.Location = new System.Drawing.Point (col*(w+b),row*(h+b));
                    newbutton.Name = "buttonCalc" + index.ToString(CultureInfo.InvariantCulture);
                    newbutton.Size = new System.Drawing.Size(w, h);
                    newbutton.TabIndex = 0;
                    newbutton.Text = calcButton.Label;
                    newbutton.UseVisualStyleBackColor = true;
                    newbutton.Click += button1_Click;

                    col++;
                }
            }
        }
    }
}