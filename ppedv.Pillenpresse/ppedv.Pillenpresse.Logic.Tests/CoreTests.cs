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

            Core core = new Core(mock.Object, null);

            Assert.ThrowsException<ArgumentNullException>(() => core.MakePillsForSymptom(null));

            mock.Verify(x => x.Machzeug(It.IsAny<IEnumerable<Wirkstoff>>()), Times.Never);
        }


        [TestMethod]
        public void Core_can_MakePillsForSymptom()
        {
            var mock = new Mock<IDevice>();
            var sym = new Symptom() { Name = "Test1" };

            Core core = new Core(mock.Object, null);

            core.MakePillsForSymptom(sym);

            mock.Verify(x => x.Machzeug(It.IsAny<IEnumerable<Wirkstoff>>()), Times.Once);
        }

        [TestMethod]
        public void Core_MakeAllPills()
        {
            var dMock = new Mock<IDevice>();
            var rMock = new Mock<IRepository>();

            rMock.Setup(x => x.GetAll<Symptom>()).Returns(() =>
            {
                var s1 = new Symptom() { Name = "S1" };
                s1.Wirkstoffe.Add(new Wirkstoff() { Name = "W1" });
                s1.Wirkstoffe.Add(new Wirkstoff() { Name = "W2" });

                //        var s2 = new Symptom() { Name = "S2" };
                //        s2.Wirkstoffe.Add(new Wirkstoff() { Name = "W3" });
                //        s2.Wirkstoffe.Add(new Wirkstoff() { Name = "W4" });

                return new[] { s1, s1, s1 };
            });

            Core core = new Core(dMock.Object, rMock.Object);

            core.MakeAllPills();

            dMock.Verify(x => x.Machzeug(It.IsAny<IEnumerable<Wirkstoff>>()), Times.Exactly(3));
        }
    }
}
