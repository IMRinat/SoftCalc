namespace SoftCalc2.Common
{
	/// <summary>
	/// Тип оператора
	/// это может быть
	/// Унарная, бинарная, тернарная операции
	/// пробел, цифра, константа, скобка
	/// </summary>
    public enum EnumOperatorType
	{
		Unar,    // унарный оператор
		Binar,   // бинарный оператор
		Ternar,  // тернарный оператор
		Space,   // пробел
		Number,  // число
		Const,   // Константа
        Dot,     // точка дробный резделитель
        OpenBracket, // открывающая скобка
        CloseBracket // закрывающая скобка
	}
}