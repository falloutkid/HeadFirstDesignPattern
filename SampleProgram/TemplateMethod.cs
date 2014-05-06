using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.TemplateMethod.First
{
    public abstract class CaffeineBeverage
    {
        public void BoilWater()
        {
            Console.WriteLine( "お湯を沸かします");
        }

        public void PourInCup()
        {
            Console.WriteLine(  "カップに注ぎます");
        }
    }

    public class Coffee:CaffeineBeverage
    {
    }
}

namespace HeadFirstDesignPattern.TemplateMethod.Second
{
    #region CaffeineBeverage
    public abstract class CaffeineBeverage
    {
        public string PrepareRecipe()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BoilWater());
            sb.Append(Brew());
            sb.Append(PourInCup());
            sb.Append(AddCondiments());

            return sb.ToString();
        }

        public abstract string Brew();
        public abstract string AddCondiments();

        string BoilWater()
        {
            return "お湯を沸かします\n";
        }

        string PourInCup()
        {
            return "カップに注ぎます\n";
        }
    }

    public class Coffee : CaffeineBeverage
    {
        public override string Brew()
        {
            return "フィルターを通してコーヒーを淹れる\n";
        }

        public override string AddCondiments()
        {
            return "砂糖とミルクを入れる\n";
        }
    }

    public class Tea : CaffeineBeverage
    {
        public override string Brew()
        {
            return "沸騰したお湯にティーパックを浸す\n";
        }

        public override string AddCondiments()
        {
            return "レモンを加える\n";
        }
    }
    #endregion

    #region CaffeineBeverageWithHook
    public abstract class CaffeineBeverageWithHook
    {
        public string PrepareRecipe()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(BoilWater());
            sb.Append(Brew());
            sb.Append(PourInCup());
            if(customerWantsCondition())
                sb.Append(AddCondiments());

            return sb.ToString();
        }

        public abstract string Brew();
        public abstract string AddCondiments();

        string BoilWater()
        {
            return "お湯を沸かします\n";
        }

        string PourInCup()
        {
            return "カップに注ぎます\n";
        }

        public virtual bool customerWantsCondition()
        {
            return true;
        }
    }

    public class CoffeeWithHook : CaffeineBeverageWithHook
    {
        private bool customer_condition_slelct;
        public bool IsAddMilkAndSugar 
        {
            set { customer_condition_slelct = value; }
            get { return customer_condition_slelct; }
        }
        public override string Brew()
        {
            return "フィルターを通してコーヒーを淹れる\n";
        }

        public override string AddCondiments()
        {
            return "砂糖とミルクを入れる\n";
        }

        public override bool customerWantsCondition()
        {
            return customer_condition_slelct;
        }
    }
    #endregion
}
