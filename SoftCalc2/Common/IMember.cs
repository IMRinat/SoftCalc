namespace SoftCalc2.Common
{
	/// <summary>
	/// Элемент в списке расчетов
	/// каждый оператор переводится в member
	/// из которых состоит memberlist
	/// </summary>
    public interface IMember
	{
		double RealNumber { get; set; }    //число в вещественном формате
		IOperator Operator { get; }        //оператор в котором хранится приоритет код для расчета
        EnumMemberType MemberType { get; set; } // тип элемента списка
	}
}