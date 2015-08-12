using System;
using SoftCalc2.Common;

namespace SoftCalc2.Default
{
    /// <summary>
    ///  Ниже следуют методы для расчет операций + - * и т.д.
    /// </summary>
    public static class DefaultFuncHelper
	{
        /// <summary>
        /// Конвертация числа
        /// </summary>
        /// <param name="i">Номер элемента в списке элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void ConvertNumber(int i, IContext context)
		{

            //если перед числом есть точка
	        if ((i > 0) && (context.MemberList[i - 1].Operator.OperatorType == EnumOperatorType.Dot))
	        {
	            context.MemberList[i - 1].RealNumber++;
	            context.MemberList[i].RealNumber = Alphabet.Find(context.MemberList[i].Operator.OperatorText)/
	                                               Math.Pow(context.Basesystem, context.MemberList[i - 1].RealNumber) +
	                                               context.MemberList[i].RealNumber;
	        }
	        else
	        {
	            //если перед числом нет точки
	            context.MemberList[i].RealNumber = context.Basesystem*context.MemberList[i].RealNumber +
	                                               Alphabet.Find(context.MemberList[i].Operator.OperatorText);

	        }

	        //помечаем как просчитанное
            context.MemberList[i].MemberType = EnumMemberType.Calc;

            //если и дальше есть число, то записываем ему наш результат
			if ((i != (context.MemberList.Count - 1)) && (context.MemberList[i + 1].Operator.OperatorType == EnumOperatorType.Number))
			{
			    context.MemberList[i + 1].RealNumber = context.MemberList[i].RealNumber;
				context.MemberList.RemoveAt(i);
			}
		}

		/// <summary>
		///  расчет синуса аргумента
		/// </summary>
        /// <param name="i">Номер элемента в списке элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void SinFunc(int i, IContext context)
		{
			context.MemberList[i + 1].RealNumber = Math.Sin(context.MemberList[i + 1].RealNumber);
			context.MemberList.RemoveAt(i);
		}

        /// <summary>
        /// расчет унарного минуса
        /// </summary>
        /// <param name="i">Номер элемента в списке элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        public static void UnarMinus(int i, IContext context)
	    {
	        context.MemberList[i + 1].RealNumber = context.MemberList[i + 1].RealNumber*(-1);
	        context.MemberList.RemoveAt(i);
	    }

        /// <summary>
        /// расчет бинарного минуса
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        public static void BinarMinus(int i, IContext context)
	    {
	        context.MemberList[i - 1].RealNumber = context.MemberList[i - 1].RealNumber -
	                                               context.MemberList[i + 1].RealNumber;
	        context.MemberList.RemoveAt(i);
	        context.MemberList.RemoveAt(i);
	    }


	    /// <summary>
	    /// расчет унарного плюса
	    /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        public static void UnarPlus(int i, IContext context)
	    {
	        context.MemberList.RemoveAt(i);
	    }

	    /// <summary>
	    /// расчет бинарного плюса
	    /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        public static void BinarPlus(int i, IContext context)
	    {
	        context.MemberList[i - 1].RealNumber = context.MemberList[i - 1].RealNumber +
	                                               context.MemberList[i + 1].RealNumber;
	        context.MemberList.RemoveAt(i);
	        context.MemberList.RemoveAt(i);
	    }

        /// <summary>
        /// расчет разделитля дробной части
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void BinarDot(int i, IContext context)
		{
			context.MemberList[i - 1].RealNumber = context.MemberList[i - 1].RealNumber + context.MemberList[i + 1].RealNumber;
			context.MemberList.RemoveAt(i);
			context.MemberList.RemoveAt(i);
		}

		/// <summary>
		/// расчет деления
		/// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void BinarDivide(int i, IContext context)
		{
			context.MemberList[i - 1].RealNumber = context.MemberList[i - 1].RealNumber / context.MemberList[i + 1].RealNumber;
			context.MemberList.RemoveAt(i);
			context.MemberList.RemoveAt(i);
		}

		/// <summary>
		/// расчет умножения
		/// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void BinarMulltiple(int i, IContext context)
		{
			context.MemberList[i - 1].RealNumber = context.MemberList[i - 1].RealNumber * context.MemberList[i + 1].RealNumber;
			context.MemberList.RemoveAt(i);
			context.MemberList.RemoveAt(i);
		}

		/// <summary>
		/// обработка пробела
		/// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void SpaceProc(int i, IContext context)
		{
			context.MemberList.RemoveAt(i);
		}
        
        /// <summary>
        /// расчет скобки
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void BracketProc(int i, IContext context)
        {
          CalcBracketsHelper.CalcBracketProc(i, context, "(");
        }

        /// <summary>
        /// расчет скобки
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void BracketProc2(int i, IContext context)
        {
            CalcBracketsHelper.CalcBracketProc(i, context, "[");
        }

        /// <summary>
        /// расчет скобки
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        static public void BracketProc3(int i, IContext context)
        {
            CalcBracketsHelper.CalcBracketProc(i, context, "{");
        }
    }
}
