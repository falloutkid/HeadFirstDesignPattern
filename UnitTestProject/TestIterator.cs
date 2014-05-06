using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Iterator;

namespace UnitTestProject
{
    [TestClass]
    public class TestIterator
    {
        [TestMethod]
        public void TestMethod_Waitress()
        {
            PancakeHouseMenu pancake = new PancakeHouseMenu();
            DinnerMenu dinner = new DinnerMenu();
            CafeMenu cafe = new CafeMenu();

            Waitress waitress = new Waitress(pancake, dinner, cafe);

            waitress.PrintMenu();
        }
    }
}
