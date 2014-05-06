using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using HeadFirstDesignPattern.Adapter;

namespace UnitTestProject
{
    [TestClass]
    public class TestAdapter
    {
        [TestMethod]
        public void TestDuckInterface()
        {
            Mock<Duck> mock_duck = new Mock<Duck>();

            mock_duck.Setup(m => m.fly()).Callback(()=>System.Diagnostics.Debug.WriteLine("飛んでいます"));
            mock_duck.Setup(m => m.quack()).Callback(() => System.Diagnostics.Debug.WriteLine("ガーガー"));
            mock_duck.Object.fly();
            mock_duck.Object.quack();
            mock_duck.VerifyAll();
        }

        [TestMethod]
        public void TestMallardDuck()
        {
            Duck duck = new MallardDuck();

            duck.fly();
            duck.quack();
        }

        [TestMethod]
        public void TestDuckAdapter()
        {
            Duck duck = new MallardDuck();
            Turkey mallard_duck_adapter = new DuckAdapter(duck);

            mallard_duck_adapter.gobble();
            for(int i = 0;i < 10;i++)
            {
                System.Diagnostics.Debug.Write(i.ToString() + "回目のfly()呼び出し");
                mallard_duck_adapter.fly();
                System.Diagnostics.Debug.Write("\n");
            }
        }

        [TestMethod]
        public void TestTurkeyAdapter()
        {
            Turkey wild_turkey = new WildTurkey();
            Duck wild_turkey_adapter = new TurkeyAdapter(wild_turkey);

            wild_turkey_adapter.fly();
            wild_turkey_adapter.quack();
        }
    }
}
