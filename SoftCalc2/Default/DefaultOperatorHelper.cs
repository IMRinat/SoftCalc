using System.Collections.Generic;
using SoftCalc2.Common;

namespace SoftCalc2.Default
{
	public static class DefaultOperatorHelper
	{
		/// <summary>
		/// Метод возвращает список всех возможных операторов
		/// правила расставления приоритетов
		///  0 - не обращать внимания
        ///  1 - пробел
        ///  2 - числа
        ///  3 - десятичный разделитель
		///  4 - скобки
		///  5,6,7 - операции
		/// </summary>
		/// <returns>Спиcок операторов </returns>
        public static List<IOperator> GetDefaultOperatorList()
		{
			return new List<IOperator>
            {
                new COperator( "(", 0, EnumOperatorType.OpenBracket, (i, list) => {}),
                new COperator( "{", 0, EnumOperatorType.OpenBracket, (i, list) => {}),
                new COperator( "[", 0, EnumOperatorType.OpenBracket, (i, list) => {}),

                new COperator( " ", 1, EnumOperatorType.Space, DefaultFuncHelper.SpaceProc),

                new COperator( "0", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "1", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "2", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "3", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "4", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "5", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "6", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "7", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "8", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "9", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "A", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "B", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "C", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "D", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "E", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),
                new COperator( "F", 2, EnumOperatorType.Number, DefaultFuncHelper.ConvertNumber),

                new COperator( ".", 3, EnumOperatorType.Dot,DefaultFuncHelper.BinarDot),
                new COperator( ",", 3, EnumOperatorType.Dot,DefaultFuncHelper.BinarDot),

                new COperator( ")", 4, EnumOperatorType.CloseBracket,DefaultFuncHelper.BracketProc),
                new COperator( "]", 4, EnumOperatorType.CloseBracket,DefaultFuncHelper.BracketProc2),
                new COperator( "}", 4, EnumOperatorType.CloseBracket,DefaultFuncHelper.BracketProc3),

                new COperator("sin",5,EnumOperatorType.Unar,DefaultFuncHelper.SinFunc),
                
                new COperator( "+", 6, EnumOperatorType.Unar,DefaultFuncHelper.UnarPlus),
                new COperator( "-", 6, EnumOperatorType.Unar,DefaultFuncHelper.UnarMinus),

                new COperator( "*", 7, EnumOperatorType.Binar,DefaultFuncHelper.BinarMulltiple),
                new COperator( "/", 7, EnumOperatorType.Binar,DefaultFuncHelper.BinarDivide),
                
                new COperator( "+", 8, EnumOperatorType.Binar,DefaultFuncHelper.BinarPlus),
                new COperator( "-", 8, EnumOperatorType.Binar,DefaultFuncHelper.BinarMinus)
            };
		}
	}
}