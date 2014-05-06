using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.Builder;

namespace UnitTestProject
{
    [TestClass]
    public class TestBuilder
    {
        [TestMethod]
        public void TestMethod()
        {
            CarDirector director = new CarDirector();

            //Jeepを製造する工場  
            CarBuilder jeep_builder = new JeepBuilder();
            //自動車を組み立て  
            director.makeCar(jeep_builder);

            //製造された自動車情報  
            Car car = jeep_builder.getCar();

            System.Diagnostics.Debug.WriteLine(car.Head);
            System.Diagnostics.Debug.WriteLine(car.Body);
            System.Diagnostics.Debug.WriteLine(car.Tail);
        }
    }
}
