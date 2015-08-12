using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftCalc2.Core;
using SoftCalc2.Default;

namespace SoftCalc2.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void CalcOneNumber()
		{
			var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
			var result = act.Calc("2",10);
			Assert.AreEqual("2", result);
		}

		[TestMethod]
		public void Calcsum()
		{
			var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("22+22", 10);
			Assert.AreEqual("44", result);
		}

		[TestMethod]
		public void Calcdel()
		{
			var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("60/2", 10);
			Assert.AreEqual("30", result);
		}

		[TestMethod]
		public void CalcUnar()
		{
			var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("60/-2", 10);
			Assert.AreEqual("-30", result);
		}

        [TestMethod]
        public void Calcunarbinar()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("33--33", 10);
            Assert.AreEqual("66", result);
        }

        [TestMethod]
        public void Calcmmm()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("33---33", 10);
            Assert.AreEqual("0", result);
        }

        [TestMethod]
        public void CalcSin()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("1000000* sin (333/106/2)+1", 10);
            Assert.AreEqual("1000000", result.Substring(0, 7));
        }

        [TestMethod]
        public void CalcDot()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("100.001", 10);
            Assert.AreEqual("100.001", result);
        }

        [TestMethod]
        public void CalcDotDvoich()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("100.001", 2);
            Assert.AreEqual("4.125", result);
        }

        [TestMethod]
        public void CalcDot16()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("F.F", 16);
            Assert.AreEqual("15.9375", result);
        }

        [TestMethod]
        public void CalcPrior()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("22+22*22", 10);
            Assert.AreEqual("506", result);
        }

        [TestMethod]
        public void Calc257()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("((333/106/2)+1)*100", 10);
            Assert.AreEqual("257", result.Substring(0, 3));
        }

        [TestMethod]
        public void Dvoich1111()
        {
            var act = new CalcCore(DefaultOperatorHelper.GetDefaultOperatorList().ToArray());
            var result = act.Calc("1111", 2);
            Assert.AreEqual("15", result);
        }

        
    }
}
