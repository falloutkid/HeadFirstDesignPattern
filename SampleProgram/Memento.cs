using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Memento
{
    public class Originator
    {
        private string state_;

        public string State
        {
            get { return state_; }
            set
            {
                state_ = value;
                System.Diagnostics.Debug.WriteLine("State = " + state_);
            }
        }

        // Creates memento
        public Memento CreateMemento()
        {
            return (new Memento(state_));
        }

        // Restores original state
        public void SetMemento(Memento memento)
        {
            System.Diagnostics.Debug.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    #region The 'Memento' class
    public class Memento
    {
        private string _state;

        public Memento(string state)
        {
            this._state = state;
        }

        // Gets or sets state
        public string State
        {
            get { return _state; }
        }
    }
    #endregion

    #region The 'Caretaker' class
    public class Caretaker
    {
        // Gets or sets memento
        public Memento Memento{set;get;}
    }
    #endregion
}
