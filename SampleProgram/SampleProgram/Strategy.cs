using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Strategy
{
    #region Quack
    public interface IQuackBehavior
    {
        void quack();
    }

    public class Quack :IQuackBehavior
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("ガーガー!");
        }
    }

    public class Squack : IQuackBehavior
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("キューキュー!");
        }
    }

    public class MuteQuack : IQuackBehavior
    {
        public void quack()
        {
            System.Diagnostics.Debug.WriteLine("鳴かない");
        }
    }
#endregion

    #region fly
    public interface IFlyBehavior
    {
        void fly();
    }

    public class FlyWithWing:IFlyBehavior
    {
        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("空を飛ぶ!");
        }
    }

    public class FlyNoWay : IFlyBehavior
    {
        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("飛べない");
        }
    }

    public class FlyRocketPowered:IFlyBehavior
    {
        public void fly()
        {
            System.Diagnostics.Debug.WriteLine("ロケットで飛んでいます");
        }
    }
    #endregion

    public abstract class Duck
    {
        protected IQuackBehavior quack_behavior_;
        protected IFlyBehavior fly_behavior_;

        public void quack()
        {
            quack_behavior_.quack();
        }
        public void swim()
        {

        }
        public abstract void display();
        public void fly()
        {
            fly_behavior_.fly();
        }
    }

    public class MallardDuck:Duck
    {
        public MallardDuck()
        {
            quack_behavior_ = new Quack();
            fly_behavior_ = new FlyWithWing();
        }

        public override void display()
        {
            System.Diagnostics.Debug.WriteLine("マガモ(mallard)");
        }
    }

    public class RedheadDuck : Duck
    {
        public RedheadDuck()
        {
            quack_behavior_ = new Quack();
            fly_behavior_ = new FlyWithWing();
        }
        public override void display()
        {
            System.Diagnostics.Debug.WriteLine("アメリカホシハジロ(Redhead)");
        }
    }

    public class RubberDuck : Duck
    {
        public RubberDuck()
        {
            quack_behavior_ = new Squack();
            fly_behavior_ = new FlyNoWay();
        }
        public override void display()
        {
            System.Diagnostics.Debug.WriteLine("ゴム製の鴨(Rubber)");
        }
    }

    public class ModelDuck : Duck
    {
        public ModelDuck()
        {
            quack_behavior_ = new MuteQuack();
            fly_behavior_ = new FlyNoWay();
        }
        public override void display()
        {
            System.Diagnostics.Debug.WriteLine("模型の鴨(Model)");
        }

        public void setFlyBehavior(IFlyBehavior fly_behavior)
        {
            fly_behavior_ = fly_behavior;
        }
    }
}

