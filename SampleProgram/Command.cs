using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Command
{
    public interface Command
    {
        void execute();
        void undo();
        string getState();
    }

    public class NoCommand:Command
    {
        public void execute()
        {

        }
        public void undo()
        {

        }
        public string getState()
        {
            return "コマンドなし";
        }
    }

    #region マクロコマンド
    public class MacroComand : Command
    {
        List<Command> command_lists_;

        public MacroComand(List<Command> command_lists)
        {
            command_lists_ = command_lists;
        }

        public void execute()
        {
            foreach(Command command in command_lists_)
            {
                command.execute();
            }
        }

        public void undo()
        {
            foreach (Command command in command_lists_)
            {
                command.undo();
            }
        }
        public string getState()
        {
            string status = "";
            foreach (Command command in command_lists_)
            {
                status += command.getState() + "\n";
            }
            return status;
        }
    }
    #endregion

    #region Light
    public class Light
    {
        private bool light_state;
        private string location_;
        public Light(string location)
        {
            light_state = false;
            location_ = location;
        }
        public void on()
        {
            light_state = true;
        }
        public void off()
        {
            light_state = false;
        }
        public string getState()
        {
            if (light_state)
                return string.Format("{0}の照明がついています", location_);
            return string.Format("{0}の照明が消えています", location_);
        }
    }

    public class LightOnCommand:Command
    {
        Light light_;
        public LightOnCommand(Light light)
        {
            light_ = light;
        }
        public void execute()
        {
            light_.on();
        }

        public void undo()
        {
            light_.off();
        }

        public string getState()
        {
            return light_.getState();
        }
    }
    
    public class LightOffCommand : Command
    {
        Light light_;
        public LightOffCommand(Light light)
        {
            light_ = light;
        }

        public void execute()
        {
            light_.off();
        }
        public void undo()
        {
            light_.on();
        }
        public string getState()
        {
            return light_.getState();
        }
    }
    public class SimpleRemoteControl
    {
        public Command Command
        {
            set;
            get;
        }
        public void buttonWasPressed()
        {
            Command.execute();
        }

        public object currentState()
        {
            if (Command == null)
                return "照明が見つかりません";
            return Command.getState();
        }
    }
    #endregion
    
    #region Stereo
    public class Stereo
    {
        string location_;
        public Stereo(string location)
        {
            stereo_state_ = false;
            is_set_cd_ = false;
            this.Volume = 0;
            location_ = location;
        }

        private bool stereo_state_;
        public void on()
        {
            stereo_state_ = true;
        }
        public void off()
        {
            stereo_state_ = false;
        }
        public string getState()
        {
            if (stereo_state_)
                return string.Format("{0}のステレオがついています",location_);
            return string.Format("{0}ステレオが消えています", location_);
        }

        private bool is_set_cd_;
        public void setCD()
        {
            is_set_cd_ = true;
        }
        public void ejectCD()
        {
            is_set_cd_ = false;
        }

        public int Volume { set; get; }
    }

    public class StereoOnWithCDCommand:Command
    {
        Stereo stereo_;
        public StereoOnWithCDCommand(Stereo stereo)
        {
            stereo_ = stereo;
        }

        public void execute()
        {
            stereo_.on();
            stereo_.setCD();
            stereo_.Volume = 11;
        }
        public void undo()
        {
            stereo_.off();
        }
        public string getState()
        {
            return stereo_.getState();
        }
    }

    public class StereoOffWithCDCommand : Command
    {
        Stereo stereo_;
        public StereoOffWithCDCommand(Stereo stereo)
        {
            stereo_ = stereo;
        }

        public void execute()
        {
            stereo_.off();
            stereo_.ejectCD();
            stereo_.Volume = 0;
        }
        public void undo()
        {
            stereo_.on();
            stereo_.setCD();
            stereo_.Volume = 8;
        }
        public string getState()
        {
            return stereo_.getState();
        }
    }
    #endregion

    #region CellingFan
    public class CellingFan
    {
        private const int HIGH_SPEED = 3;
        private const int MIDIUM_SPEED = 2;
        private const int LOW_SPEED = 1;
        private const int STOP = 0;
        public int FanSpeed { set; get; }

        private string location_;

        public CellingFan(string location)
        {
            FanSpeed = STOP;
            location_ = location;
        }
        public void increment_speed()
        {
            FanSpeed++;
            if (FanSpeed > HIGH_SPEED)
                FanSpeed = STOP;
        }
        public void decrement_speed()
        {
            FanSpeed--;
            if (FanSpeed < STOP)
                FanSpeed = HIGH_SPEED;
        }
        public string getState()
        {
            string fan_status = string.Format("{0}のセーリングファンが止まっています", location_);
            switch (FanSpeed)
            {
                case HIGH_SPEED:
                    fan_status = string.Format("{0}セーリングファンが高速で回っています", location_);
                    break;
                case MIDIUM_SPEED:
                    fan_status = string.Format("{0}セーリングファンが中速で回っています", location_);
                    break;
                case LOW_SPEED:
                    fan_status = string.Format("{0}セーリングファンが低速で回っています", location_);
                    break;
            }
            return fan_status;
        }
    }

    public class CellingFanOnCommand : Command
    {
        CellingFan celling_fan_;
        public CellingFanOnCommand(CellingFan celling_fan)
        {
            celling_fan_ = celling_fan;
        }
        public void execute()
        {
            celling_fan_.increment_speed();
        }
        public void undo()
        {
            celling_fan_.decrement_speed();
        }
        public string getState()
        {
            return celling_fan_.getState();
        }
    }

    public class CellingFanOffCommand : Command
    {
        CellingFan celling_fan_;
        public CellingFanOffCommand(CellingFan celling_fan)
        {
            celling_fan_ = celling_fan;
        }

        public void execute()
        {
            celling_fan_.decrement_speed();
        }
        public void undo()
        {
            celling_fan_.increment_speed();
        }
        public string getState()
        {
            return celling_fan_.getState();
        }
    }
    #endregion

    #region GarageDoor
    public class GarageDoor
    {
        private bool garage_door_state;
        private string location_;

        public GarageDoor(string location)
        {
            garage_door_state = false;
            location_ = location;
        }
        public void on()
        {
            garage_door_state = true;
        }
        public void off()
        {
            garage_door_state = false;
        }
        public string getState()
        {
            if (garage_door_state)
                return string.Format("{0}ガレージドアが開いています",location_);
            return string.Format("{0}ガレージドアが閉じています", location_);
        }
    }

    public class GarageDoorOnCommand : Command
    {
        GarageDoor garage_door_;
        public GarageDoorOnCommand(GarageDoor garage_door)
        {
            garage_door_ = garage_door;
        }
        public void execute()
        {
            garage_door_.on();
        }
        public void undo()
        {
            garage_door_.off();
        }
        public string getState()
        {
            return garage_door_.getState();
        }
    }

    public class GarageDoorOffCommand : Command
    {
        GarageDoor garage_door_;
        public GarageDoorOffCommand(GarageDoor garage_door)
        {
            garage_door_ = garage_door;
        }

        public void execute()
        {
            garage_door_.off();
        }
        public void undo()
        {
            garage_door_.on();
        }
        public string getState()
        {
            return garage_door_.getState();
        }
    }
    #endregion
}

