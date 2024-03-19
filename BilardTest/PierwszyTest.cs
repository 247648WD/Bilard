using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BilardTest
{
    [TestClass]
    public class PierwszyTest
    {
        [TestMethod]
        public void GettersTest()
        {
            Bila bila1 = new Bila(-3, 4.5, 8, 90);
            Assert.AreEqual(-3, bila1.GetX());
            Assert.AreEqual(4.5, bila1.GetY());
            Assert.AreEqual(8, bila1.GetVel());
            Assert.AreEqual(90, bila1.GetDir());
        }

        [TestMethod]
        public void UpdateTest()
        {
            Bila bila2 = new Bila(0, 0, 5, 90);
            Bila bila3 = new Bila(3, 4, 15, 45);
            Bila bila4 = new Bila(3, 4, 12, 30);
            bila2.UpdatePos();
            bila3.UpdatePos();
            bila4.UpdatePos();
            Assert.AreEqual(5, bila2.GetX());
            Assert.AreEqual(0, bila2.GetY());
            Assert.AreEqual(10.879829832265946, bila3.GetX());
            Assert.AreEqual(16.76355286801178, bila3.GetY());
            Assert.AreEqual(4.851017398651009, bila4.GetX());
            Assert.AreEqual(-7.856379489114341, bila4.GetY());
        }
    }
}