using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Flyweight
{
    public class Stamp
    {
        string type;
        public Stamp(string type)
        {
            this.type = type;
        }
        public void print()
        {
            System.Diagnostics.Debug.WriteLine(this.type);
        }
    }

    public class StampFactory
    {
        Dictionary<string, Stamp> pool;
        public StampFactory()
        {
            this.pool = new Dictionary<string, Stamp>();
        }
        public Stamp get(string type)
        {
            if(pool.ContainsKey(type) == false)
            {
                this.pool.Add(type, new Stamp(type));
            }
            return pool[type];
        }
    }
}
