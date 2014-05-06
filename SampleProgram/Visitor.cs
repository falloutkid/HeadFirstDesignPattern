using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Visitor
{
    #region Visitor
    public abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);
        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }
    #endregion

    #region ConcreteVisitor
    public class ConcreteVisitor1 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name));
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name));
        }
    }

    public class ConcreteVisitor2 : Visitor
    {
        public override void VisitConcreteElementA(ConcreteElementA concreteElementA)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} visited by {1}", concreteElementA.GetType().Name, this.GetType().Name));
        }

        public override void VisitConcreteElementB(ConcreteElementB concreteElementB)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("{0} visited by {1}", concreteElementB.GetType().Name, this.GetType().Name));
        }
    }
    #endregion

    #region Element
    public abstract class Element
    {
        public abstract void Accept(Visitor visitor);
    }
    #endregion

    #region ConcreteElement
    public class ConcreteElementA : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementA(this);
        }

        public void OperationA()
        {
        }
    }

    public class ConcreteElementB : Element
    {
        public override void Accept(Visitor visitor)
        {
            visitor.VisitConcreteElementB(this);
        }

        public void OperationB()
        {
        }
    }
    #endregion

    #region ObjectStructure
    public class ObjectStructure
    {
        private List<Element> elements_ = new List<Element>();

        public void Attach(Element element)
        {
            elements_.Add(element);
        }

        public void Detach(Element element)
        {
            elements_.Remove(element);
        }

        public void Accept(Visitor visitor)
        {
            foreach (Element element in elements_)
            {
                element.Accept(visitor);
            }
        }
    }
    #endregion
}