namespace HeadFirstDesignPattern.Command
{
    
    public class RemoteControl
    {
        public const int MAX_COMMAND_NUMBER = 7;
        List<Command> on_command_list;
        List<Command> off_command_list;
        Command undo_command;

        public RemoteControl()
        {
            on_command_list = new List<Command>();
            off_command_list = new List<Command>();
            undo_command = new NoCommand();
            for(int i = 0;i < MAX_COMMAND_NUMBER;i++)
            {
                on_command_list.Add(new NoCommand());
                off_command_list.Add(new NoCommand());
            }
        }

        public Command GetOnCommand(int p)
        {
            if (p < MAX_COMMAND_NUMBER)
                return on_command_list[p];
            return null;
        }
        public Command GetOffCommand(int p)
        {
            if (p < MAX_COMMAND_NUMBER)
                return off_command_list[p];
            return null;
        }
        public void SetCommand(int slot, Command on_command, Command off_command)
        {
            on_command_list[slot] = on_command;
            off_command_list[slot] = off_command;
        }

        public void OnButtonWasPushed(int p)
        {
            on_command_list[p].execute();
            undo_command = on_command_list[p];
        }

        public object GetStatus(int p)
        {
            return on_command_list[p].getState();
        }

        public void OffButtonWasPushed(int p)
        {
            off_command_list[p].execute();
            undo_command = off_command_list[p];
        }

        public void UndoButtonWasPushed()
        {
            undo_command.undo();
        }
    }
}
