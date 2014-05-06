using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.TemplateMethod;

using System.IO;

namespace UnitTestProject
{
    [TestClass]
    public class TestTemplateMethodFirst
    {
        HeadFirstDesignPattern.TemplateMethod.First.Coffee coffee;

        [TestInitialize]
        public void Setup()
        {
            coffee = new HeadFirstDesignPattern.TemplateMethod.First.Coffee();
        }

        [TestMethod]
        public void TestBoilWater()
        {
            string result;
            string expect = "お湯を沸かします";

            using (var memory_stream = new MemoryStream())
            using (var stream_writer = new StreamWriter(memory_stream))
            using (var text_writer = TextWriter.Synchronized(stream_writer))
            {
                // 標準出力の出力Streamを挿げ替える
                {
                    // 自動でMemoryStreamにFlush
                    stream_writer.AutoFlush = true;

                    Console.SetOut(text_writer);
                }

                // テストコードの実行
                coffee.BoilWater();

                // MemoryStreamから読み込む
                using (var stream_reader = new StreamReader(memory_stream))
                {
                    // ポジションが末尾になっているので先頭に変更
                    memory_stream.Position = 0;
                    result = stream_reader.ReadToEnd();
                }
            }

            // 標準出力の出力Streamを元に戻す
            using (var standard_output = new StreamWriter(Console.OpenStandardOutput()))
            {
                standard_output.AutoFlush = true;

                Console.SetOut(standard_output);
            }

            // 改行コードの削除
            result = result.Replace(Environment.NewLine, "");
            Assert.IsTrue(result.CompareTo(expect) == 0, "Expect[{0}], Result[{1}]", expect, result);
        }
    }

    [TestClass]
    public class TestTemplateMethodSecond
    {
        public TestContext TestContext{set;get;}

        HeadFirstDesignPattern.TemplateMethod.Second.Coffee coffee;
        HeadFirstDesignPattern.TemplateMethod.Second.Tea tea;

        HeadFirstDesignPattern.TemplateMethod.Second.CoffeeWithHook coffee_with_hook;
//        HeadFirstDesignPattern.TemplateMethod.Second.Tea tea;

        [TestInitialize]
        public void Setup()
        {
            coffee = new HeadFirstDesignPattern.TemplateMethod.Second.Coffee();
            tea = new HeadFirstDesignPattern.TemplateMethod.Second.Tea();

            coffee_with_hook = new HeadFirstDesignPattern.TemplateMethod.Second.CoffeeWithHook();
        }

        [TestMethod]
        public void Test_Coffee_PrepareRecipe()
        {
            string resutlt = coffee.PrepareRecipe();
            System.Diagnostics.Debug.WriteLine(resutlt);
        }
        [TestMethod]
        public void Test_Tea_PrepareRecipe()
        {
            string resutlt = tea.PrepareRecipe();
            System.Diagnostics.Debug.WriteLine(resutlt);
        }

        [TestMethod]
        public void Test_CoffeeWithHook_PrepareRecipe_AddMilkAndSugar()
        {
            coffee_with_hook.IsAddMilkAndSugar = true;
            string resutlt = coffee_with_hook.PrepareRecipe();
            System.Diagnostics.Debug.WriteLine(resutlt);
        }
        [TestMethod]
        public void Test_CoffeeWithHook_PrepareRecipe_Balck()
        {
            coffee_with_hook.IsAddMilkAndSugar = false;
            string resutlt = coffee_with_hook.PrepareRecipe();
            System.Diagnostics.Debug.WriteLine(resutlt);
        }
    }
}
