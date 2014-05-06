using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Bridge
{
    #region Abstraction
    //自動車抽象クラス  
    public abstract class Car
    {
        public SetCarEngine setCarEngine;

        public abstract void setEngine();
    }
    #endregion

    #region RefinedAbstraction
    //トラック 
    public class Truck : Car
    {
        public Truck(SetCarEngine setCarEngine)
        {
            this.setCarEngine = setCarEngine;
        }

        public override void setEngine()
        {
            System.Diagnostics.Debug.WriteLine("Set Truck Engine: ");

            setCarEngine.setEngine();
        }
    }

    //バス
    public class Bus : Car
    {
        public Bus(SetCarEngine setCarEngine)
        {
            this.setCarEngine = setCarEngine;
        }

        public override void setEngine()
        {
            System.Diagnostics.Debug.WriteLine("Set Bus Engine: ");
            setCarEngine.setEngine();
        }
    }
    #endregion

    #region Implementor
    //エンジンの設置機能の抽象インタフェース
    public interface SetCarEngine
    {
        void setEngine();
    }
    #endregion

    #region ConcreteImplementor
    //1500cc設置機能クラス
    public class SetCarEngine1500cc : SetCarEngine
    {
        public void setEngine()
        {
            System.Diagnostics.Debug.WriteLine("1500cc");
        }
    }

    //2000cc設置機能クラス
    public class SetCarEngine2000cc : SetCarEngine
    {
        public void setEngine()
        {
            System.Diagnostics.Debug.WriteLine("2000cc");
        }
    }
    #endregion
}
