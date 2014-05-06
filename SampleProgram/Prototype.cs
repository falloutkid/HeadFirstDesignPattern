using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Prototype
{
    #region 'Prototype' abstract class
    public abstract class Prototype
    {
        private string id_;

        // Constructor
        public Prototype(string id)
        {
            this.id_ = id;
        }

        // Gets id
        public string Id
        {
            get { return id_; }
        }

        public abstract Prototype Clone();
    }
    #endregion

    #region A 'ConcretePrototype' class
    public class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id)
            : base(id)
        {
        }

        // Returns a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    public class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id)
            : base(id)
        {
        }

        // Returns a shallow copy
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
    #endregion
}
