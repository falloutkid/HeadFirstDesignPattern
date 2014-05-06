using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.State
{
    public class GumballMachine
    {
        State sold_out_state_;
        State no_quarter_state_;
        State has_quarter_state_;
        State sold_state_;
        State state_;

        int count = 0;

        public State StateOfMachine
        {
            get { return state_; }
            set { state_ = value; }
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public GumballMachine(int numberOfGumballs)
        {
            sold_out_state_ = new SoldOutState(this);
            no_quarter_state_ = new NoQuarterState(this);
            has_quarter_state_ = new HasQuarterState(this);
            sold_state_ = new SoldState(this);
            this.count = numberOfGumballs;
            if (numberOfGumballs > 0)
            {
                state_ = no_quarter_state_;
            }
            else
            {
                state_ = sold_out_state_;
            }
        }

        public string InsertQuarter()
        {
            return state_.InsertQuarter();
        }

        public string EjectQuarter()
        {
            return state_.EjectQuarter();
        }

        public string TurnCrank()
        {
            return state_.TurnCrank() +
                state_.Dispense();
        }

        public string ReleaseBall()
        {
            if (count != 0)
            {
                count -= 1;
            }

            return "A gumball comes rolling out the slot...\n";
        }

        public string Refill(int numberOfGumballs)
        {
            this.count += numberOfGumballs;
            state_ = no_quarter_state_;

            return "\nRefill: " + numberOfGumballs + " gumballs were added. " +
                "The gumball count in now: " + count + "\n";
        }

        public string MachineStateHeader()
        {
            StringBuilder result = new StringBuilder();
            result.Append("Mighty Gumball, Inc.");
            result.Append("\nC# Enabled Standing Gumball Model #2005\n");
            result.Append("Inventory: " + count + " gumball");
            if (count != 1)
            {
                result.Append("s");
            }
            result.Append("\nMachine is " + state_.ToString());

            return result.ToString();
        }
    }

    public interface State
    {
        string InsertQuarter();
        string EjectQuarter();
        string TurnCrank();
        string Dispense();
    }

    public class SoldState : State
    {
        GumballMachine gumball_machine_;
        State no_quarter_state_;
        State sold_out_state_;

        public SoldState(GumballMachine gumballMachine)
        {
            this.gumball_machine_ = gumballMachine;
            no_quarter_state_ = new NoQuarterState(gumballMachine);
            sold_out_state_ = new SoldOutState(gumballMachine);
        }


        public string InsertQuarter()
        {
            return "Please wait, we're already giving you a gumball\n";
        }

        public string EjectQuarter()
        {
            return "Sorry, you already turned the crank\n";
        }

        public string TurnCrank()
        {
            return "Turning twice doesn't get you another gumball!\n";
        }

        public string Dispense()
        {
            string outPut;
            outPut = gumball_machine_.ReleaseBall();
            if (gumball_machine_.Count > 0)
            {
                gumball_machine_.StateOfMachine = no_quarter_state_;
            }
            else
            {
                gumball_machine_.StateOfMachine = sold_out_state_;
                outPut += "Oops, out of gumballs!\n";
            }

            return outPut;
        }

        public override string ToString()
        {
            return "delivering a gumball";
        }
    }

    public class NoQuarterState : State
    {
        GumballMachine gumball_machine_;
        State has_quarter_state_;

        public NoQuarterState(GumballMachine gumball_machine)
        {
            gumball_machine_ = gumball_machine;
            has_quarter_state_ = new HasQuarterState(gumball_machine);
        }

        public string InsertQuarter()
        {
            gumball_machine_.StateOfMachine = has_quarter_state_;
            return "25セント投入しました";
        }

        public string EjectQuarter()
        {
            return "25セント投入していません";
        }

        public string TurnCrank()
        {
            return "クランクを回しましたが、25セントを投入していません";
        }

        public string Dispense()
        {
            string output = "";

            output = gumball_machine_.ReleaseBall();
            output += "まず支払いをする必要があります";

            return output;
        }

        public override string ToString()
        {
            return "25セントを投入されることをまっている状態";
        }
    }

    public class HasQuarterState : State
    {
        GumballMachine gumball_machine_;
        Random random_winner_ = new Random(System.DateTime.Now.Millisecond);
        State winner_state_;
        State sold_state_;

        public HasQuarterState(GumballMachine gumball_machine)
        {
            gumball_machine_ = gumball_machine;
            winner_state_ = new WinnerState(gumball_machine_);
            sold_state_ = new SoldState(gumball_machine_);
        }

        public string InsertQuarter()
        {
            return "新たに25セントを入れる必要はありません";
        }

        public string EjectQuarter()
        {
            return "25セント返金します";
        }

        public string TurnCrank()
        {
            string output;
            output = "クランクを回しました";

            int winner = random_winner_.Next(10);
            if (winner == 0 && gumball_machine_.Count > 1)
            {
                gumball_machine_.StateOfMachine = new WinnerState(gumball_machine_);
                gumball_machine_.StateOfMachine = winner_state_;
            }
            else
            {
                gumball_machine_.StateOfMachine = new SoldState(gumball_machine_);
                gumball_machine_.StateOfMachine = sold_state_;
            }

            return output;
        }

        public string Dispense()
        {
            string output;

            output = gumball_machine_.ReleaseBall();
            output += "ガムボールがありません";

            return output;
        }

        public override string ToString()
        {
            return "クランクを回すのをまっている状態";
        }
    }

    public class SoldOutState : State
    {
        GumballMachine gumballMachine;
        State no_quarter_state_;
        State sold_out_state_;

        public SoldOutState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
            no_quarter_state_ = new NoQuarterState(gumballMachine);
            sold_out_state_ = new SoldOutState(gumballMachine);
        }

        public string InsertQuarter()
        {
            return "25セントは入れられません。現在売り切れ中です。";
        }

        public string EjectQuarter()
        {
            return "返金出来ません。まだ25セント入れていません。";
        }

        public string TurnCrank()
        {
            return "既にクランクを回しました。";
        }

        public string Dispense()
        {
            string output;

            output = gumballMachine.ReleaseBall();
            output += "返金してください。ガムボールは売り切れです";

            return output;
        }

                public override string ToString()
        {
            return "売り切れ中";
        }
    }

    public class WinnerState : State
    {
        GumballMachine gumballMachine;
        State sold_out_state_;
        State no_quarter_state_;

        public WinnerState(GumballMachine gumballMachine)
        {
            this.gumballMachine = gumballMachine;
            sold_out_state_ = new SoldOutState(gumballMachine);
            no_quarter_state_ = new NoQuarterState(gumballMachine);
        }

        public string InsertQuarter()
        {
            return "Please wait, we're already giving you a gumball\n";
        }

        public string EjectQuarter()
        {
            return "Sorry, you already turned the crank\n";
        }

        public string TurnCrank()
        {
            return "Turning twice doesn't get you another gumball!\n";
        }

        public string Dispense()
        {
            string outPut;
            outPut = "YOUR A WINNER! You get two gumballs for your quarter\n";
            outPut += gumballMachine.ReleaseBall();
            if (gumballMachine.Count == 0)
            {
                gumballMachine.StateOfMachine = sold_out_state_;
            }
            else
            {
                outPut += gumballMachine.ReleaseBall();
                if (gumballMachine.Count > 0)
                {
                    gumballMachine.StateOfMachine = no_quarter_state_;
                }
                else
                {
                    outPut += "Oops, out of gumballs!\n";
                    gumballMachine.StateOfMachine = sold_out_state_;
                }
            }
            return outPut;
        }

        public override string ToString()
        {
            return "";
        }
    }

    public class GumballMachineStart
    {
        private const int SOLD_OUT = 0;
        private const int NO_QUARTER = 1;
        private const int HAS_QUARTER = 2;
        private const int SOLD = 3;

        int count = 0;
        int state = SOLD_OUT;

        public GumballMachineStart(int count)
        {
            this.count = count;
            if (count > 0)
            {
                state = NO_QUARTER;
            }
        }

        public string InsertQuarter()
        {
            string insertResponse = "";

            switch (state)
            {
                case HAS_QUARTER:
                    insertResponse = "You can't insert another quarter";
                    break;
                case NO_QUARTER:
                    state = HAS_QUARTER;
                    insertResponse = "You inserted a quarter";
                    break;
                case SOLD_OUT:
                    insertResponse = "You can't insert a quarter, the machine is sold out";
                    break;
                case SOLD:
                    insertResponse = "Please wait, we're already giving you a gumball";
                    break;
                default:
                    insertResponse = "Kick the machine and then call BR549 cause it ain't workin";
                    break;
            }

            return insertResponse;
        }

        public string EjectQuarter()
        {
            string ejectResponse = "";

            switch (state)
            {
                case HAS_QUARTER:
                    ejectResponse = "Quarter returned";
                    state = NO_QUARTER;
                    break;
                case NO_QUARTER:
                    ejectResponse = "You haven't inserted a quarter";
                    break;
                case SOLD_OUT:
                    ejectResponse = "You can't eject, you haven't inserted a quarter yet";
                    break;
                case SOLD:
                    ejectResponse = "Sorry, you already turned the crank";
                    break;
                default:
                    ejectResponse = "Kick the machine and then call BR549 cause it ain't workin";
                    break;
            }
            return ejectResponse;
        }

        public string TurnCrank()
        {
            string turnCrankResponse = "";

            switch (state)
            {
                case HAS_QUARTER:
                    turnCrankResponse = "You turned...";
                    state = SOLD;
                    turnCrankResponse += Dispense();
                    break;
                case NO_QUARTER:
                    turnCrankResponse = "You turned but there's no quarter";
                    break;
                case SOLD_OUT:
                    turnCrankResponse = "You turned, but there are no gumballs";
                    break;
                case SOLD:
                    turnCrankResponse = "Turning twice doesn't get you another gumball!";
                    break;
                default:
                    turnCrankResponse = "Kick the machine and then call BR549 cause it ain't workin";
                    break;
            }

            return turnCrankResponse;
        }

        public string Dispense()
        {
            string dispenseResponse = "";

            switch (state)
            {
                case HAS_QUARTER:
                    dispenseResponse = "\nNo gumball dispensed";
                    break;
                case NO_QUARTER:
                    dispenseResponse = "\nYou need to pay first";
                    break;
                case SOLD_OUT:
                    dispenseResponse = "\nNo gumball dispensed";
                    break;
                case SOLD:
                    dispenseResponse = "\nA gumball comes rolling out the slot";
                    count -= 1;
                    if (count == 0)
                    {
                        dispenseResponse = "\nNow out of gumballs!";
                        state = SOLD_OUT;
                    }
                    else
                    {
                        state = NO_QUARTER;
                    }
                    break;
                default:
                    dispenseResponse = "\nKick the machine and then call BR549 cause it ain't workin";
                    break;
            }

            return dispenseResponse;
        }

        public void Refill(int newGumballs)
        {
            this.count = newGumballs;
            state = NO_QUARTER;
        }

        public string MachineState()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\nMighty Gumball, Inc.");
            result.Append("\nC# Enabled Standing Gumball Model #2005\n");
            result.Append("Inventory: " + count + " gumball");
            if (count != 1)
            {
                result.Append("s");
            }
            result.Append("\nMachine is ");
            if (state == SOLD_OUT)
            {
                result.Append("sold out");
            }
            else if (state == NO_QUARTER)
            {
                result.Append("waiting for quarter");
            }
            else if (state == HAS_QUARTER)
            {
                result.Append("waiting for turn of crank");
            }
            else if (state == SOLD)
            {
                result.Append("delivering a gumball");
            }

            return result.ToString();
        }
    }
}
