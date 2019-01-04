using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Pillenpresse.Model;
using ppedv.Pillenpresse.Model.Contracts;

namespace ppedv.Pillenpresse.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_MakePillsForSymptom_symptom_null_throws_ArgumentException()
        {
            var mock = new Mock<IDevice>();

            Core core = new Core(mock.Object);

            Assert.ThrowsException<ArgumentNullException>(() => core.MakePillsForSymptom(null));

            mock.Verify(x => x.Machzeug(It.IsAny<IEnumerable<Wirkstoff>>()), Times.Never);
        }


        [TestMethod]
        public void Core_can_MakePillsForSymptom()
        {
            var mock = new Mock<IDevice>();
            var sym = new Symptom() { Name = "Test1" };

            Core core = new Core(mock.Object);

            core.MakePillsForSymptom(sym);

            mock.Verify(x => x.Machzeug(It.IsAny<IEnumerable<Wirkstoff>>()), Times.Once);
        }
    }
}
