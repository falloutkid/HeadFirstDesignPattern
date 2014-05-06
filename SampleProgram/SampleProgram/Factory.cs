using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Factory
{
    #region Pizza
    #region Topping
    public interface Topping
    {
        string ToppingName { get; }
    }
    public class ReggianoCheese:Topping
    {
        public string ToppingName
        {
            get
            {
                return "レッジャーノチーズ";
            }
        }
    }
    public class Garlic : Topping
    {
        public string ToppingName
        {
            get
            {
                return "にんにく";
            }
        }
    }

    public class  Mushroom: Topping
    {
        public string ToppingName
        {
            get
            {
                return "きのこ";
            }
        }
    }

    public class  Onion: Topping
    {
        public string ToppingName
        {
            get
            {
                return "たまねぎ";
            }
        }
    }

    public class  Cram: Topping
    {
        public string ToppingName
        {
            get
            {
                return "ハマグリ";
            }
        }
    }

    public class FreshCram : Topping
    {
        public string ToppingName
        {
            get
            {
                return "新鮮なハマグリ";
            }
        }
    }

    public class  RedChili: Topping
    {
        public string ToppingName
        {
            get
            {
                return "赤唐辛子";
            }
        }
    }

    public class  Pepperoni: Topping
    {
        public string ToppingName
        {
            get
            {
                return "ペパロニ";
            }
        }
    }

    public class  Oregano: Topping
    {
        public string ToppingName
        {
            get
            {
                return "オレガノ";
            }
        }
    }
    public class  Eggplant: Topping
    {
        public string ToppingName
        {
            get
            {
                return "なす";
            }
        }
    }

    public class  Spinach: Topping
    {
        public string ToppingName
        {
            get
            {
                return "ほうれん草";
            }
        }
    }

    public class  BlackOlives: Topping
    {
        public string ToppingName
        {
            get
            {
                return "ブラックオリーブ";
            }
        }
    }

    public class  MozzarellaCheese: Topping
    {
        public string ToppingName
        {
            get
            {
                return "モッツァレラチーズ";
            }
        }
    }

    public class  ParmesanCheese: Topping
    {
        public string ToppingName
        {
            get
            {
                return "パルメザンチーズ";
            }
        }
    }
    #endregion

    #region Sauce
    public interface Sauce
    {
        string SauceName { get; }
    }

    public class MarinaraSauce:Sauce
    {
        public string SauceName
        {
            get
            {
                return "マリナラソース";
            }
        }
    }

    public class PlumTomatoSauce : Sauce
    {
        public string SauceName
        {
            get
            {
                return "プラムトマトソース";
            }
        }
    }

    public class TomatoSauce : Sauce
    {
        public string SauceName
        {
            get
            {
                return "トマトソース";
            }
        }
    }

    #endregion

    #region Douch
    public interface Douch
    {
        string DouchName { get; }
    }

    public class ThinCraftDouch : Douch
    {
        public string DouchName
        {
            get
            {
                return "薄いクラフト生地";
            }
        }
    }

    public class NormalDouch : Douch
    {
        public string DouchName
        {
            get
            {
                return "通常の生地";
            }
        }
    }
    #endregion

    public interface PizzaIngredientFactory
    {
        Dictionary<string, Topping> createTopping();
        Sauce createSauce();
        Douch createDouch();
    }

    public abstract class Pizza
    {
        protected string name;
        protected Douch douch;
        protected Sauce sauce;
        private List<Topping> toppings = new List<Topping>();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public void addTopping(Topping topping)
        {
            toppings.Add(topping);
        }

        public virtual void prepare()
        {
            //準備
            System.Diagnostics.Debug.WriteLine(string.Format("{0}を下処理",name));
            System.Diagnostics.Debug.WriteLine(string.Format("生地({0})をこねる....",douch.DouchName));
            System.Diagnostics.Debug.WriteLine(string.Format("{0}を追加....",sauce.SauceName));
            if (toppings.Count != 0)
            {
                System.Diagnostics.Debug.WriteLine("トッピングを追加:");
                foreach (Topping topping in toppings)
                {
                    System.Diagnostics.Debug.WriteLine(string.Format(" {0}", topping.ToppingName));
                }
            }
        }
        public virtual void bake()
        {
            // 焼く
            System.Diagnostics.Debug.WriteLine("350度で25分間焼く");
        }
        public virtual void cut()
        {
            // 切る
            System.Diagnostics.Debug.WriteLine("ピザを扇型に切る");
        }
        public virtual void box() 
        {
            // 箱詰め
            System.Diagnostics.Debug.WriteLine("PizzaStoreの正式な箱にピザを入れる");
        }
    }
    #region Pizza Style
    public class StandardIngredientFactory:PizzaIngredientFactory
    {
        Dictionary<string, Topping> toppings;
        public StandardIngredientFactory()
        {
            ReggianoCheese reggiano_cheese = new ReggianoCheese();
            Spinach spinach = new Spinach();
            Onion onion = new Onion();
            Mushroom mushroom = new Mushroom();
            Garlic garlic = new Garlic();
            Cram cram = new Cram();
            RedChili red_chili = new RedChili();
            Pepperoni pepperoni = new Pepperoni();
            Eggplant eggplant = new Eggplant();
            BlackOlives black_olive = new BlackOlives();

            toppings = new Dictionary<string, Topping>()
            {
                {"ReggianoCheese", reggiano_cheese},
                {"Spinach", spinach},
                {"Onion", onion},
                {"Mushroom", mushroom},
                {"Garlic", garlic},
                {"Cram",cram},
                {"RedChili",red_chili},
                {"Pepperoni", pepperoni},
                {"Eggplant", eggplant},
                {"BlackOlives",black_olive}
            };
        }
        public Sauce createSauce()
        {
            return new TomatoSauce();
        }

        public Douch createDouch()
        {
            return new NormalDouch();
        }

        public Dictionary<string, Topping> createTopping()
        {
                        return toppings;
        }
    }

    
    public class NYStyleIngredientFactory : PizzaIngredientFactory
    {
        Dictionary<string, Topping> toppings;
        public NYStyleIngredientFactory()
        {
            ReggianoCheese reggiano_cheese = new ReggianoCheese();
            Spinach spinach = new Spinach();
            Onion onion = new Onion();
            Mushroom mushroom = new Mushroom();
            Garlic garlic = new Garlic();
            FreshCram cram = new FreshCram();
            RedChili red_chili = new RedChili();
            Pepperoni pepperoni = new Pepperoni();
            Eggplant eggplant = new Eggplant();
            BlackOlives black_olive = new BlackOlives();

            toppings = new Dictionary<string, Topping>()
            {
                {"ReggianoCheese", reggiano_cheese},
                {"Spinach", spinach},
                {"Onion", onion},
                {"Mushroom", mushroom},
                {"Garlic", garlic},
                {"Cram",cram},
                {"RedChili",red_chili},
                {"Pepperoni", pepperoni},
                {"Eggplant", eggplant},
                {"BlackOlives",black_olive}
            };
        }
        public Sauce createSauce()
        {
            return new MarinaraSauce();
        }

        public Douch createDouch()
        {
            return new ThinCraftDouch();
        }

        public Dictionary<string, Topping> createTopping()
        {
            return toppings;
        }
    }

    public class ChicagoStyleIngredientFactory : PizzaIngredientFactory
    {
        Dictionary<string, Topping> toppings;
        public ChicagoStyleIngredientFactory()
        {
            ReggianoCheese reggiano_cheese = new ReggianoCheese();
            MozzarellaCheese mozzarella_cheese = new MozzarellaCheese();
            Spinach spinach = new Spinach();
            Onion onion = new Onion();
            Mushroom mushroom = new Mushroom();
            Garlic garlic = new Garlic();
            Cram cram = new Cram();
            RedChili red_chili = new RedChili();
            Pepperoni pepperoni = new Pepperoni();
            Eggplant eggplant = new Eggplant();
            BlackOlives black_olive = new BlackOlives();

            toppings = new Dictionary<string, Topping>()
            {
                {"ReggianoCheese", reggiano_cheese},
                {"MozzarellaCheese", mozzarella_cheese},
                {"Spinach", spinach},
                {"Onion", onion},
                {"Mushroom", mushroom},
                {"Garlic", garlic},
                {"Cram",cram},
                {"RedChili",red_chili},
                {"Pepperoni", pepperoni},
                {"Eggplant", eggplant},
                {"BlackOlives",black_olive}
            };
        }
        public Sauce createSauce()
        {
            return new MarinaraSauce();
        }

        public Douch createDouch()
        {
            return new ThinCraftDouch();
        }

        public Dictionary<string, Topping> createTopping()
        {
            return toppings;
        }
    }
    #endregion

    public class CheesePizza : Pizza
    {
        public CheesePizza(PizzaIngredientFactory ingredient_factory)
        {
            douch = ingredient_factory.createDouch();
            sauce = ingredient_factory.createSauce();

            addTopping(ingredient_factory.createTopping()["ReggianoCheese"]);
            addTopping(ingredient_factory.createTopping()["Garlic"]);
        }
    }

    public class ClamPizza : Pizza
    {
        public ClamPizza(PizzaIngredientFactory ingredient_factory)
        {
            douch = ingredient_factory.createDouch();
            sauce = ingredient_factory.createSauce();

            addTopping(ingredient_factory.createTopping()["Cram"]);
        }
    }

    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza(PizzaIngredientFactory ingredient_factory)
        {
            douch = ingredient_factory.createDouch();
            sauce = ingredient_factory.createSauce();

            addTopping(ingredient_factory.createTopping()["Pepperoni"]);
            addTopping(ingredient_factory.createTopping()["RedChili"]);
        }
    }

    public class VeggiePizza : Pizza
    {
        public VeggiePizza(PizzaIngredientFactory ingredient_factory)
        {
            douch = ingredient_factory.createDouch();
            sauce = ingredient_factory.createSauce();

            addTopping(ingredient_factory.createTopping()["Onion"]);
            addTopping(ingredient_factory.createTopping()["Mushroom"]);
            addTopping(ingredient_factory.createTopping()["Garlic"]);
            addTopping(ingredient_factory.createTopping()["Spinach"]);
            addTopping(ingredient_factory.createTopping()["BlackOlives"]);
        }
    }
    #endregion
}

