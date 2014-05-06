using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Composite;

namespace UnitTestProject
{
    [TestClass]
    public class TestComposite
    {
        [TestMethod]
        public void TestMethod()
        {
            MenuComponent pancake_house_menu = new Menu("パンケーキハウスメニュー", "朝食");
            MenuComponent dinner_menu = new Menu("食堂メニュー", "昼食");
            MenuComponent cafe_manu = new Menu("カフェメニュー", "夕食");
            MenuComponent desset_menu = new Menu("デザートメニュー", "もちろんデザート！");

            MenuComponent all_menus = new Menu("全てのメニュー", "全てを統合したメニュー");

            all_menus.Add(pancake_house_menu);
            all_menus.Add(dinner_menu);
            all_menus.Add(cafe_manu);

            dinner_menu.Add(new MenuItem("パスタ", "マリナラソースのかかったスパゲッティとサワードーパン", true, 3.89));

            dinner_menu.Add(desset_menu);

            desset_menu.Add(new MenuItem("アップルパイ","バニラアイスクリームをのせたフレーク状の生地のアップルパイ",true, 1.59));

            // ToDo:メニューの追加

            Waitress waitress = new Waitress(all_menus);

            System.Diagnostics.Debug.WriteLine(waitress.PrintMenu());
        }
    }
}
