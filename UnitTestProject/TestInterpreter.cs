using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPattern.Interpreter;

using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class TestInterpreter
    {
        [TestMethod]
        public void TestMethod()
        {
            String inputExpr = "10";

            Context context = new Context(inputExpr);

            List<AbstractExpression> list = new List<AbstractExpression>();

            list.Add(new PlusExpression());
            list.Add(new PlusExpression());
            list.Add(new MinusExpression());
            list.Add(new MinusExpression());
            list.Add(new MinusExpression());

            foreach (AbstractExpression expression in list)
            {
                expression.interpret(context);
            }

            System.Diagnostics.Debug.WriteLine(context.Output);
        }
    }
}
