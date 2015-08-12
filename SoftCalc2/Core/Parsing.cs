using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using SoftCalc2.Common;

namespace SoftCalc2.Core
{
    static class Parsing
    {

        /// <summary>
        /// функция поиска подходящего под текст оператора
        /// </summary>
        /// <param name="textForParse">Текст с выражением</param>
        /// <param name="operatorList">список всех операторов</param>
        /// <returns>Оператор</returns>
        private static IOperator FindOperator(string textForParse, IOperator[] operatorList)
        {
           return operatorList.FirstOrDefault
               (oper => oper.OperatorText == textForParse.Substring(0, Math.Min(oper.OperatorText.Length, textForParse.Length)));
        }


        /// <summary>
        /// Функция для перевода строки в список элементов
        /// </summary>
        /// <param name="textForParse">Текст с выражением </param>
        /// <param name="operatorList">Список всех возможных операций </param>
        /// <returns>Список элементов для расчета</returns>
        public static IList<IMember> Parse(string textForParse, IOperator[] operatorList)
        {
            if (Equals(textForParse, ""))
            {
                throw new ArgumentNullException("ERROR  TRY " + "CALC EMPTY STRING");
            }

            var memberList = new List<IMember>();
            var errorPosition = 0;
            while (textForParse.Length > 0)
            {
                var tmpOper = FindOperator(textForParse, operatorList);
                if (tmpOper == null)
                {
                    throw new ArgumentNullException("ERROR PARSING ON SYMBOL " + errorPosition.ToString(CultureInfo.InvariantCulture) + " WITH TEXT " + textForParse);
                }

                memberList.Add(new Member(tmpOper));
                textForParse = textForParse.Substring(tmpOper.OperatorText.Length);
                errorPosition += tmpOper.OperatorText.Length;
            }
            return memberList;
        }
    }
}
