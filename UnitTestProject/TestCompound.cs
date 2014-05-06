using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Compound;

namespace UnitTestProject
{
    [TestClass]
    public class TestCompound
    {
        IQuackable mallard_duck;
        IQuackable redhead_duck;
        IQuackable duck_call;
        IQuackable rubber_duck;

        IQuackable goose;

        [TestInitialize]
        public void Setup()
        {
        }

        [TestMethod]
        public void Test_DuckQuack()
        {
            System.Diagnostics.Debug.WriteLine("鴨シュミレータ");

            mallard_duck = new MallardDuck();
            redhead_duck = new RedheadDuck();
            duck_call = new DuckCall();
            rubber_duck = new RubberDuck();

            simulate(mallard_duck);
            simulate(redhead_duck);
            simulate(duck_call);
            simulate(rubber_duck);
        }

        [TestMethod]
        public void Test_DuckQuackAndGoose()
        {
            System.Diagnostics.Debug.WriteLine("鴨とガチョウのシュミレータ");

            mallard_duck = new MallardDuck();
            redhead_duck = new RedheadDuck();
            duck_call = new DuckCall();
            rubber_duck = new RubberDuck();

            goose = new GooseAdapter(new Goose());

            simulate(mallard_duck);
            simulate(redhead_duck);
            simulate(duck_call);
            simulate(rubber_duck);

            simulate(goose);
        }

        [TestMethod]
        public void Test_QuackCounter()
        {
            System.Diagnostics.Debug.WriteLine("鴨シュミレータ:デコレータ付き");
            mallard_duck = new QuackCounter(new MallardDuck());
            redhead_duck = new QuackCounter(new RedheadDuck());
            duck_call = new QuackCounter(new DuckCall());
            rubber_duck = new QuackCounter(new RubberDuck());

            goose = new GooseAdapter(new Goose());

            simulate(mallard_duck);
            simulate(redhead_duck);
            simulate(duck_call);
            simulate(rubber_duck);

            simulate(goose);

            System.Diagnostics.Debug.WriteLine(string.Format("鴨が鳴いた回数：{0}回",QuackCounter.QuackCount));
        }

        [TestMethod]
        public void Test_CountingDuckFactory()
        {
            AbstractDuckFactory duck_factory = new CountingDuckFactory();

            mallard_duck = duck_factory.CreateMallardDuck();
            redhead_duck = duck_factory.CreateRedheadDuck();
            duck_call = duck_factory.CreateDuckCall();
            rubber_duck = duck_factory.CreateRubberDuck();

            System.Diagnostics.Debug.WriteLine("鴨シュミレータ:CountingDuckFactoryより");
            simulate(mallard_duck);
            simulate(redhead_duck);
            simulate(duck_call);
            simulate(rubber_duck);

            System.Diagnostics.Debug.WriteLine(string.Format("鴨が鳴いた回数：{0}回", QuackCounter.QuackCount));

        }

        [TestMethod]
        public void Test_DuckFactory()
        {
            AbstractDuckFactory duck_factory = new DuckFactory();

            mallard_duck = duck_factory.CreateMallardDuck();
            redhead_duck = duck_factory.CreateRedheadDuck();
            duck_call = duck_factory.CreateDuckCall();
            rubber_duck = duck_factory.CreateRubberDuck();

            System.Diagnostics.Debug.WriteLine("鴨シュミレータ:DuckFactoryより");
            simulate(mallard_duck);
            simulate(redhead_duck);
            simulate(duck_call);
            simulate(rubber_duck);
        }

        [TestMethod]
        public void Test_Flock()
        {
            System.Diagnostics.Debug.WriteLine("鴨シュミレータ:コンポジット付き");
            AbstractDuckFactory duck_factory = new CountingDuckFactory();

            mallard_duck = duck_factory.CreateMallardDuck();
            redhead_duck = duck_factory.CreateRedheadDuck();
            duck_call = duck_factory.CreateDuckCall();
            rubber_duck = duck_factory.CreateRubberDuck();

            goose = new GooseAdapter(new Goose());

            Flock flock_of_ducks = new Flock();
            flock_of_ducks.Add(mallard_duck);
            flock_of_ducks.Add(redhead_duck);
            flock_of_ducks.Add(duck_call);
            flock_of_ducks.Add(rubber_duck);
            flock_of_ducks.Add(goose);

            Flock flock_of_mallard_ducks = new Flock();
            // マガモを4羽追加する
            for (int i = 0; i < 4;i++ )
            {
                flock_of_mallard_ducks.Add(duck_factory.CreateMallardDuck());
            }

            flock_of_ducks.Add(flock_of_mallard_ducks);

            System.Diagnostics.Debug.WriteLine("群れ全体のシュミレーション");
            simulate(flock_of_ducks);

            System.Diagnostics.Debug.WriteLine("マガモの群れシュミレーション");
            simulate(flock_of_mallard_ducks);

            System.Diagnostics.Debug.WriteLine(string.Format("鴨が鳴いた回数：{0}回", QuackCounter.QuackCount));

        }

        [TestMethod]
        public void Test_Quackologist()
        {
            System.Diagnostics.Debug.WriteLine("鴨シュミレータ:オブザーバー付き");
            AbstractDuckFactory duck_factory = new CountingDuckFactory();

            mallard_duck = duck_factory.CreateMallardDuck();
            redhead_duck = duck_factory.CreateRedheadDuck();
            duck_call = duck_factory.CreateDuckCall();
            rubber_duck = duck_factory.CreateRubberDuck();

            goose = new GooseAdapter(new Goose());

            Flock flock_of_ducks = new Flock();
            flock_of_ducks.Add(mallard_duck);
            flock_of_ducks.Add(redhead_duck);
            flock_of_ducks.Add(duck_call);
            flock_of_ducks.Add(rubber_duck);
            flock_of_ducks.Add(goose);

            Flock flock_of_mallard_ducks = new Flock();
            // マガモを4羽追加する
            for (int i = 0; i < 4; i++)
            {
                flock_of_mallard_ducks.Add(duck_factory.CreateMallardDuck());
            }

            flock_of_ducks.Add(flock_of_mallard_ducks);

            Quackologist quackologist = new Quackologist();
            flock_of_ducks.RegisterObserver(quackologist);

            System.Diagnostics.Debug.WriteLine("群れ全体のシュミレーション");
            simulate(flock_of_ducks);

            System.Diagnostics.Debug.WriteLine("マガモの群れシュミレーション");
            simulate(flock_of_mallard_ducks);

            System.Diagnostics.Debug.WriteLine(string.Format("鴨が鳴いた回数：{0}回", QuackCounter.QuackCount));
        }

        private void simulate(IQuackable duck)
        {
            System.Diagnostics.Debug.WriteLine(duck.Quack());
        }
    }
}
