using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Memento;

namespace UnitTestProject
{
    [TestClass]
    public class TestMemento
    {
        [TestMethod]
        public void TestMethod1()
        {
            Originator originator = new Originator();
            originator.State = "On";

            // Store internal state
            Caretaker c = new Caretaker();
            c.Memento = originator.CreateMemento();

            // Continue changing originator
            originator.State = "Off";

            // Restore saved state
            originator.SetMemento(c.Memento);
        }
    }
}
