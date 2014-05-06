using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Decorator
{
    public abstract class Beverage
    {
        protected string description = "不明な飲み物";

        public virtual string GetDescription()
        {
            return description;
        }
        public abstract double cost();
    }

    public abstract class CondimentDecorator : Beverage
    {
        public abstract override string GetDescription();
    }

    #region Coffee
    public class Espresso : Beverage
    {
        public Espresso()
        {
            description = "エスプレッソ";
        }
        public override double cost()
        {
            return 1.99;
        }
    }

    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            description = "ダークロースト";
        }
        public override double cost()
        {
            return 0.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            description = "ハウスブレンド";
        }
        public override double cost()
        {
            return 0.89;
        }
    }

    public class Decaf : Beverage
    {
        public Decaf()
        {
            description = "カフェイン抜き";
        }
        public override double cost()
        {
            return 1.05;
        }
    }
    #endregion

    #region Toping
    public class Mocha:CondimentDecorator
    {
        Beverage beverage_;

        public Mocha(Beverage beverage)
        {
            beverage_ = beverage;
        }

        public override string GetDescription()
        {
            return beverage_.GetDescription() + "、モカ";
        }

        public override double cost()
        {
            return beverage_.cost() + 0.20;
        }
    }

    public class Soy : CondimentDecorator
    {
        Beverage beverage_;

        public Soy(Beverage beverage)
        {
            beverage_ = beverage;
        }

        public override string GetDescription()
        {
            return beverage_.GetDescription() + "、ソイ";
        }

        public override double cost()
        {
            return beverage_.cost() + 0.15;
        }
    }

    public class Milk : CondimentDecorator
    {
        Beverage beverage_;

        public Milk(Beverage beverage)
        {
            beverage_ = beverage;
        }

        public override string GetDescription()
        {
            return beverage_.GetDescription() + "、スチームミルク";
        }

        public override double cost()
        {
            return beverage_.cost() + 0.10;
        }
    }

    public class Whip : CondimentDecorator
    {
        Beverage beverage_;

        public Whip(Beverage beverage)
        {
            beverage_ = beverage;
        }

        public override string GetDescription()
        {
            return beverage_.GetDescription() + "、ホイップ";
        }

        public override double cost()
        {
            return beverage_.cost() + 0.10;
        }
    }
    #endregion
}

