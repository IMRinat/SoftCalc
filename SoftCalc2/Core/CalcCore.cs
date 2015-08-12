using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SoftCalc2.Common;

namespace SoftCalc2.Core
{
	public class CalcCore
	{
		/// <summary>
		/// Спиок всех операторов
		/// </summary>
        private readonly IOperator[] _operatorList;
		
		/// <summary>
		/// Конструктор
		/// </summary>
		/// <param name="operatorList">Список операторов с методами их расчета</param>
        public CalcCore(IOperator[] operatorList)
		{
			if (operatorList == null)
			{
				throw new ArgumentNullException("operatorList");
			}
			_operatorList = operatorList;
		}

		/// <summary>
		/// Вычисление индекс следующего оператора для расчета
		/// </summary>
		/// <returns>индекс элемента в списке</returns>
		private int GetIndexNextOperator(IList<IMember> memberList)
		{
			//ищем оператор с  минимальным приоритетом
            var mn = 999999;
			var ind = -1;
			for (var index = 0; index < memberList.Count; index++)
			{
				var member = memberList[index];
			    if ((member.Operator.OperatorPriority > 0) && (member.Operator.OperatorPriority < mn) &&
			        (member.MemberType != EnumMemberType.Calc))
			    {
			        mn = member.Operator.OperatorPriority;
			        ind = index;
			    }
			}

            //перемещаемся слева направо по унарным операторам
            while ((ind>=0)&&(ind < memberList.Count - 1) &&
                   (memberList[ind].Operator.OperatorType == EnumOperatorType.Unar) &&
                   (memberList[ind+1].Operator.OperatorType == EnumOperatorType.Unar)) { ind++; }


			return ind;
		}

	    /// <summary>
        /// Прототип метода для расчета списка элементов memberList.
        /// </summary>
        /// <param name="context">контекст, который содержит список элементов</param>
        private void CalcBaseListProto( IContext context)
	    {
            while (GetIndexNextOperator(context.MemberList)>=0)
            {
                var i = GetIndexNextOperator(context.MemberList);
                //Вызываем метод вычисления оператора
                context.MemberList[i].Operator.CalcOperator(i, context);
            }
	    }

	    /// <summary>
        /// Метод для определения и исправления операторов. 
        /// исправление путаницы бинарных  и унарных
        /// </summary>
        /// <param name="members">Список элементов расчета</param>
        private void UnarBinarCorrect(IList<IMember> members)
        {
            for (var i = 0; i < members.Count; i++)
            {
                //оператор является унарным либо бинарным. такие и будем проверять
                if ((members[i].Operator.OperatorType != EnumOperatorType.Binar) &&
                    (members[i].Operator.OperatorType != EnumOperatorType.Unar)) continue;

                //находим унарный и бинарный оператор для такого текста
                var unarOperator = _operatorList.FirstOrDefault(oper => ((oper.OperatorText == members[i].Operator.OperatorText) && (oper.OperatorType == EnumOperatorType.Unar)));
                var binarOperator = _operatorList.FirstOrDefault(oper => ((oper.OperatorText == members[i].Operator.OperatorText) && (oper.OperatorType == EnumOperatorType.Binar)));
                //если не нашли такие операторы,то ничего не делаем
                if ((unarOperator == null) || (binarOperator == null)) continue;

                //если оператор вообще первый то это унарный
                if (i == 0) members[i] = new Member(unarOperator);
                //если перед оператором закр скобка или цифра, то это бинарный, остальное унарный
                if (i > 0)
                {
                    if (members[i - 1].Operator.OperatorType == EnumOperatorType.Number)
                        members[i] = new Member(binarOperator);
                    else if (members[i - 1].Operator.OperatorType == EnumOperatorType.CloseBracket)
                        members[i] = new Member(binarOperator);
                    else members[i] = new Member(unarOperator);
                }
            }
        }

	    /// <summary>
	    /// calc string
	    /// </summary>
	    /// <param name="formula">содержит текст для вычисления "60/-2"</param>
	    /// <param name="baseSystem">Основание системы исчисления</param>
	    /// <returns>Строка с результатом</returns>
	    public string Calc(string formula, int baseSystem)
        {
            var members = Parsing.Parse(formula,_operatorList);
            UnarBinarCorrect(members);

            var err = CheckErrors.CheckCorrect(members, baseSystem);
	        if (!Equals(err, "")) return err;

	        var cont1 = new Context();
            cont1.CalcContext(members, baseSystem, CalcBaseListProto);

            if (members.Count == 1) return members[0].RealNumber.ToString(CultureInfo.InvariantCulture);

            return "Damn";
        }
	}
}
