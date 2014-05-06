using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Composite
{
    public abstract class MenuComponent
    {

        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual bool IsVegetarian { get; set; }
        public virtual double Price { get; set; }

        public virtual void Add(MenuComponent menuComponent)
        {
            throw new NotSupportedException("非対応");
        }

        public virtual void Remove(MenuComponent menuComponent)
        {
            throw new NotSupportedException("非対応");
        }

        public virtual MenuComponent GetChild(int index)
        {
            throw new NotSupportedException("非対応");
        }

        public virtual string Print()
        {
            throw new NotSupportedException("非対応");
        }

        public virtual List<MenuComponent> GetMenu()
        {
            throw new NotSupportedException("非対応");
        }

        public virtual int Count()
        {
            throw new NotSupportedException("非対応");
        }
    }

    public class MenuItem : MenuComponent
    {
        string name_;
        string description_;
        bool vegetarian_;
        double price_;

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            name_ = name;
            description_ = description;
            vegetarian_ = vegetarian;
            price_ = price;
        }

        public override string Name
        {
            get
            {
                return name_;
            }
            set
            {
                this.name_ = value;
            }
        }

        public override string Description
        {
            get
            {
                return description_;
            }
            set
            {
                this.description_ = value;
            }
        }

        public override double Price
        {
            get
            {
                return price_;
            }
            set
            {
                price_ = value;
            }
        }

        public override bool IsVegetarian
        {
            get
            {
                return vegetarian_;
            }
            set
            {
                this.vegetarian_ = value;
            }
        }

        public override string Print()
        {
            StringBuilder printOutPut = new StringBuilder();
            printOutPut.Append("\t" + Name);
            if (IsVegetarian)
            {
                printOutPut.Append(" (v) ");
            }
            printOutPut.Append(", $" + Price + "\n");
            printOutPut.Append("\t\t--" + Description + "\n");

            return printOutPut.ToString();
        }
    }

    public class Menu : MenuComponent
    {
        List<MenuComponent> menuComponents = new List<MenuComponent>();
        string name_;
        string description_;

        public Menu(string name, string description)
        {
            name_ = name;
            description_ = description;
        }

        public override string Name
        {
            get
            {
                return name_;
            }
            set
            {
                this.name_ = value;
            }
        }

        public override string Description
        {
            get
            {
                return description_;
            }
            set
            {
                this.description_ = value;
            }
        }

        public override void Add(MenuComponent menuComponent)
        {
            menuComponents.Add(menuComponent);
        }

        public override void Remove(MenuComponent menuComponent)
        {
            menuComponents.Remove(menuComponent);
        }

        public override MenuComponent GetChild(int i)
        {
            return menuComponents[i];
        }

        public override List<MenuComponent> GetMenu()
        {
            return menuComponents;
        }

        public override int Count()
        {
            return menuComponents.Count;
        }

        public override string Print()
        {
            StringBuilder printOutPut = new StringBuilder();
            printOutPut.Append("\n" + name_);
            printOutPut.Append(", " + description_ + "\n");
            printOutPut.Append("-------------------------\n");

            foreach (MenuComponent menuComponent in menuComponents)
            {
                printOutPut.Append(menuComponent.Print());
            }

            return printOutPut.ToString();
        }
    }

    public class Waitress
    {
        MenuComponent allMenus;

        public Waitress(MenuComponent allMenus)
        {
            this.allMenus = allMenus;
        }

        public string PrintMenu()
        {
            return allMenus.Print();
        }
    }

}
