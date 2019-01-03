using NUnit.Framework;

namespace Calculator.NUnitTests
{
    [TestFixture]
    public class CalcTests
    {
        [Test]
        [Category("NUNIT")]
        public void Calc_Sum_1_and_5_results_6()
        {
            Calc calc = new Calc();

            int result = calc.Sum(1, 5);

            Assert.AreEqual(6, result);
        }

        [Test]
        [Category("NUNIT")]
        [TestCase(12, -5, 7)]
        [TestCase(12, 5, 17)]
        public void Calc_Sum(int a, int b, int soll)
        {
            Calc calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.AreEqual(soll, result);
        }
    }
}
