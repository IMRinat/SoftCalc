using System;
namespace SoftCalc2.Common
{
    class Alphabet
    {
        //определяет число по тексту 
        public static int Find(string operatorText)
        {
            return "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ".IndexOf(operatorText, StringComparison.Ordinal);
        }
    }
}
