using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.XUnitTests
{
    public class CalcTests
    {
        [Fact]
        [Trait("XUnit", "")]
        public void Sum_9_and_3_results_12()
        {
            Calc calc = new Calc();

            var result = calc.Sum(9, 3);

            Assert.Equal(12, result);
        }

        [Theory]
        [Trait("XUnit", "")]
        [InlineData(12, -5, 7)]
        [InlineData(12, 5, 17)]
        public void Calc_Sum(int a, int b, int soll)
        {
            Calc calc = new Calc();

            int result = calc.Sum(a, b);

            Assert.Equal(soll, result);
        }
    }
}
