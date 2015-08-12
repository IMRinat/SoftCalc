using System;

namespace SoftCalc2.Common
{
	/// <summary>
	/// Описание оператора вычисления
	/// числа это тоже операторы
	/// </summary>
    public interface IOperator
	{
		string OperatorText { get; }                // Текст оператора, например + - sin 8  и т.д.
        int OperatorPriority { get; }               // Приоритет выполнения оператора, чем меньше тем выше
		EnumOperatorType OperatorType { get; }      // Тип оператора, константа, число, бинарная операция и т.д.
		Action<int, IContext> CalcOperator { get; } // Метод который обсчитывает это топератор
	}
}