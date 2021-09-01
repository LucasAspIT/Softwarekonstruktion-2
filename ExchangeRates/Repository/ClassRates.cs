using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassRates : ClassNotify
    {
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

        public ClassRates(ExchangeRates rates, string inKey, double inValue)
        {
            _DKK = rates.rates["DKK"];
            _rateDK = 0D;
            disclaimer = rates.disclaimer;
            license = rates.license;
            strDateTime = "";
            timestamp = rates.timestamp;
            Base = rates.Base;
            key = inKey;
            value = inValue;
        }

        private string _key;
        private double _value;
        private string _Base;
        private int _timestamp;
        private string _license;
        private string _disclaimer;
        private string _strDateTime;
        private double _rateDK;

        private double _DKK;


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

        private void MakeTimeString()
        {
            strDateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToString("dd-MM-yyyy HH:mm:ss") + " (GMT+0)"; // GMT because openexchangerates is based in the UK
        }

        private void CalculateRateInDKK()
        {
            rateDK = 1 / value * _DKK;
        }
    }
}
