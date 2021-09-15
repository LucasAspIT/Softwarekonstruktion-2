using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassApiRates
    {
        private long _timestamp;
        private Dictionary<string, double> _rates;
        private string _newTimestamp;

        public ClassApiRates()
        {
            timestamp = 0L;
            rates = new Dictionary<string, double>();
            newTimestamp = "";
        }

        public long timestamp
        {
            get { return _timestamp; }
            set
            {
                if (_timestamp != value)
                {
                    _timestamp = value;
                }
            }
        }


        public Dictionary<string, double> rates
        {
            get { return _rates; }
            set
            {
                if (_rates != value)
                {
                    _rates = value;
                }
            }
        }


        public string newTimestamp
        {
            get { return _newTimestamp; }
            set
            {
                if (_newTimestamp != value)
                {
                    _newTimestamp = value;
                }
            }
        }

    }
}
