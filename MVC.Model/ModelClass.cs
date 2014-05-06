using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC.Model
{
    public class BeatObserver
{

}
    public class BPMObserver
    {

    }

    public interface IBeatModel
    {
        void Initialize();
        void on();
        void off();
        void SetBPM(int bmp);
        int GetBPM();
        void RegisterObserver(BeatObserver observer);
        void RemoveObserver(BeatObserver observer);
        void RegisterObserver(BPMObserver observer);
        void RemoveObserver(BPMObserver observer);
    }
    public class BeatModel:IBeatModel
    {

        public void Initialize()
        {
            throw new NotImplementedException();
        }
        public void on()
        {
            throw new NotImplementedException();
        }
        public void off()
        {
            throw new NotImplementedException();
        }
        public void SetBPM(int bmp)
        {
            throw new NotImplementedException();
        }
        public int GetBPM()
        {
            throw new NotImplementedException();
        }
        public void RegisterObserver(BeatObserver observer)
        {
            throw new NotImplementedException();
        }
        public void RemoveObserver(BeatObserver observer)
        {
            throw new NotImplementedException();
        }
        public void RegisterObserver(BPMObserver observer)
        {
            throw new NotImplementedException();
        }
        public void RemoveObserver(BPMObserver observer)
        {
            throw new NotImplementedException();
        }
    }
}
