using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HeadFirstDesignPattern;
using HeadFirstDesignPattern.Singleton;

namespace UnitTestProject
{
    [TestClass]
    public class TestSingleton
    {
        [Ignore]
        public void TestAlwaysFailt()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestGetSameInstance()
        {
            ChocolateBoilder instance1 = ChocolateBoilder.getInstance();
            ChocolateBoilder instance2 = ChocolateBoilder.getInstance();

            Assert.AreSame(instance1, instance2);
        }
    }
}
