using System;
using SoftCalc2.Common;

namespace SoftCalc2.Default
{
	public class COperator:IOperator
	{

		public COperator(string name, int priority, EnumOperatorType opertyp, Action<int, IContext> calcOper)
		{
			OperatorText = name;
            OperatorPriority = priority;
			OperatorType  =  opertyp;
			CalcOperator = calcOper;
		}

        public string OperatorText { get; private set; }
        public int OperatorPriority { get; private set; }
        public EnumOperatorType OperatorType { get; private set; }
		public Action<int, IContext> CalcOperator { get; private set; }

	}
}
