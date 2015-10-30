using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace ButtonGeneration
{
    public class BorderButtonCoord
    {
        public int W, H, B, T, L; //width,height,border,top,left
        public int Row = 0;
        public int Col = 0;

        public BorderButtonCoord(int w1, int h1, int b1) // 40 20 3
        {
            W = w1;
            H = h1;
            B = b1;
        }

        public void Inc(EnumCalcButtonType typ)
        {
            if (typ == EnumCalcButtonType.Empty)
            {
                Col++;
            }
            else if (typ == EnumCalcButtonType.NextRow)
            {
                Row++;
                Col = 0;
            }
            else
            {
                L = Col*(W + B);
                T = Row*(H + B);
                Col++;
            }
        }
    }

    public static class CalcButtonRender
    {

        //private static IList<CalcButton> _calcButtonList;


        private static void button1_Click(object sender, EventArgs e)
        {
            /*var tmpButton = _calcButtonList.FirstOrDefault(button => button.Label == ((Button)sender).Text);

            if (tmpButton != null)
            {
             //   _statTextBox.Text = _statTextBox.Text + tmpButton.TextForEdit;
            }
            */
        }



        public static void RenderWinForm(Panel panel,IList<CalcButton> calcButtonList)
        {
            var coord = new BorderButtonCoord(40, 20, 3);

            foreach (var calcButton in calcButtonList)
            {
                if (((calcButton.ButtonType != EnumCalcButtonType.Empty))&&(calcButton.ButtonType != EnumCalcButtonType.NextRow))
                {
                    var newbutton = new Button
                        {
                            Location = new System.Drawing.Point(coord.L, coord.T),
                            Size = new System.Drawing.Size(coord.W, coord.H),
                            Name = calcButton.ID,
                            Text = calcButton.Label,
                            UseVisualStyleBackColor = true
                        };
                    newbutton.Click += button1_Click;
                    panel.Controls.Add(newbutton);
                }
                coord.Inc(calcButton.ButtonType);
            }
        }
    }
}