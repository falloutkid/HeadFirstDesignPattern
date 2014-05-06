using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HeadFirstDesignPattern.ChainOfResponsibility;

namespace UnitTestProject
{
    [TestClass]
    public class TestChainOfResponsibility
    {
        [TestMethod]
        public void TestMethod()
        {
            System.Diagnostics.Debug.WriteLine("---workfolow1----");
            //オブジェクトのチェーンを構造する  
            CarHandler carHandler1 = new CarHeadHandler();
            carHandler1.setNextCarHandler(
                    new CarBodyHandler()).setNextCarHandler(
                            new CarTailHandler()).setNextCarHandler(
                                    new CarColorHandler());

            //メッセージの送信開始  
            carHandler1.handleCar(CarHandler.STEP_HANDLE_COLOR);


            //ワークフロー2：テール　⇒　ボディ　⇒　ヘッダー　⇒　塗装  
            System.Diagnostics.Debug.WriteLine("---workfolow2---");
            //オブジェクトのチェーンを構造する  
            CarHandler carHandler2 = new CarTailHandler();
            carHandler2.setNextCarHandler(
                    new CarBodyHandler()).setNextCarHandler(
                            new CarHeadHandler()).setNextCarHandler(
                                    new CarColorHandler());

            //メッセージの送信開始  
            carHandler2.handleCar(CarHandler.STEP_HANDLE_COLOR);
        }
    }
}
