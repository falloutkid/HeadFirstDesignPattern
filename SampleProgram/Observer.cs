using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Observer
{
    public interface IObserver
    {
        void Update(float temperature, float humidity, float pressure);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObserver();
    }

    public interface IDisplayElement
    {
        object Display();
    }

    public class WeatherData : ISubject
    {
        private List<IObserver> observers_;
        private float temperature_;
        private float humidity_;
        private float pressure_;

        public WeatherData()
        {
            observers_ = new List<IObserver>();
        }

        #region ISubject Members

        public void RegisterObserver(IObserver observer)
        {
            observers_.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            int i = observers_.IndexOf(observer);
            if (i >= 0)
            {
                observers_.Remove(observer);
            }
        }

        public void NotifyObserver()
        {
            foreach (IObserver observer in observers_)
            {
                observer.Update(temperature_, humidity_, pressure_);
            }
        }

        #endregion

        public void MeasurementsChanged()
        {
            NotifyObserver();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature_ = temperature;
            this.humidity_ = humidity;
            this.pressure_ = pressure;
            MeasurementsChanged();
        }
    }

    public class HeatIndexDisplay : IObserver, IDisplayElement
    {
        private float heatIndex = 0.0f;
        private ISubject weatherData;

        public HeatIndexDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        #region IObserver Members

        public void Update(float temperature, float relativeHumidity, float pressure)
        {
            heatIndex = computeHeatIndex(temperature, relativeHumidity);
        }

        #endregion

        #region IDisplayElement Members

        public object Display()
        {
            return "Heat index is " + heatIndex;
        }

        #endregion

        #region computeHeatIndex
        private float computeHeatIndex(float temperature, float relativeHumidity)
        {
            float heatIndex = (float)((16.923 + (0.185212 * temperature) +
                (5.37941 * relativeHumidity) - (0.100254 * temperature * relativeHumidity) +
                (0.00941695 * (temperature * temperature)) +
                (0.00728898 * (relativeHumidity * relativeHumidity)) +
                (0.000345372 * (temperature * temperature * relativeHumidity)) -
                (0.000814971 * (temperature * relativeHumidity * relativeHumidity)) +
                (0.0000102102 * (temperature * temperature * relativeHumidity * relativeHumidity)) -
                (0.000038646 * (temperature * temperature * temperature)) +
                (0.0000291583 * (relativeHumidity * relativeHumidity * relativeHumidity)) +
                (0.00000142721 * (temperature * temperature * temperature * relativeHumidity)) +
                (0.000000197483 * (temperature * relativeHumidity * relativeHumidity * relativeHumidity)) -
                (0.0000000218429 * (temperature * temperature * temperature * relativeHumidity * relativeHumidity)) +
                0.000000000843296 * (temperature * temperature * relativeHumidity * relativeHumidity * relativeHumidity)) -
                (0.0000000000481975 * (temperature * temperature * temperature * relativeHumidity * relativeHumidity * relativeHumidity)));
            return heatIndex;
        }
        #endregion//computeHeatIndex

    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        #region Members
        private float maxTemp = 0.0f;
        private float minTemp = 200;//set intial high so that minimum 
        //is set first invokation
        private float temperatureSum = 0.0f;
        private int numReadings = 0;
        private ISubject weatherData;
        #endregion//Members

        #region NumberOfReadings Property
        public int NumberOfReadings
        {
            get
            {
                return numReadings;
            }
        }
        #endregion//NumberOfReadings Property

        #region Constructor
        public StatisticsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }
        #endregion//Constructor

        #region IObserver Members

        public void Update(float temperature, float humidity, float pressure)
        {
            temperatureSum += temperature;
            numReadings++;

            if (temperature > maxTemp)
            {
                maxTemp = temperature;
            }

            if (temperature < minTemp)
            {
                minTemp = temperature;
            }
        }

        #endregion

        #region IDisplayElement Members

        public object Display()
        {
            return "Avg/Max/Min temperature = " + RoundFloatToString(temperatureSum / numReadings) + "F/" + maxTemp + "F/" + minTemp + "F";
        }

        #endregion

        #region RoundFloatToString
        public static string RoundFloatToString(float floatToRound)
        {
            System.Globalization.CultureInfo cultureInfo = new System.Globalization.CultureInfo("en-US");
            cultureInfo.NumberFormat.CurrencyDecimalDigits = 2;
            cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            return floatToRound.ToString("F", cultureInfo);
        }
        #endregion//RoundFloatToString

    }

    public class ForcastDisplay : IObserver, IDisplayElement
    {
        private float currentPressure = 29.92f;
        private float lastPressure;
        private ISubject weatherData;

        public ForcastDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        #region IObserver Members
        public void Update(float temperature, float humidity, float pressure)
        {
            lastPressure = currentPressure;
            currentPressure = pressure;
        }
        #endregion

        #region IDisplayElement Members
        public object Display()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Forecast: ");

            if (currentPressure > lastPressure)
            {
                sb.Append("Improving weather on the way!");
            }
            else if (currentPressure == lastPressure)
            {
                sb.Append("More of the same");
            }
            else if (currentPressure < lastPressure)
            {
                sb.Append("Watch out for cooler, rainy weather");
            }
            return sb.ToString();
        }
        #endregion
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float temperature;
        private float humidity;
        private float pressure;
        private ISubject weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterObserver(this);
        }

        #region IObserver Members
        public void Update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
        }
        #endregion

        #region IDisplayElement Members
        public object Display()
        {
            return "Current conditions: " + temperature + "F degrees and " + humidity + "% humidity";
        }
        #endregion
    }
}
