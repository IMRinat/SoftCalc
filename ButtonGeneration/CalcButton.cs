using System;

namespace ButtonGeneration
{
    /// <summary>
    /// класс который описывает кнопку на форме калькулятора
    /// </summary>
    public class CalcButton
    {
        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="id">Идентифкатор кнопки</param>
        /// <param name="label">Текст на кнопке</param>
        /// <param name="textForEdit">Текст который пойдет в эдит</param>
        /// <param name="hotKey">горячая клавиша</param>
        /// <param name="buttonType">Тип кнопки: обычная, пустая, переход строки</param>
        public CalcButton(string id, string label, string textForEdit, string hotKey, EnumCalcButtonType buttonType)
        {
            ID = id;
            Label = label;
            TextForEdit = textForEdit;
            HotKey = hotKey;
            ButtonType = buttonType;
		}

        public string ID { get; private set; }
        public string Label { get; private set; }
        public string TextForEdit { get; private set; }
        public string HotKey { get; private set; }
        public EnumCalcButtonType ButtonType { get; private set; }
    }
}
