using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logika;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.X86;
using System.Collections.Specialized;

namespace Test
{
    [TestClass]
    public class TestDane
    {
        Bila b1 = new Bila();
        Stol s1 = new Stol();

        [TestMethod]
        public void BilaTest()
        {
            b1 = (Bila)b1.Copy(0, 0, 1, 1, 1, 1);
            Assert.AreEqual(0, b1.GetX());
            Assert.AreEqual(0, b1.GetY());
            Assert.AreEqual(1, b1.GetMass());
            Assert.AreEqual(1, b1.GetSize());
            Assert.AreEqual(1, b1.GetVecX());
            Assert.AreEqual(1, b1.GetVecY());
        }

        [TestMethod]
        public void StolTest()
        {
            s1 = (Stol)s1.Copy(600, 800);
            Assert.AreEqual(600, s1.GetWidth());
            Assert.AreEqual(800, s1.GetHeight());
        }
    }

    [TestClass]
    public class TestLogika
    {
        Bila b2 = new Bila();
        Bila b3 = new Bila();
        Bila b4 = new Bila();
        List<Bila> listMove = new List<Bila>();
        List<Bila> listGenerate = new List<Bila>();

        Stol s2 = new Stol();
        [TestMethod]
        public void BilaMoveTest()
        {
            b2 = (Bila)b2.Copy(-1, -1, 1, 1, -1, -1);
            b3 = (Bila)b3.Copy(1, 1, 1, 1, 1, 1);
            b2.MoveTest(10, -10, 10, -10);
            b3.MoveTest(10, -10, 10, -10);
            Assert.AreEqual(-1, b2.GetX());
            Assert.AreEqual(1, b3.GetX());
            Assert.AreEqual(-1, b2.GetY());
            Assert.AreEqual(1, b3.GetY());
        }

        [TestMethod]
        public void StolTest()
        {
            s2.Copy(300, 400);
            Assert.AreEqual(300, s2.GetWidth());
            Assert.AreEqual(400, s2.GetHeight());
            s2.SetWidth(100);
            s2.SetHeight(100);
            Assert.AreEqual(100, s2.GetWidth());
            Assert.AreEqual(100, s2.GetHeight());
        }
    }
}