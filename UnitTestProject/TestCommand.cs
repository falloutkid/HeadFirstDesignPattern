using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Moq;
using Moq.Sequences;
using HeadFirstDesignPattern;
using HeadFirstDesignPattern.Command;
using System.Diagnostics;


namespace UnitTestProject
{
    [TestClass]
    public class TestCommand
    {


        public TestContext TestContext { set; get; }

        [Ignore]
        public void TestAlwaysFail()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void TestRemoteControlSetTargetCommand()
        {
            RemoteControl controler = new RemoteControl();
            Light light = new Light("");
            LightOnCommand light_on = new LightOnCommand(light);
            LightOffCommand light_off = new LightOffCommand(light);

            NoCommand expect_object = new NoCommand();

            Assert.AreEqual(expect_object.GetType(), controler.GetOffCommand(0).GetType());
            Assert.AreEqual(expect_object.GetType(), controler.GetOnCommand(0).GetType());

            controler.SetCommand(0, light_on, light_off);

            Assert.AreEqual(light_off.GetType(), controler.GetOffCommand(0).GetType());
            Assert.AreEqual(light_on.GetType(), controler.GetOnCommand(0).GetType());
        }

        [TestMethod]
        public void TestRemoteControlInitialize()
        {
            RemoteControl controler = new RemoteControl();
            NoCommand no_command = new NoCommand();
            for (int i = 0; i < 7; i++)
            {
                Assert.AreEqual(no_command.GetType(), controler.GetOffCommand(i).GetType());
                Assert.AreEqual(no_command.GetType(), controler.GetOnCommand(i).GetType());
            }
        }

        [TestMethod]
        public void TestRemoteControllerButtonOnPush()
        {
            RemoteControl controler = new RemoteControl();
            Light light = new Light("リビング");
            LightOnCommand light_on = new LightOnCommand(light);
            LightOffCommand light_off = new LightOffCommand(light);

            controler.SetCommand(0, light_on, light_off);
            controler.OnButtonWasPushed(0);
            Assert.AreEqual("リビングの照明がついています", controler.GetStatus(0));
        }

        [TestMethod]
        public void TestRemoteControllerButtonOffPush()
        {
            RemoteControl controler = new RemoteControl();
            Light light = new Light("リビング");
            LightOnCommand light_on = new LightOnCommand(light);
            LightOffCommand light_off = new LightOffCommand(light);

            controler.SetCommand(0, light_on, light_off);
            controler.OnButtonWasPushed(0);
            Assert.AreEqual("リビングの照明がついています", controler.GetStatus(0));

            controler.OffButtonWasPushed(0);
            Assert.AreEqual("リビングの照明が消えています", controler.GetStatus(0));
        }

        [TestMethod]
        public void TestSetSomeCommandRemoteController()
        {
            Light living_light = new Light("リビング");
            LightOffCommand living_light_off = new LightOffCommand(living_light);
            LightOnCommand living_light_on = new LightOnCommand(living_light);

            Light kitchen_light = new Light("キッチン");
            LightOffCommand kitchen_light_off = new LightOffCommand(kitchen_light);
            LightOnCommand kitchen_light_on = new LightOnCommand(kitchen_light);

            CellingFan living_celling_fan = new CellingFan("リビング");
            CellingFanOffCommand living_celling_fan_off = new CellingFanOffCommand(living_celling_fan);
            CellingFanOnCommand living_celling_fan_on = new CellingFanOnCommand(living_celling_fan);

            Stereo bead_room_stereo = new Stereo("ベッドルーム");
            StereoOffWithCDCommand bead_room_stereo_off = new StereoOffWithCDCommand(bead_room_stereo);
            StereoOnWithCDCommand bead_room_stereo_on = new StereoOnWithCDCommand(bead_room_stereo);

            GarageDoor entrance_garage = new GarageDoor("玄関");
            GarageDoorOffCommand entrance_garage_off = new GarageDoorOffCommand(entrance_garage);
            GarageDoorOnCommand entrance_garage_on = new GarageDoorOnCommand(entrance_garage);

            RemoteControl controler = new RemoteControl();
            controler.SetCommand(0, living_celling_fan_on, living_celling_fan_off);
            controler.SetCommand(1, kitchen_light_on, kitchen_light_off);
            controler.SetCommand(2, living_light_on, living_light_off);
            controler.SetCommand(3, bead_room_stereo_on, bead_room_stereo_off);
            controler.SetCommand(4, entrance_garage_on, entrance_garage_off);
            for (int i = 0; i < 7; i++)
            {
                Debug.WriteLine("ボタン：" + i.ToString() + " 状態：" + controler.GetStatus(i));
            }

            controler.OnButtonWasPushed(1);
            controler.OnButtonWasPushed(3);
            controler.OnButtonWasPushed(4);
            controler.OnButtonWasPushed(5);

            for (int i = 0; i < 7; i++)
            {
                Debug.WriteLine("ボタン：" + i.ToString() + " 状態：" + controler.GetStatus(i));
            }

            controler.OffButtonWasPushed(3);
            controler.OffButtonWasPushed(4);

            for (int i = 0; i < 7; i++)
            {
                Debug.WriteLine("ボタン：" + i.ToString() + " 状態：" + controler.GetStatus(i));
            }
        }

