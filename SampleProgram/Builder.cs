using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Builder
{
    //自動車クラス  
    public class Car
    {
        public String Body { set; get; }
        public String Head { set; get; }
        public String Tail { set; get; }
    }


    //自動車工場抽象クラス  
    public interface CarBuilder
    {
        void makeHead();
        void makeBody();
        void makeTail();
        Car getCar();
    }

    //Jeep工場クラス  
    public class JeepBuilder : CarBuilder
    {
        Car car = new Car();

        public void makeHead()
        {
            car.Head = "Jeep head";
        }
        public void makeBody()
        {
            car.Body = "Jeep body";
        }
        public void makeTail()
        {
            car.Tail = "Jeep tail";
        }

        public Car getCar()
        {
            return car;
        }
    }

    //自動車を組み立てクラス  
    public class CarDirector
    {
        public void makeCar(CarBuilder builder)
        {
            builder.makeHead();
            builder.makeBody();
            builder.makeTail();
        }
    }
}
