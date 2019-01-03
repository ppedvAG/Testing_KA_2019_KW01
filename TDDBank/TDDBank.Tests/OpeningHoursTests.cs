using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDDBank.Tests
{
    [TestClass]
    public class OpeningHoursTests
    {
        [TestMethod]
        [DataRow(2018, 12, 31, 10, 30, true)]//mo
        [DataRow(2018, 12, 31, 10, 29, false)]//mo
        [DataRow(2018, 12, 31, 19, 0, false)] //mo
        [DataRow(2019, 1, 5, 12, 0, true)] //sa
        [DataRow(2019, 1, 5, 18, 0, false)] //sa
        [DataRow(2019, 1, 6, 12, 0, false)] //so
        public void OpeningHours_IsOpen(int y, int M, int d, int h, int m, bool result)
        {
            var dt = new DateTime(y, M, d, h, m, 0);
            var oh = new OpeningHours();

            Assert.AreEqual(result, oh.IsOpen(dt));
        }


    }
}
