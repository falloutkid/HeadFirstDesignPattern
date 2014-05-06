using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Singleton
{
    public class Singleton
    {
        private static Singleton unique_instance;
        private Singleton() { }
        public static Singleton getInstance()
        {
            if(unique_instance == null)
            {
                unique_instance = new Singleton();
            }
            return unique_instance;
        }

        public Singleton Instance
        {
            get
            {
                if (unique_instance == null)
                {
                    unique_instance = new Singleton();
                }
                return unique_instance;
            }
        }
    }

    public class ChocolateBoilder
    {
        private bool empty;
        public bool isEmpty { get { return empty; } }
        private bool boild;
        public bool isBoild { get { return boild; } }

        private static readonly System.Object sync_object = new object();

        private static ChocolateBoilder unique_instance;
        private ChocolateBoilder()
        {
            empty = true;
            boild = false;
        }

        public static ChocolateBoilder getInstance()
        {
            lock (sync_object)
            {
                if (unique_instance == null)
                    unique_instance = new ChocolateBoilder();
            }
            return unique_instance;
        }

        public void fill()
        {
            lock (sync_object)
            {
                if (empty)
                {
                    empty = false;
                    boild = false;
                }
            }
        }

        public void drain()
        {
            lock (sync_object)
            {
                if (!empty && boild)
                    empty = true;
            }
        }
        public void boil()
        {
            lock (sync_object)
            {
                if (!empty && !boild)
                    boild = true;
            }
        }
    }
}