namespace HeadFirstDesignPattern.Factory.BeforeFactory
{
    public class SimplePizzaFactory
    {
        public Pizza CreatePizza(string type)
        {
            Pizza retrun_value = null;
            StandardIngredientFactory ingredient_factory = new StandardIngredientFactory();
            if(type.Equals("Cheese"))
            {
                retrun_value = new CheesePizza(ingredient_factory);
                retrun_value.Name = "チーズピザ";
            }
            else if (type.Equals("Clam"))
            {
                retrun_value = new ClamPizza(ingredient_factory);
                retrun_value.Name = "クラムピザ";
            }
            else if (type.Equals("Pepperoni"))
            {
                retrun_value = new PepperoniPizza(ingredient_factory);
                retrun_value.Name = "ペパロニピザ";
            }
            else if (type.Equals("Vegetable"))
            {
                retrun_value = new VeggiePizza(ingredient_factory);
                retrun_value.Name = "ベジタブルピザ";
            }
            return retrun_value;
        }
    }

    public class PizzaStore
    {
        SimplePizzaFactory factory_;
        public PizzaStore(SimplePizzaFactory factory)
        {
            factory_ = factory;
        }


        public Pizza orderPizza(string type)
        {
            Pizza pizza = factory_.CreatePizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }
    }
}

