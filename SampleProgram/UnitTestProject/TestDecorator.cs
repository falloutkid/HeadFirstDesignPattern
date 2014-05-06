using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPattern.Decorator;
using Moq;
using HeadFirstDesignPattern;

namespace UnitTestProject
{
    [TestClass]
    public class TestDecorator
    {
        private Mock<Beverage> beverage_mock;

        [TestInitialize]
        public void Setup()
        {
            beverage_mock = new Mock<Beverage>();
        }

        #region Coffee
        [TestMethod]
        [TestCategory("Coffee")]
        public void TestEspressoCost()
        {
            Beverage beverage = new Espresso();

            Assert.AreEqual<double>(1.99, beverage.cost());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestEspressoDescription()
        {
            Beverage beverage = new Espresso();

            Assert.AreEqual<string>("エスプレッソ", beverage.GetDescription());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestDarkRoastCost()
        {
            Beverage beverage = new DarkRoast();

            Assert.AreEqual<double>(0.99, beverage.cost());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestDarkRoastDescription()
        {
            Beverage beverage = new DarkRoast();

            Assert.AreEqual<string>("ダークロースト", beverage.GetDescription());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestHouseBlendCost()
        {
            Beverage beverage = new HouseBlend();

            Assert.AreEqual<double>(0.89, beverage.cost());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestHouseBlendDescription()
        {
            Beverage beverage = new HouseBlend();

            Assert.AreEqual<string>("ハウスブレンド", beverage.GetDescription());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestDecafCost()
        {
            Beverage beverage = new Decaf();

            Assert.AreEqual<double>(1.05, beverage.cost());
        }

        [TestMethod]
        [TestCategory("Coffee")]
        public void TestDecafDescription()
        {
            Beverage beverage = new Decaf();

            Assert.AreEqual<string>("カフェイン抜き", beverage.GetDescription());
        }
        #endregion

        #region Toping
        [TestMethod]
        [TestCategory("Toping")]
        public void TestMochaDescription()
        {
            beverage_mock.Setup(m => m.GetDescription()).Returns("エスプレッソ");

            CondimentDecorator toping = new Mocha(beverage_mock.Object);

            string expect = string.Format("エスプレッソ" + "、モカ");
            Assert.AreEqual(expect, toping.GetDescription());
            beverage_mock.VerifyAll();
        }

        [TestMethod]
        [TestCategory("Toping")]
        public void TestCost()
        {
            beverage_mock.Setup(m => m.cost()).Returns(0.99);

            CondimentDecorator toping = new Mocha(beverage_mock.Object);

            double expect = 0.99 + 0.20;
            Assert.AreEqual(expect, toping.cost());
            beverage_mock.VerifyAll();
        }

        [TestMethod]
        [TestCategory("Toping")]
        public void TestSoyDescription()
        {
            beverage_mock.Setup(m => m.GetDescription()).Returns("ハウスブレンド");

            CondimentDecorator toping = new Soy(beverage_mock.Object);

            string expect = string.Format("ハウスブレンド" + "、ソイ");
            Assert.AreEqual(expect, toping.GetDescription());
            beverage_mock.VerifyAll();
        }

        [TestMethod]
        [TestCategory("Toping")]
        public void TestSoyCost()
        {
            beverage_mock.Setup(m => m.cost()).Returns(0.89);

            CondimentDecorator toping = new Soy(beverage_mock.Object);

            double expect =  0.89+ 0.15;
            Assert.AreEqual(expect, toping.cost());
            beverage_mock.VerifyAll();
        }
        
        [TestMethod]
        [TestCategory("Toping")]
        public void TestMilkDescription()
        {
            beverage_mock.Setup(m => m.GetDescription()).Returns("カフェイン抜き");

            CondimentDecorator toping = new Milk(beverage_mock.Object);

            string expect = string.Format("カフェイン抜き" + "、スチームミルク");
            Assert.AreEqual(expect, toping.GetDescription());
            beverage_mock.VerifyAll();
        }

        [TestMethod]
        [TestCategory("Toping")]
        public void TestMilkCost()
        {
            beverage_mock.Setup(m => m.cost()).Returns(1.99);

            CondimentDecorator toping = new Milk(beverage_mock.Object);

            double expect =  1.99+ 0.10;
            Assert.AreEqual(expect, toping.cost());
            beverage_mock.VerifyAll();
        }
        
        [TestMethod]
        [TestCategory("Toping")]
        public void TestWhipDescription()
        {
            beverage_mock.Setup(m => m.GetDescription()).Returns("ダークロースト");

            CondimentDecorator toping = new Whip(beverage_mock.Object);

            string expect = string.Format("ダークロースト" + "、ホイップ");
            Assert.AreEqual(expect, toping.GetDescription());
            beverage_mock.VerifyAll();
        }

        [TestMethod]
        [TestCategory("Toping")]
        public void TestWhipCost()
        {
            beverage_mock.Setup(m => m.cost()).Returns(0.99);

            CondimentDecorator toping = new Whip(beverage_mock.Object);

            double expect =  0.99+ 0.10;
            Assert.AreEqual(expect, toping.cost());
            beverage_mock.VerifyAll();
        }
        #endregion

        [TestMethod]
        [TestCategory("E2E_Decorator")]
        public void EndToEndTest1()
        {
            Beverage beverage = new DarkRoast();
            Assert.AreEqual("ダークロースト", beverage.GetDescription());

            beverage = new Mocha(beverage);
            Assert.AreEqual("ダークロースト、モカ", beverage.GetDescription());

            beverage = new Mocha(beverage);
            Assert.AreEqual("ダークロースト、モカ、モカ", beverage.GetDescription());

            beverage = new Whip(beverage);
            Assert.AreEqual(1.49, beverage.cost());
            Assert.AreEqual("ダークロースト、モカ、モカ、ホイップ", beverage.GetDescription());
        }

        [TestMethod]
        [TestCategory("E2E_Decorator")]
        public void EndToEndTest2()
        {
            Beverage beverage = new DarkRoast();

            beverage = new Soy(beverage);
            beverage = new Mocha(beverage);
            beverage = new Whip(beverage);

            Assert.AreEqual(1.44, beverage.cost());
            Assert.AreEqual("ダークロースト、ソイ、モカ、ホイップ", beverage.GetDescription());
        }
    }
}
