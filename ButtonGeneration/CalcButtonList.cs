using System.Collections.Generic;

namespace ButtonGeneration
{
    public static class CalcButtonList
    {
        /// <summary>
        /// Список кнопок для формы
        /// </summary>
        /// <returns></returns>
        public static IList<CalcButton> GetCalcButtonist()
        {
            /*
            Label = Надпись на кнопке
            TextForEdit =  текст который пойдет в эдит
            HotKey = Горячая клавиша
            ButtonType =  тип кнопки: обычная, пустая, переход на новую строку*/
            return new List<CalcButton>
                {
                    new CalcButton("0", "0", "0", EnumCalcButtonType.Calc),
                    new CalcButton("1", "1", "1", EnumCalcButtonType.Calc),
                    new CalcButton("2", "2", "2", EnumCalcButtonType.Calc),
                    new CalcButton(" ", " ", " ", EnumCalcButtonType.Empty),
                    new CalcButton("3", "3", "3", EnumCalcButtonType.Calc),
                    new CalcButton(" ", " ", " ", EnumCalcButtonType.NextRow),
                    new CalcButton("4", "4", "4", EnumCalcButtonType.Calc),
                    new CalcButton("5", "5", "5", EnumCalcButtonType.Calc),
                    new CalcButton("6", "6", "6", EnumCalcButtonType.Calc),
                    new CalcButton("7", "7", "7", EnumCalcButtonType.Calc),
                    new CalcButton(" ", " ", " ", EnumCalcButtonType.NextRow),
                    new CalcButton("8", "8", "8", EnumCalcButtonType.Calc),
                    new CalcButton("9", "9", "9", EnumCalcButtonType.Calc),
                    new CalcButton("+", "+", "+", EnumCalcButtonType.Calc),
                    new CalcButton("-", "-", "-", EnumCalcButtonType.Calc),
                    new CalcButton(" ", " ", " ", EnumCalcButtonType.NextRow),
                    new CalcButton("(", "(", "(", EnumCalcButtonType.Calc),
                    new CalcButton(")", ")", ")", EnumCalcButtonType.Calc),
                    new CalcButton("sin", "sin(", "ctrl+s", EnumCalcButtonType.Calc),
                };
        }
    }
}
