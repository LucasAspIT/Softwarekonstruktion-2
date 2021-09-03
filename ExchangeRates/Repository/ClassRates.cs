using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    /// <summary>
    /// Denne class benyttes til at holde data vedrørende en valuta.
    /// Data fra Web API omsættes til passende data typer, som passer til applikationen.
    /// </summary>
    public class ClassRates : ClassNotify
    {
        private string _key;
        private double _value;
        private string _Base;
        private int _timestamp;
        private string _license;
        private string _disclaimer;
        private string _strDateTime;
        private double _rateDK;

        private double _DKK;

        public ClassRates()
        {
            disclaimer = "";
            license = "";
            strDateTime = "";
            timestamp = 0;
            Base = "";
            key = "";
            value = 0D;
            _DKK = 0D;
            _rateDK = 0D;
        }

        /// <summary>
        /// Denne overloaded constructor, gør det muligt at oprette en ny instans af ClassRates, som er baseret på valutakoden og valutakursen.
        /// Ved at modtage en fuld instans af ExchangeRates, fremtidssikrer jeg ClassRates, da jeg kan udlede langt flere data fra denne instans.
        /// </summary>
        /// <param name="rates">ExchangeRates</param>
        /// <param name="inKey">string</param>
        /// <param name="inValue">double</param>
        public ClassRates(ExchangeRates rates, string inKey, double inValue)
        {
            _DKK = rates.rates["DKK"];
            rateDK = 0D;
            disclaimer = rates.disclaimer;
            license = rates.license;
            strDateTime = "";
            timestamp = rates.timestamp;
            Base = rates.Base;
            key = inKey;
            value = inValue;
        }


        public double rateDK
        {
            get { return _rateDK; }
            set
            {
                if (_rateDK != value)
                {
                    _rateDK = value;
                }
                Notify("rateDK");
            }
        }

        public string disclaimer
        {
            get { return _disclaimer; }
            set
            {
                if (_disclaimer != value)
                {
                    _disclaimer = value;
                }
                Notify("disclaimer");
            }
        }

        public string license
        {
            get { return _license; }
            set
            {
                if (_license != value)
                {
                    _license = value;
                }
                Notify("license");
            }
        }

        public int timestamp
        {
            get { return _timestamp; }
            set
            {
                if (_timestamp != value)
                {
                    _timestamp = value;
                    MakeTimeString();
                }
                Notify("timestamp");
            }
        }

        public string Base
        {
            get { return _Base; }
            set
            {
                if (_Base != value)
                {
                    _Base = value;
                }
                Notify("Base");
            }
        }

        public string key
        {
            get { return _key; }
            set
            {
                if (_key != value)
                {
                    _key = value;
                }
                Notify("key");
            }
        }

        /// <summary>
        /// Dennee property har to funktioner. Ud over at den holder værdien for den valgte valutakurs i USD, sikrer den også at udregningen til valutakursen i DKK udføres.
        /// Dette sikres kun ved et kald til metoden CalculateRateInDKK();
        /// Foretages kun, hvis data i value opdateres.
        /// </summary>
        public double value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    CalculateRateInDKK();
                }
                Notify("value");
            }
        }

        public string strDateTime
        {
            get { return _strDateTime; }
            set
            {
                if (_strDateTime != value)
                {
                    _strDateTime = value;
                }
                Notify("strDateTime");
            }
        }

        /// <summary>
        /// Takes the provided timestamp in UNIX and converts it to a readable string formatted as day-month-year hour:minutes:seconds e.g. 02-09-2021 12:34:55
        /// </summary>
        private void MakeTimeString()
        {
            strDateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToString("dd-MM-yyyy HH:mm:ss") + " (GMT+0)"; // UNIX time is in GMT+0
        }

        /// <summary>
        /// Denne metode omregner valutakursen fra USD til kursen i DKK.
        /// </summary>
        private void CalculateRateInDKK()
        {
            rateDK = 1 / value * _DKK;
        }
    }
}
