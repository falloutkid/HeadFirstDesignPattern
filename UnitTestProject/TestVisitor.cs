using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPattern.Visitor;

namespace UnitTestProject
{
    [TestClass]
    public class TestVisitor
    {
        [TestMethod]
        public void TestMethod()
        {
            ObjectStructure object_structure = new ObjectStructure();
            object_structure.Attach(new ConcreteElementA());
            object_structure.Attach(new ConcreteElementB());

            // Create visitor objects
            ConcreteVisitor1 visitor1 = new ConcreteVisitor1();
            ConcreteVisitor2 visitor2 = new ConcreteVisitor2();

            // Structure accepting visitors
            object_structure.Accept(visitor1);
            object_structure.Accept(visitor2);
        }
    }
}
