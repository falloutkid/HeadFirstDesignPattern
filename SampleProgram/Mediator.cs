using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Mediator
{
    public abstract class Mediator
    {
        public abstract void Send(string message, Colleague colleague);
    }

    #region The 'ConcreteMediator' class
    public class ConcreteMediator : Mediator
    {
        private ConcreteColleague1 colleague1_;
        private ConcreteColleague2 colleague2_;

        public ConcreteColleague1 Colleague1
        {
            set { colleague1_ = value; }
        }

        public ConcreteColleague2 Colleague2
        {
            set { colleague2_ = value; }
        }

        public override void Send(string message, Colleague colleague)
        {
            if (colleague == colleague1_)
            {
                colleague2_.Notify(message);
            }
            else
            {
                colleague1_.Notify(message);
            }
        }
    }
    #endregion

    #region Colleague
    // abstract class
    public abstract class Colleague
    {
        protected Mediator mediator_;

        // Constructor
        public Colleague(Mediator mediator)
        {
            mediator_ = mediator;
        }
    }

    /// A 'ConcreteColleague' class
    public class ConcreteColleague1 : Colleague
    {
        public ConcreteColleague1(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator_.Send(message, this);
        }

        public void Notify(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Colleague1 gets message: " + message));
        }
    }

    /// A 'ConcreteColleague' class
    public class ConcreteColleague2 : Colleague
    {
        public ConcreteColleague2(Mediator mediator)
            : base(mediator)
        {
        }

        public void Send(string message)
        {
            mediator_.Send(message, this);
        }

        public void Notify(string message)
        {
            System.Diagnostics.Debug.WriteLine(string.Format("Colleague2 gets message: " + message));
        }
    }
    #endregion
}
