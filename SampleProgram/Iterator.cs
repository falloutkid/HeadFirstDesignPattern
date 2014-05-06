using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeadFirstDesignPattern;

namespace HeadFirstDesignPattern.Iterator
{
    public interface Iterator
    {
        bool HasNext();
        Object Next();
        void Remove();
    }

    public interface Menu
    {
        Iterator createIterator();
    }

    public class MenuItem
    {
        string name_;
        string description_;
        bool vegetarian_;
        double price_;

        public string Name { get { return name_; } }
        public string Description { get { return description_; } }
        public bool Vegitarian { get { return vegetarian_; } }
        public double Price {get{return price_;}}

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            name_ = name;
            description_ = description;
            vegetarian_ = vegetarian;
            price_ = price;
        }
    }

    public class PancakeHouseMenu : Menu
    {
        List<MenuItem> menu_items_;

        public PancakeHouseMenu()
        {
            menu_items_ = new List<MenuItem>();

            AddItem("K&B's Pancake Breakfast",
                "Pancakes with scrambled eggs, and toast",
                true,
                2.99);
            AddItem("Regular Pancake Breakfast",
                "Pancakes with fried eggs, and sausage",
                false,
                2.99);
            AddItem("Blueberry Pancakes",
                "Pancakes made with fresh blueberries",
                true,
                3.49);
            AddItem("Waffles",
                "Waffles, with your choice of blueberries or strawberries",
                true,
                3.59);
        }

        public void AddItem(string name, string description, bool isVegetarian, double price)
        {
            MenuItem menu_item = new MenuItem(name, description, isVegetarian, price);
            menu_items_.Add(menu_item);
        }

        /*
        public List<MenuItem> getMenuItems()
        {
            return menu_items_;
        }
        */
        public Iterator createIterator()
        {
            return new PancakeHouseMenuIterator(menu_items_);
        }
    }

    public class PancakeHouseMenuIterator:Iterator
    {
        List<MenuItem> menu_items_;
        int position = 0;

        public PancakeHouseMenuIterator(List<MenuItem> items)
        {
            menu_items_ = items;   
        }

        public bool HasNext()
        {
            if (position >= menu_items_.Count || menu_items_[position] == null)
                return false;
            return true;
        }
        public Object Next()
        {
            MenuItem menu_item = menu_items_[position];
            position++;
            return menu_item;
        }

        public void Remove()
        {
            if (position <= 0)
                throw new Exception("最低1回はNext関数を呼ばないといけません");
            if (menu_items_[position - 1] != null)
                menu_items_.RemoveRange(position - 1, menu_items_.Count - position);
        }
    }

    public class DinnerMenu : Menu
    {
        static int MAX_ITEMS = 6;
        int numberOfItems = 0;
        MenuItem[] menu_items_;

        public DinnerMenu()
        {
            menu_items_ = new MenuItem[MAX_ITEMS];

            AddItem("Vegetarian BLT",
                "(Fakin') Bacon with lettuce & tomato on whole wheat",
                true,
                2.99);
            AddItem("BLT",
                "Bacon with lettuce & tomato on whole wheat",
                false,
                2.99);
            AddItem("Soup of the day",
                "Soup of the day, with a side of potato salad",
                false,
                3.29);
            AddItem("Hotdog",
                "A hot dog with saurkraut, relish, onions, topped with cheese",
                false,
                3.05);
            AddItem("Steamed Veggies and Brown Rice",
                "Steamed vegetables over brown rice",
                true,
                3.99);
            AddItem("Pasta",
                "Spaghetti with Marina Sauce and a slice of sourdough bread",
                true,
                3.89);
        }

        public void AddItem(string name, string description, bool isVegetarian, double price)
        {
            MenuItem menuItem = new MenuItem(name, description, isVegetarian, price);
            if (numberOfItems >= MAX_ITEMS)
            {
                System.Diagnostics.Debug.WriteLine("Sorry, menu is full! Can't add item to menu");
            }
            else
            {
                menu_items_[numberOfItems] = menuItem;
                numberOfItems += 1;
            }
        }

        /*
        public MenuItem[] getMenuItems()
        {
            return menu_items_;
        }
        */
        public Iterator createIterator()
        {
            return new DinnerMenuIterator(menu_items_);
        }

    }

    public class DinnerMenuIterator:Iterator
    {
        MenuItem[] items_;
        int position;

        public DinnerMenuIterator(MenuItem[] items)
        {
            items_ = items;   
        }

        public bool HasNext()
        {
            if (position >= items_.Length || items_[position] == null)
                return false;
            return true;
        }

        public object Next()
        {
            MenuItem menu_item = items_[position];
            position++;
            return menu_item;
        }

        public void Remove()
        {
            if (position <= 0)
                throw new Exception("最低1回はNext関数を呼ばないといけません");
            if(items_[position - 1]!= null)
            {
                for(int index = position-1;index <items_.Length - 1;index++)
                {
                    items_[index] = items_[index + 1];
                }
                items_[items_.Length - 1] = null;
            }
        }
    }

    public class CafeMenu:Menu
    {
        Dictionary<int, MenuItem> menu_items_ = new Dictionary<int, MenuItem>();

        public CafeMenu()
        {
            AddItem("Veggie Burger and Air Fries",
                "Veggie burger on a whole wheat bun, lettuce, tomato, and fries",
                true, 3.99, 1);
            AddItem("Soup of the Day",
                "A cup of the soup of the day, with a side salad",
                false, 3.69, 2);
            AddItem("Burrito",
                "A large burrito, with whole pinto beans, salsa, guacamole",
                true, 4.29, 3);
        }

        public void AddItem(string name, string description, bool isVegetarian, double price, int index)
        {
            MenuItem menu_item = new MenuItem(name, description, isVegetarian, price);
            menu_items_.Add(index, menu_item);
        }

        public Iterator createIterator()
        {
            return new CafeMenuIterator(menu_items_);
        }
    }

    public class CafeMenuIterator:Iterator
    {
        private Dictionary<int, MenuItem> menu_items_;
        int position;

        public CafeMenuIterator(Dictionary<int, MenuItem> menu_items)
        {
            position = 1;
            this.menu_items_ = menu_items;
        }
        public bool HasNext()
        {
            if (position >= menu_items_.Count || menu_items_[position] == null)
                return false;
            return true;
        }

        public Object Next()
        {
            MenuItem menu_item = menu_items_[position];
            position++;
            return menu_item;
        }

        public void Remove()
        {
            if (position <= 0)
                throw new Exception("最低1回はNext関数を呼ばないといけません");
            if (menu_items_[position - 1] != null)
            {
                for (int remove_index = position - 1; remove_index < menu_items_.Count; remove_index++)
                    menu_items_.Remove(remove_index);
            }
        }
    }

    public class Waitress
    {
        Menu pancake_house_menu_;
        Menu dinner_menu_;
        Menu cafe_menu_;

        public Waitress(Menu pancakeHouse_menu, Menu dinner_menu, Menu cafe_menu)
        {
            pancake_house_menu_ = pancakeHouse_menu;
            dinner_menu_ = dinner_menu;
            cafe_menu_ = cafe_menu;
        }

        public void PrintMenu()
        {
            Iterator pancake_iterator = pancake_house_menu_.createIterator();
            Iterator dinner_iterator = dinner_menu_.createIterator();
            Iterator cafe_iterator = cafe_menu_.createIterator();

            System.Diagnostics.Debug.WriteLine("メニュー\n-----------------------------------\n朝食");
            PrintMenu(pancake_iterator);
            System.Diagnostics.Debug.WriteLine("カフェメニュー");
            PrintMenu(cafe_iterator);
            System.Diagnostics.Debug.WriteLine("夕食");
            PrintMenu(dinner_iterator);
            
        }

        private void PrintMenu(Iterator menu_iterator)
        {
            while (menu_iterator.HasNext())
            {
                MenuItem menu_item = (MenuItem)menu_iterator.Next();
                System.Diagnostics.Debug.WriteLine(menu_item.Name + ", ");
                System.Diagnostics.Debug.WriteLine(menu_item.Price + " -- ");
                System.Diagnostics.Debug.WriteLine(menu_item.Description + "\n");
            }
        }
    }
}
