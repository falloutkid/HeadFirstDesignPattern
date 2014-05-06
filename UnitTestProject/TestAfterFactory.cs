using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using HeadFirstDesignPattern.Factory.AfterFactory;
using HeadFirstDesignPattern.Factory;

namespace UnitTestProject
{
    [TestClass]
    public class TestAfterFactory
    {
        public TestContext TestContext { get; set; }

        static object[] CreatePizzaTestCase(string type, Pizza expext)
        {
            return new object[] { type, expext };
        }

        PizzaStore store;
        
        #region NY Style
        static NYStyleIngredientFactory nystyle_ingredient_factory = new NYStyleIngredientFactory();
        static object[] CreateNYStylePizzaTestData =
        {
            CreatePizzaTestCase("Cheese", new CheesePizza(nystyle_ingredient_factory)),
            CreatePizzaTestCase("Clam", new ClamPizza(nystyle_ingredient_factory)),
            CreatePizzaTestCase("Pepperoni", new PepperoniPizza(nystyle_ingredient_factory)),
            CreatePizzaTestCase("Vegetable", new VeggiePizza(nystyle_ingredient_factory)),
        };
        
        [TestMethod]
        [TestCaseSource("CreateNYStylePizzaTestData")]
        public void TestNYStyleCreatePizza()
        {
            store = new NYStylePizzaStore();
            TestContext.Run((string type, Pizza expect) =>
                {
                    Pizza pizza = store.CreatePizza(type);
                    Assert.IsTrue(expect.GetType().Equals(pizza.GetType()), "Expect Class[{0}] Result Class[{1}]", expect.GetType().ToString(), pizza.GetType().ToString());
                });
        }
        #region orderPizza
        [TestMethod]
        [TestCaseSource("CreateNYStylePizzaTestData")]
        public void TestNYStyleorderPizza()
        {
            store = new NYStylePizzaStore();
            TestContext.Run((string type, Pizza expect) =>
            {
                Pizza pizza = store.orderPizza(type);
                Assert.IsTrue(expect.GetType().Equals(pizza.GetType()), "Expect Class[{0}] Result Class[{1}]", expect.GetType().ToString(), pizza.GetType().ToString());
            });
        }

        #endregion
        #endregion

        #region Chicago Style
        static ChicagoStyleIngredientFactory chicagostyle_ingredient_factory = new ChicagoStyleIngredientFactory();
        static object[] CreateChicagoStylePizzaTestData =
        {
            CreatePizzaTestCase("Cheese", new CheesePizza(chicagostyle_ingredient_factory)),
            CreatePizzaTestCase("Clam", new ClamPizza(chicagostyle_ingredient_factory)),
            CreatePizzaTestCase("Pepperoni", new PepperoniPizza(chicagostyle_ingredient_factory)),
            CreatePizzaTestCase("Vegetable", new VeggiePizza(chicagostyle_ingredient_factory)),
        };

        [TestMethod]
        [TestCaseSource("CreateChicagoStylePizzaTestData")]
        public void TestChicagoStyleCreatePizza()
        {
            store = new ChicagoStylePizzaStore();
            TestContext.Run((string type, Pizza expect) =>
            {
                Pizza pizza = store.CreatePizza(type);
                Assert.IsTrue(expect.GetType().Equals(pizza.GetType()), "Expect Class[{0}] Result Class[{1}]", expect.GetType().ToString(), pizza.GetType().ToString());
            });

        }

        #region orderPizza
        [TestMethod]
        [TestCaseSource("CreateChicagoStylePizzaTestData")]
        public void TestChicagoStyleorderPizza()
        {
            store = new ChicagoStylePizzaStore();
            TestContext.Run((string type, Pizza expect) =>
            {
                Pizza pizza = store.orderPizza(type);
                Assert.IsTrue(expect.GetType().Equals(pizza.GetType()), "Expect Class[{0}] Result Class[{1}]", expect.GetType().ToString(), pizza.GetType().ToString());
            });
        }

        #endregion
        #endregion
    }
}
