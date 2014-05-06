using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Mediator;

namespace UnitTestProject
{
    [TestClass]
    public class TestMediator
    {
        [TestMethod]
        public void TestMethod()
        {
            ConcreteMediator m = new ConcreteMediator();

            ConcreteColleague1 concrete_colleague1 = new ConcreteColleague1(m);
            ConcreteColleague2 concrete_colleague2 = new ConcreteColleague2(m);

            m.Colleague1 = concrete_colleague1;
            m.Colleague2 = concrete_colleague2;

            concrete_colleague1.Send("How are you?");
            concrete_colleague2.Send("Fine, thanks");
        }
    }
}