namespace HeadFirstDesignPattern.Factory.AfterFactory
{
    public abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }

        public virtual Pizza CreatePizza(string type)
        {
            BeforeFactory.SimplePizzaFactory factory = new BeforeFactory.SimplePizzaFactory();
            return factory.CreatePizza(type);
        }
    }

    public class NYStylePizzaStore:PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza retrun_value = null;
            NYStyleIngredientFactory ingredient_factory = new NYStyleIngredientFactory();
            if (type.Equals("Cheese"))
            {
                retrun_value = new CheesePizza(ingredient_factory);
                retrun_value.Name = "ニューヨークスタイルチーズピザ";
            }
            else if (type.Equals("Clam"))
            {
                retrun_value = new ClamPizza(ingredient_factory);
                retrun_value.Name = "ニューヨークスタイルクラムピザ";
            }
            else if (type.Equals("Pepperoni"))
            {
                retrun_value = new PepperoniPizza(ingredient_factory);
                retrun_value.Name = "ニューヨークスタイルペパロニピザ";
            }
            else if (type.Equals("Vegetable"))
            {
                retrun_value = new VeggiePizza(ingredient_factory);
                retrun_value.Name = "ニューヨークスタイルベジタブルピザ";
            }
            return retrun_value;
        }
    }

    public class ChicagoStylePizzaStore : PizzaStore
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza retrun_value = null;
            ChicagoStyleIngredientFactory ingredient_factory = new ChicagoStyleIngredientFactory();
            if (type.Equals("Cheese"))
            {
                retrun_value = new CheesePizza(ingredient_factory);
                retrun_value.Name = "シカゴスタイルチーズピザ";
            }
            else if (type.Equals("Clam"))
            {
                retrun_value = new ClamPizza(ingredient_factory);
                retrun_value.Name = "シカゴスタイルクラムピザ";
            }
            else if (type.Equals("Pepperoni"))
            {
                retrun_value = new PepperoniPizza(ingredient_factory);
                retrun_value.Name = "シカゴスタイルペパロニピザ";
            }
            else if (type.Equals("Vegetable"))
            {
                retrun_value = new VeggiePizza(ingredient_factory);
                retrun_value.Name = "シカゴスタイルベジタブルピザ";
            }
            return retrun_value;
        }
    }
}
