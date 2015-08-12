using System.Collections.Generic;
using System.Globalization;
using SoftCalc2.Common;

namespace SoftCalc2.Core
{
    public static class CheckErrors
    {

        /// <summary>
        /// проверка на ошибки
        /// </summary>
        /// <param name="members">Список элементов для расчета</param>
        /// <param name="baseSystem">Система исчисления</param>
        /// <returns></returns>
        public static string CheckCorrect(IList<IMember> members, int baseSystem)
        {
            for (var i = 0; i < members.Count; i++)
            {
                if ((i > 0) && (members[i].Operator.OperatorType == members[i - 1].Operator.OperatorType) &&
                    (members[i].Operator.OperatorType == EnumOperatorType.Binar))
                {
                    return "ERROR FOR TWO BINAR OPERATIONS";
                }

                if ((members[i].Operator.OperatorType == EnumOperatorType.Number) &&
                    (Alphabet.Find(members[i].Operator.OperatorText) >= baseSystem))
                {
                    return "ERROR FOR NUMBER " + members[i].Operator.OperatorText + ", BASESYSTEM IS " +
                           baseSystem.ToString(CultureInfo.InvariantCulture);
                }

                if ((i > 0) && (i < members.Count - 1) &&
                    (members[i].Operator.OperatorType == EnumOperatorType.Space) &&
                    (members[i - 1].Operator.OperatorType == EnumOperatorType.Number) &&
                    (members[i + 1].Operator.OperatorType == EnumOperatorType.Number))
                {
                    return "Два числа подряд чеез пробел";
                }

            }
            return "";
        }

    }
}
