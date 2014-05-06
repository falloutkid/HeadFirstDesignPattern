using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPattern.Strategy;
using HeadFirstDesignPattern;

namespace UnitTestProject
{
    [TestClass]
    public class TestStrategy
    {
        #region TestQuack
        [TestMethod]
        [TestCategory("Quack")]
        public void TestMallardQuack()
        {
            MallardDuck duck = new MallardDuck();
            duck.quack();
            //duck.performQuack();
        }

        [TestMethod]
        [TestCategory("Quack")]
        public void TestRedheadQuack()
        {
            RedheadDuck duck = new RedheadDuck();
            duck.quack();
            //duck.performQuack();
        }

        [TestMethod]
        [TestCategory("Quack")]
        public void TestRubberQuack()
        {
            RubberDuck duck = new RubberDuck();
            duck.quack();
            //duck.performQuack();
        }
        #endregion

        #region TestFly
        [TestMethod]
        [TestCategory("Fly")]
        public void TestMallardFly()
        {
            MallardDuck duck = new MallardDuck();
            duck.fly();
            //duck.performFly();
        }

        [TestMethod]
        [TestCategory("Fly")]
        public void TestRedheadFly()
        {
            RedheadDuck duck = new RedheadDuck();
            duck.fly();
            //duck.performFly();
        }

        [TestMethod]
        [TestCategory("Fly")]
        public void TestRubberFly()
        {
            RubberDuck duck = new RubberDuck();
            duck.fly();
            //duck.performFly();
        }
        #endregion

        #region SetFlyBehavior
        [TestMethod]
        [TestCategory("SetFlyBehavior")]
        public void TestSetFlyBehavior()
        {
            ModelDuck duck = new ModelDuck();

            duck.fly();
            duck.setFlyBehavior(new FlyRocketPowered());
            duck.fly();
        }
        #endregion
    }
}
