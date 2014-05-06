using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.ChainOfResponsibility
{
    #region 組み立て処理抽象クラス
    public abstract class CarHandler
    {
        public const int STEP_HANDLE_HEAD = 0;
        public const int STEP_HANDLE_BODY = 1;
        public const int STEP_HANDLE_TAIL = 2;
        public const int STEP_HANDLE_COLOR = 3;

        protected CarHandler carHandler;

        //チェーンの次のオブジェクトをセットする  
        public CarHandler setNextCarHandler(CarHandler carHandler)
        {
            this.carHandler = carHandler;

            return this.carHandler;
        }

        //メッセージを処理するメソッド  
        abstract public void handleCar(int lastStep);
    }
    #endregion
    //ヘッダーの組み立て処理クラス  
    public class CarHeadHandler : CarHandler
    { 
        public override void handleCar(int lastStep)
        {
            if (STEP_HANDLE_HEAD <= lastStep)
            {
                //自分ができるものだけをする  
                System.Diagnostics.Debug.WriteLine("Handle car's head.");
            }

            //メッセージの終了条件  
            if (carHandler != null)
            {
                carHandler.handleCar(lastStep);
            }
        }
    }

    //ボディの組み立て処理クラス  
    public class CarBodyHandler : CarHandler
    {
        public override void handleCar(int lastStep)
        {
            if (STEP_HANDLE_BODY <= lastStep)
            {
                //自分ができるものだけをする  
                System.Diagnostics.Debug.WriteLine("Handle car's body.");
            }

            //メッセージの終了条件  
            if (carHandler != null)
            {
                carHandler.handleCar(lastStep);
            }
        }
    }

    //テールの組み立て処理クラス  
    public class CarTailHandler : CarHandler
    {
        public override void handleCar(int lastStep)
        {
            if (STEP_HANDLE_TAIL <= lastStep)
            {
                //自分ができるものだけをする  
                System.Diagnostics.Debug.WriteLine("Handle car's tail.");
            }

            //メッセージの終了条件  
            if (carHandler != null)
            {
                carHandler.handleCar(lastStep);
            }
        }
    }

    //塗装処理クラス  
    public class CarColorHandler : CarHandler
    {
        public override void handleCar(int lastStep)
        {
            if (STEP_HANDLE_COLOR == lastStep)
            {
                //自分ができるものだけをする  
                System.Diagnostics.Debug.WriteLine("Handle car's color.");
            }

            //メッセージの終了条件  
            if (carHandler != null)
            {
                carHandler.handleCar(lastStep);
            }
        }
    }
}
