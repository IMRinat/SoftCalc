using System;
using SoftCalc2.Common;

namespace SoftCalc2.Core
{
	/// <summary>
	/// Элемент списка memberlist в который помещается оператор
	/// </summary>
    internal class Member:IMember
	{

        public double RealNumber { get; set; }   // результат вычислений как вещественное десятичное число
        public IOperator Operator { get; private set; } // оператор вычисления
        public EnumMemberType MemberType { get; set; }  // тип элемента например исходный, посчитанный

	    /// <summary>
	    /// конструктор принимает оператор 
	    /// результат вычислений сбарсывает в ноль
	    /// устанавливает тип - исходный
	    /// </summary>
	    /// <param name="operator1"></param>
        public Member(IOperator operator1)
	    {
	        if (operator1 == null)
	        {
	            throw new ArgumentNullException("operator1");
	        }
	        Operator = operator1;
	        RealNumber = 0; //здесь содержатся результаты расчетов
            MemberType = EnumMemberType.Clear;
	    }
	}
}
