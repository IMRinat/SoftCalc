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
                    new CalcButton("ID_0","0", "0", "0", EnumCalcButtonType.Digit),
                    new CalcButton("ID_1","1", "1", "1", EnumCalcButtonType.Digit),
                    new CalcButton("ID_2","2", "2", "2", EnumCalcButtonType.Digit),
                    new CalcButton("ID_e1"," ", " ", " ", EnumCalcButtonType.Empty),
                    new CalcButton("ID_3","3", "3", "3", EnumCalcButtonType.Digit),
                    new CalcButton("ID_e2"," ", " ", " ", EnumCalcButtonType.NextRow),
                    new CalcButton("ID_4","4", "4", "4", EnumCalcButtonType.Digit),
                    new CalcButton("ID_5","5", "5", "5", EnumCalcButtonType.Digit),
                    new CalcButton("ID_6","6", "6", "6", EnumCalcButtonType.Digit),
                    new CalcButton("ID_7","7", "7", "7", EnumCalcButtonType.Digit),
                    new CalcButton("ID_e3"," ", " ", " ", EnumCalcButtonType.NextRow),
                    new CalcButton("ID_8","8", "8", "8", EnumCalcButtonType.Digit),
                    new CalcButton("ID_9","9", "9", "9", EnumCalcButtonType.Digit),
                    new CalcButton("ID_plus","+", "+", "+", EnumCalcButtonType.Binar),
                    new CalcButton("ID_minus","-", "-", "-", EnumCalcButtonType.Binar),
                    new CalcButton("ID_e4"," ", " ", " ", EnumCalcButtonType.NextRow),
                    new CalcButton("ID_obr","(", "(", "(", EnumCalcButtonType.Bracket),
                    new CalcButton("ID_cbr",")", ")", ")", EnumCalcButtonType.Bracket),
                    new CalcButton("ID_sin","sin", "sin(", "ctrl+s", EnumCalcButtonType.Unar),
                };
        }
    }
}
