using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Bridge;

namespace UnitTestProject
{
    [TestClass]
    public class TestBridge
    {
        [TestMethod]
        public void TestMethod()
        {
            SetCarEngine carEngine1500cc = new SetCarEngine1500cc();
            SetCarEngine carEngine2000cc = new SetCarEngine2000cc();

            Car truck1500cc = new Truck(carEngine1500cc);
            Car truck2000cc = new Truck(carEngine2000cc);

            truck1500cc.setEngine();
            truck2000cc.setEngine();

            Car bus1500cc = new Bus(carEngine1500cc);
            Car bus2000cc = new Bus(carEngine2000cc);

            bus1500cc.setEngine();
            bus2000cc.setEngine();  
        }
    }
}
