using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPattern.Prototype;

namespace UnitTestProject
{
    [TestClass]
    public class TestPrototype
    {
        [TestMethod]
        public void TestMethod()
        {
            ConcretePrototype1 prototype1 = new ConcretePrototype1("I");
            ConcretePrototype1 clone_prototype1 = (ConcretePrototype1)prototype1.Clone();
            System.Diagnostics.Debug.WriteLine(string.Format("Cloned: {0}", clone_prototype1.Id));

            ConcretePrototype2 prototype2 = new ConcretePrototype2("II");
            ConcretePrototype2 clone_prototype2 = (ConcretePrototype2)prototype2.Clone();
            System.Diagnostics.Debug.WriteLine(string.Format("Cloned: {0}", clone_prototype2.Id));
        }
    }
}
