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
            b1 = (Bila)b1.Copy(2, 2, 1, 1, 1, 90);
            Assert.AreEqual(2, b1.GetX());
            Assert.AreEqual(2, b1.GetY());
            Assert.AreEqual(1, b1.GetMass());
            Assert.AreEqual(1, b1.GetVel());
            Assert.AreEqual(1, b1.GetVel());
            Assert.AreEqual(90, b1.GetDir());
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
            b2 = (Bila)b2.Copy(2, 1, 1, 1, 1, 0);
            b3 = (Bila)b3.Copy(1, 1, 1, 1, 1, 0);
            listMove.Add(b2);
            listMove.Add(b3);
            b2.MoveBalls(listMove, 3, 0, 4, 0);
            Assert.AreEqual(3, b2.GetX());
            Assert.AreEqual(2, b3.GetX());
            b2.MoveBalls(listMove, 3, 0, 4, 0);
            Assert.AreEqual(2, b2.GetX());
            Assert.AreEqual(3, b3.GetX());
        }

        public void BilaGenerateTest()
        {
            listGenerate = b4.GenerateBalls(3, 5, 1, 3, 2);
            Assert.IsTrue(listGenerate[0].GetX() < 5 && listGenerate[0].GetX() >= 1);
            Assert.IsTrue(listGenerate[0].GetY() < 3 && listGenerate[0].GetY() >= 2);
            Assert.IsTrue(listGenerate[1].GetX() < 5 && listGenerate[0].GetX() >= 1);
            Assert.IsTrue(listGenerate[1].GetY() < 3 && listGenerate[0].GetY() >= 2);
            Assert.IsTrue(listGenerate[2].GetX() < 5 && listGenerate[0].GetX() >= 1);
            Assert.IsTrue(listGenerate[2].GetY() < 3 && listGenerate[0].GetY() >= 2);
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