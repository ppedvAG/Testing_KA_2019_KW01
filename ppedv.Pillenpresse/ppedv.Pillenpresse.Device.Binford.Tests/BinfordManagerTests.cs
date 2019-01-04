using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.Pillenpresse.Device.Binford.Tests
{
    [TestClass]
    public class BinfordManagerTests
    {
        [TestMethod]
        public void BinfordManager_can_create_pill()
        {
            var bm = new BinfordManager();

            bm.CreatePill(null);
        }
    }
}
