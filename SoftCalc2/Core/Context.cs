using System;
using System.Collections.Generic;
using SoftCalc2.Common;

namespace SoftCalc2.Core
{
    /// <summary>
    /// Контекст нужен для рекурсивного расчета  выражений в скобках
    /// </summary>
    internal class Context : IContext
    {
        /// <summary>
        /// содержит список всех элементов для расчета
        /// </summary>
        public IList<IMember> MemberList { get; private set; }

        /// <summary>
        /// Метод расчета всех элементов
        /// </summary>
        public Action<IContext> CalcMemberList { get; private set; }

        /// <summary>
        /// система исчисления
        /// </summary>
        public int Basesystem { get; private set; }

        /// <summary>
        /// Функция для расчета контекста
        /// </summary>
        /// <param name="memberList">Список элементов для расчета</param>
        /// <param name="сalcMemberList">Функция для расчета списка элементов</param>
        /// <param name="basesystem">система исчисления</param>
        public void CalcContext(IList<IMember> memberList, int basesystem, Action<IContext> сalcMemberList)
        {
            CalcMemberList = сalcMemberList;
            MemberList = memberList;
            Basesystem = basesystem;

            сalcMemberList(this);
        }

        /// <summary>
        /// Создание нового экземпляра контекста
        /// Нужен для расчета выражений в скобках
        /// Для выражения в скобках создается отдельный контекст
        /// </summary>
        /// <returns>Новый объект контекста</returns>
        public IContext NewContextObject()
        {
            return new Context();
        }
    }
}
