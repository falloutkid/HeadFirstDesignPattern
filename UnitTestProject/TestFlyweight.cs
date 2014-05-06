using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using HeadFirstDesignPattern.Flyweight;

namespace UnitTestProject
{
    [TestClass]
    public class TestFlyweight
    {
        [TestMethod]
        public void TestMethod()
        {
            StampFactory factory = new StampFactory();
            List<Stamp> stamps = new List<Stamp>();
            stamps.Add(factory.get("た"));
            stamps.Add(factory.get("か"));
            stamps.Add(factory.get("い"));
            stamps.Add(factory.get("た"));
            stamps.Add(factory.get("け"));
            stamps.Add(factory.get("た"));
            stamps.Add(factory.get("て"));
            stamps.Add(factory.get("か"));
            stamps.Add(factory.get("け"));
            stamps.Add(factory.get("た"));
            foreach (Stamp s in stamps)
            {
                s.print();
            }
        }
    }
}
