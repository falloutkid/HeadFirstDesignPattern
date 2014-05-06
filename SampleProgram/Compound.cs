using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Compound
{
    #region 継承用のクラス
    #region Interface
    public interface IQuackable
    {
        string Quack();
    }

    public interface IObserver
    {
        string Update(IQuackObservable duck);
    }

    public interface IQuackObservable
    {
        void RegisterObserver(IObserver observer);
        string NotifyObservers();
    }
    #endregion

    #region Abstract Class
    public abstract class AbstractDuckFactory
    {
        public abstract IQuackable CreateMallardDuck();
        public abstract IQuackable CreateRedheadDuck();
        public abstract IQuackable CreateDuckCall();
        public abstract IQuackable CreateRubberDuck();
    }
    #endregion
    #endregion

    #region Duck Factory
    public class DuckFactory : AbstractDuckFactory
    {
        public DuckFactory()
        { }

        public override IQuackable CreateMallardDuck()
        {
            return new MallardDuck();
        }

        public override IQuackable CreateRedheadDuck()
        {
            return new RedheadDuck();
        }

        public override IQuackable CreateDuckCall()
        {
            return new DuckCall();
        }

        public override IQuackable CreateRubberDuck()
        {
            return new RubberDuck();
        }
    }

    public class CountingDuckFactory : AbstractDuckFactory
    {
        public CountingDuckFactory()
        { }

        public override IQuackable CreateMallardDuck()
        {
            return new QuackCounter(new MallardDuck());
        }

        public override IQuackable CreateRedheadDuck()
        {
            return new QuackCounter(new RedheadDuck());
        }

        public override IQuackable CreateDuckCall()
        {
            return new QuackCounter(new DuckCall());
        }

        public override IQuackable CreateRubberDuck()
        {
            return new QuackCounter(new RubberDuck());
        }
    }
    #endregion

    #region Duckクラス
    public class MallardDuck : IQuackable, IQuackObservable
    {
        Observable observable;

        public MallardDuck()
        {
            observable = new Observable(this);
        }

        #region IQuackable Members
        public string Quack()
        {
            NotifyObservers();
            return "Quack";
        }
        #endregion

        #region IQuackObservable Members
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
        #endregion
    }

    public class RedheadDuck : IQuackable, IQuackObservable
    {
        Observable observable;

        public RedheadDuck()
        {
            observable = new Observable(this);
        }

        #region IQuackable Members
        public string Quack()
        {
            NotifyObservers();
            return "Quack";
        }
        #endregion

        #region IQuackObservable Members
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
        #endregion
    }

    public class RubberDuck : IQuackable, IQuackObservable
    {
        Observable observable;

        public RubberDuck()
        {
            observable = new Observable(this);
        }

        #region IQuackable Members
        public string Quack()
        {
            NotifyObservers();
            return "Squeak";
        }
        #endregion

        #region IQuackObservable Members
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
        #endregion
    }

    public class DuckCall : IQuackable, IQuackObservable
    {
        Observable observable;

        public DuckCall()
        {
            observable = new Observable(this);
        }

        #region IQuackable Members
        public string Quack()
        {
            NotifyObservers();
            return "Kwak";
        }
        #endregion

        #region IQuackObservable Members
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
        #endregion
    }
    #endregion

    #region その他の動物
    public class Goose
    {
        public Goose()
        { }

        public string Honk()
        {
            return "Honk";
        }
    }

    public class GooseAdapter : IQuackable, IQuackObservable
    {
        Goose goose;
        Observable observable;

        public GooseAdapter(Goose goose)
        {
            this.goose = goose;
            observable = new Observable(this);
        }

        #region IQuackable Members
        public string Quack()
        {
            NotifyObservers();
            return goose.Honk();
        }
        #endregion

        #region IQuackObservable Members
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
        #endregion
    }

    public class QuackCounter : IQuackable, IQuackObservable
    {
        IQuackable duck;
        static int numberOfQuacks;
        Observable observable;

        public static int QuackCount
        {
            get
            {
                return numberOfQuacks;
            }
            set
            {
                numberOfQuacks = value;
            }
        }

        public QuackCounter(IQuackable duck)
        {
            this.duck = duck;
            observable = new Observable(this);
        }

        #region IQuackable Members
        public string Quack()
        {
            NotifyObservers();
            numberOfQuacks++;
            return duck.Quack();
        }
        #endregion

        #region IQuackObservable Members
        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
        #endregion
    }
    #endregion

    #region 管理用
    public class Flock : IQuackable, IQuackObservable
    {
        List<IQuackable> quackers = new List<IQuackable>();
        Observable observable;

        public Flock()
        {
            observable = new Observable(this);
        }

        public void Add(IQuackable quacker)
        {
            quackers.Add(quacker);
        }

        public string Quack()
        {

            StringBuilder sb = new StringBuilder();

            foreach (IQuackable quacker in quackers)
            {
                sb.Append(quacker.Quack());
                sb.Append("\n");
                sb.Append(NotifyObservers());
            }

            return sb.ToString();
        }

        public void RegisterObserver(IObserver observer)
        {
            observable.RegisterObserver(observer);
        }

        public string NotifyObservers()
        {
            return observable.NotifyObservers();
        }
    }

    public class Quackologist : IObserver
    {
        public Quackologist()
        { }

        public string Update(IQuackObservable duck)
        {
            return "Quackologist: the " + duck.GetType().Name + " just quacked";
        }
    }
    #endregion

    #region Observerクラス
    public class Observable : IQuackObservable
    {
        List<IObserver> observers_ = new List<IObserver>();
        IQuackObservable duck_;

        public Observable(IQuackObservable duck)
        {
            duck_ = duck;
        }

        public void RegisterObserver(IObserver observer)
        {
            observers_.Add(observer);
        }

        public string NotifyObservers()
        {
            StringBuilder sb = new StringBuilder();
            foreach (IObserver observer in observers_)
            {
                sb.Append(observer.Update(duck_));
                sb.Append("\n");
            }

            return sb.ToString();
        }
    }
    #endregion
}
