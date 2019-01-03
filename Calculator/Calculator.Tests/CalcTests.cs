using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Calc_Sum_3_and_4_Results_7()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(3, 4);

            //Assert
            Assert.AreEqual(7, result);
        }


        [TestMethod]
        public void Calc_Sum_0_and_0_Results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [TestCategory("Exceptiontest")]
        public void Calc_Sum_MAX_and_1_throws_OverflowException()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));
        }

        [TestMethod]
        [DataRow(2, 7, 9)]
        [DataRow(1400, 700, 2100)]
        [DataRow(10, -20, -10)]
        [DataRow(-10, -20, -30)]
        [DataRow(-10, 20, 10)]
        public void Calc_Sum(int a, int b, int soll)
        {
            Calc calc = new Calc();

            var result = calc.Sum(a, b);

            Assert.AreEqual(soll, result);
        }

        [TestMethod]
        [TestCategory("Exceptiontest")]
        [DataRow(int.MaxValue, 1)]
        [DataRow(1, int.MaxValue)]
        [DataRow(-1, int.MinValue)]
        public void Calc_Sum_throws_OverflowException(int a, int b)
        {
            Calc calc = new Calc();

            Assert.ThrowsException<OverflowException>(() => calc.Sum(a, b));
        }

    }
}
