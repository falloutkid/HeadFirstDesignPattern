using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Adapter
{
    #region Duck
    public interface Duck
    {
        void quack();
        void fly();
    }
    public class MallardDuck:Duck
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("ガーガー");
        }

        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("飛んでいます");
        }
    }

    #region DuckAdapter
    public class DuckAdapter : Turkey
    {
        Duck duck_;
        Random random;
        public DuckAdapter(Duck duck)
        {
            duck_ = duck;
            random = new Random();
        }
        public void gobble()
        {
            duck_.quack();
        }

        public void fly()
        {
            if(random.Next(0, 5) == 0)
                duck_.fly();
        }
    }
    #endregion
    #endregion

    #region Turkey
    public interface Turkey
    {
        void gobble();
        void fly();
    }
    public class WildTurkey : Turkey
    {
        public void gobble()
        {
            System.Diagnostics.Debug.WriteLine("ゴロゴロ");
        }

        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("短い距離を飛んでいます");
        }
    }

    #region TurkeyAdapter
    public class TurkeyAdapter:Duck
    {
        Turkey turkey_;
        public TurkeyAdapter(Turkey turkey)
        {
            turkey_ = turkey;
        }
        public void quack()
        {
            turkey_.gobble();
        }

        public void fly()
        {
            for (int i = 0; i < 5; i++)
                turkey_.fly();
        }
    }
    #endregion

    #endregion

    
}
