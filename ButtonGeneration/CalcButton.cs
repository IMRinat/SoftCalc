using System;

namespace ButtonGeneration
{
    /// <summary>
    /// класс который опписывает кнопку на форме калькулятора
    /// </summary>
    public class CalcButton
    {

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="label">Текст на кнопке</param>
        /// <param name="textForEdit">Текст который пойдет в эдит</param>
        /// <param name="hotKey">горячая клваиша</param>
        /// <param name="buttonType">Тип кнопки: обычная, пустая, переход строки</param>
        public CalcButton(string label, string textForEdit, string hotKey, EnumCalcButtonType buttonType)
		{
            Label = label;
            TextForEdit = textForEdit;
            HotKey = hotKey;
            ButtonType = buttonType;
		}

        public string Label { get; private set; }
        public string TextForEdit { get; private set; }
        public string HotKey { get; private set; }
        public EnumCalcButtonType ButtonType { get; private set; }
    }
}
