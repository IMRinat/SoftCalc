using System;
using System.Collections.Generic;

namespace SoftCalc2.Common
{
	/// <summary>
	/// Контекст содержит 
	/// 1.Список всех элементов расчета
	/// 2.метод расчета всех элементов
	/// 3.систему счисления
	/// 4.метод расчета контекста.
	/// 5. метод возвращающий новый экземпляр контекста
	/// </summary>
    public interface IContext
	{
		IList<IMember> MemberList { get; }
        Action<IContext> CalcMemberList { get; }
        int Basesystem { get; }
        void CalcContext(IList<IMember> memberList, int basesystem, Action<IContext> calcMemberList);
	    IContext NewContextObject();
	}
}