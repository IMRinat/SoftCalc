using System.Collections.Generic;
using SoftCalc2.Common;

namespace SoftCalc2.Default
{
    class CalcBracketsHelper
    {
        /// <summary>
        /// поиск элемента в списке
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        /// <param name="symbol">символ для поиска</param>
        /// <returns>номер элемента в списке</returns>
        private static int FindSymbolPred(int i, IContext context, string symbol)
        {
            int j;
            for (j = i - 1; j >= 0; j--)
                if (context.MemberList[j].Operator.OperatorText.Equals(symbol)) break;
            return j;
        }

        //клонирование списка элементов. слабонервным не смотреть.
        /// <summary> 
        /// клонирование списка элементов в новый список
        /// Создает копию списка элементов с элемента i по элемент j
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="j"></param>
        /// <param name="memberList">список элементов</param>
        /// <returns>новый список элементов</returns>
        static private IList<IMember> DoClone(int i, int j, IList<IMember> memberList)
        {
            //TODO Надо исполоьзовать встроенную функцию копирования
            var clonememberList = new List<IMember>();
            for (var n = i - 1; n > j; n--)
            {
                clonememberList.Insert(0, memberList[n]);
            }
            return clonememberList;
        }

        /// <summary>
        /// Удаление из списка элементов с j до i
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="memberList">список элементов</param>
        static private void DoRemoveIj(int i, int j, IList<IMember> memberList)
        {
            for (var n = i - 1; n > j; n--)
            {
                memberList.RemoveAt(n);
            }
            memberList.RemoveAt(j);
        }

        /// <summary>
        /// расчет выражения в скобках
        /// </summary>
        /// <param name="i">Номер элемента в спсике элементов</param>
        /// <param name="context">Контекст в котором список элементов и функция расчета всех элементов </param>
        /// <param name="symbol">символ открывающей скобки</param>
        static public void CalcBracketProc(int i, IContext context, string symbol)
        {
            //находим открывающую скобку
            var j = FindSymbolPred(i, context, symbol);
            //делаем копию списка от открывающейся до закрывающейся скобки
            var clonememberList = DoClone(i, j, context.MemberList);

            //Удаляем из основного списка выражение в скобках
            DoRemoveIj(i, j, context.MemberList);

            //вычисляем  содержимое скобок
            var tempContext = context.NewContextObject();
            tempContext.CalcContext(clonememberList, context.Basesystem, context.CalcMemberList);

            //заменяем содержимое скобок на вычисленное выражение
            context.MemberList[j] = clonememberList[0]; //TODO   проверить на ошибки нужно будет тебе
        }

    }
}