        [TestMethod]
        public void TestRemoteControllerCellingFan()
        {
            RemoteControl controler = new RemoteControl();
            CellingFan living_celling_fan = new CellingFan("リビング");
            CellingFanOffCommand living_celling_fan_off = new CellingFanOffCommand(living_celling_fan);
            CellingFanOnCommand living_celling_fan_on = new CellingFanOnCommand(living_celling_fan);

            controler.SetCommand(0, living_celling_fan_on, living_celling_fan_off);
            for (int i = 0; i < 5; i++)
            {
                controler.OnButtonWasPushed(0);
                Debug.WriteLine("Push ON Button");
                Debug.WriteLine(controler.GetStatus(0) + "\n");
            }
            for (int i = 0; i < 5; i++)
            {
                controler.UndoButtonWasPushed();
                Debug.WriteLine("Push UNDO Button");
                Debug.WriteLine(controler.GetStatus(0) + "\n");
            }
            for (int i = 0; i < 5; i++)
            {
                controler.OffButtonWasPushed(0);
                Debug.WriteLine("Push OFF Button");
                Debug.WriteLine(controler.GetStatus(0) + "\n");
            }
            for (int i = 0; i < 5; i++)
            {
                controler.UndoButtonWasPushed();
                Debug.WriteLine("Push UNDO Button");
                Debug.WriteLine(controler.GetStatus(0) + "\n");
            }
        }

        [TestMethod]
        public void TestMacroCommand()
        {
            Light living_light = new Light("リビング");
            LightOffCommand living_light_off = new LightOffCommand(living_light);
            LightOnCommand living_light_on = new LightOnCommand(living_light);

            CellingFan living_celling_fan = new CellingFan("リビング");
            CellingFanOffCommand living_celling_fan_off = new CellingFanOffCommand(living_celling_fan);
            CellingFanOnCommand living_celling_fan_on = new CellingFanOnCommand(living_celling_fan);

            Stereo living_stereo = new Stereo("リビング");
            StereoOffWithCDCommand living_stereo_off = new StereoOffWithCDCommand(living_stereo);
            StereoOnWithCDCommand living_stereo_on = new StereoOnWithCDCommand(living_stereo);

            List<Command> party_on = new List<Command>() { living_celling_fan_on, living_light_on, living_stereo_on };
            List<Command> party_off = new List<Command>() { living_celling_fan_off, living_light_off, living_stereo_off };

            MacroComand macro_patty_on = new MacroComand(party_on);
            MacroComand macro_patty_off = new MacroComand(party_off);

            RemoteControl controler = new RemoteControl();
            controler.SetCommand(0, macro_patty_on, macro_patty_off);
            Debug.WriteLine(controler.GetStatus(0));

            controler.OnButtonWasPushed(0);
            Debug.WriteLine(controler.GetStatus(0));

            controler.OffButtonWasPushed(0);
            Debug.WriteLine(controler.GetStatus(0));
        }
    }

    [TestClass]
    public class TestCommandFunction
    {
        readonly string LIVING_ROOM = "リビング";
        readonly string LIVING_ROOM_LIGHT_ON_MESSAGE = "リビングの照明がついています";
        readonly string LIVING_ROOM_LIGHT_OFF_MESSAGE = "リビングの照明が消えています";
        readonly string SIMPLE_CONTROLLER_NO_LIGHT_TARGET_MESSAGE = "照明が見つかりません";

        [TestMethod]
        public void TestLightOn()
        {
            Light light = new Light(LIVING_ROOM);
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, light.getState());
            LightOnCommand light_on = new LightOnCommand(light);
            light_on.execute();
            Assert.AreEqual(LIVING_ROOM_LIGHT_ON_MESSAGE, light.getState());
        }

        [TestMethod]
        public void TestLightOff()
        {
            Light light = new Light(LIVING_ROOM);
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, light.getState());
            LightOffCommand light_off = new LightOffCommand(light);
            light_off.execute();
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, light.getState());
        }

        [TestMethod]
        public void TestLightOnOffOn()
        {
            Light light = new Light(LIVING_ROOM);
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, light.getState());

            LightOnCommand light_on = new LightOnCommand(light);
            light_on.execute();
            Assert.AreEqual(LIVING_ROOM_LIGHT_ON_MESSAGE, light.getState());

            LightOffCommand light_off = new LightOffCommand(light);
            light_off.execute();
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, light.getState());
        }

        [TestMethod]
        public void TestSimpleRemoteControl1()
        {
            Light light = new Light(LIVING_ROOM);
            LightOnCommand light_on = new LightOnCommand(light);
            LightOffCommand light_off = new LightOffCommand(light);

            SimpleRemoteControl remote = new SimpleRemoteControl();
            Assert.AreEqual(SIMPLE_CONTROLLER_NO_LIGHT_TARGET_MESSAGE, remote.currentState());

            remote.Command = light_off;
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, remote.currentState());
            remote.buttonWasPressed();
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, remote.currentState());

            remote.Command = light_on;
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, remote.currentState());
            remote.buttonWasPressed();
            Assert.AreEqual(LIVING_ROOM_LIGHT_ON_MESSAGE, remote.currentState());

            remote.Command = light_off;
            Assert.AreEqual(LIVING_ROOM_LIGHT_ON_MESSAGE, remote.currentState());
            remote.buttonWasPressed();
            Assert.AreEqual(LIVING_ROOM_LIGHT_OFF_MESSAGE, remote.currentState());
        }
    }
}
