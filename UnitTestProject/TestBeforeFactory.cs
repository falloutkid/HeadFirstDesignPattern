using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HeadFirstDesignPattern.Factory.BeforeFactory;
using HeadFirstDesignPattern.Factory;

namespace UnitTestProject
{
    [TestClass]
    public class TestBeforeFactory
    {
        SimplePizzaFactory factory;
        PizzaStore store;

        [TestInitialize]
        public void Setup()
        {
            factory = new SimplePizzaFactory();
            store = new PizzaStore(factory);
        }
        #region TestCreatePizza
        static object[] CreatePizzaTestCase(string type, Pizza expext)
        {
            return new object[] { type, expext };
        }
        static StandardIngredientFactory standard_ingredient_factory = new StandardIngredientFactory();
        static object[] CreatePizzaTestData =
        {
            CreatePizzaTestCase("Cheese", new CheesePizza(standard_ingredient_factory)),
            CreatePizzaTestCase("Clam", new ClamPizza(standard_ingredient_factory)),
            CreatePizzaTestCase("Pepperoni", new PepperoniPizza(standard_ingredient_factory)),
            CreatePizzaTestCase("Vegetable", new VeggiePizza(standard_ingredient_factory)),
        };

        public TestContext TestContext { get; set; }
        [TestMethod]
        [TestCaseSource("CreatePizzaTestData")]
        public void TestCreatePizza()
        {
            TestContext.Run((string type, Pizza expect) =>
                {
                    Pizza pizza = factory.CreatePizza(type);
                    Assert.IsTrue(expect.GetType().Equals(pizza.GetType()), "Expect Class[{0}] Result Class[{1}]", expect.GetType().ToString(), pizza.GetType().ToString());
                });
        }
        #region orderPizza
        [TestMethod]
        [TestCaseSource("CreatePizzaTestData")]
        public void Test_orderPizza()
        {
            TestContext.Run((string type, Pizza expect) =>
            {
                Pizza pizza = store.orderPizza(type);
                Assert.IsTrue(expect.GetType().Equals(pizza.GetType()), "Expect Class[{0}] Result Class[{1}]",expect.GetType().ToString(), pizza.GetType().ToString());
            });
        }

        #endregion
        #endregion
    }
}
