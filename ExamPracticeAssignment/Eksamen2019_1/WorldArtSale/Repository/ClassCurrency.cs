using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCurrency : ClassNotify
    {
        private string _USD;
        private string _EUR;
        private string _RUB;
        private string _KWD;
        private string _BHD;
        private string _OMR;
        private string _JOD;
        private string _GBP;
        private string _KYD;
        private string _CHF;
        private string _CAD;
        private string _AUD;
        private string _AZN;
        private string _BRL;
        private string _HKD;
        private Dictionary<string, string> _currencyIdName;
        private Dictionary<string, decimal> _rates;

        public ClassCurrency()
        {
            _USD = "";
            _EUR = "";
            _RUB = "";
            _KWD = "";
            _BHD = "";
            _OMR = "";
            _JOD = "";
            _GBP = "";
            _KYD = "";
            _CHF = "";
            _CAD = "";
            _AUD = "";
            _AZN = "";
            _BRL = "";
            _HKD = "";
            _currencyIdName = new Dictionary<string, string>();
            _rates = new Dictionary<string, decimal>();
        }


        public string USD
        {
            get { return _USD; }
            set
            {
                if (_USD != value)
                {
                    _USD = value;
                }
                Notify("USD");
            }
        }


        public string EUR
        {
            get { return _EUR; }
            set
            {
                if (_EUR != value)
                {
                    _EUR = value;
                }
                Notify("EUR");
            }
        }


        public string RUB
        {
            get { return _RUB; }
            set
            {
                if (_RUB != value)
                {
                    _RUB = value;
                }
                Notify("RUB");
            }
        }


        public string KWD
        {
            get { return _KWD; }
            set
            {
                if (_KWD != value)
                {
                    _KWD = value;
                }
                Notify("KWD");
            }
        }


        public string BHD
        {
            get { return _BHD; }
            set
            {
                if (_BHD != value)
                {
                    _BHD = value;
                }
                Notify("BHD");
            }
        }


        public string OMR
        {
            get { return _OMR; }
            set
            {
                if (_OMR != value)
                {
                    _OMR = value;
                }
                Notify("OMR");
            }
        }


        public string JOD
        {
            get { return _JOD; }
            set
            {
                if (_JOD != value)
                {
                    _JOD = value;
                }
                Notify("JOD");
            }
        }


        public string GBP
        {
            get { return _GBP; }
            set
            {
                if (_GBP != value)
                {
                    _GBP = value;
                }
                Notify("GBP");
            }
        }


        public string KYD
        {
            get { return _KYD; }
            set
            {
                if (_KYD != value)
                {
                    _KYD = value;
                }
                Notify("KYD");
            }
        }


        public string CHF
        {
            get { return _CHF; }
            set
            {
                if (_CHF != value)
                {
                    _CHF = value;
                }
                Notify("CHF");
            }
        }


        public string CAD
        {
            get { return _CAD; }
            set
            {
                if (_CAD != value)
                {
                    _CAD = value;
                }
                Notify("CAD");
            }
        }


        public string AUD
        {
            get { return _AUD; }
            set
            {
                if (_AUD != value)
                {
                    _AUD = value;
                }
                Notify("AUD");
            }
        }


        public string AZN
        {
            get { return _AZN; }
            set
            {
                if (_AZN != value)
                {
                    _AZN = value;
                }
                Notify("AZN");
            }
        }


        public string BRL
        {
            get { return _BRL; }
            set
            {
                if (_BRL != value)
                {
                    _BRL = value;
                }
                Notify("BRL");
            }
        }


        public string HKD
        {
            get { return _HKD; }
            set
            {
                if (_HKD != value)
                {
                    _HKD = value;
                }
                Notify("HKD");
            }
        }


        public Dictionary<string, string> currencyIdName
        {
            get { return _currencyIdName; }
            set
            {
                if (_currencyIdName != value)
                {
                    _currencyIdName = value;
                }
                Notify("currencyIdName");
            }
        }


        public Dictionary<string, decimal> rates
        {
            get { return _rates; }
            set
            {
                if (_rates != value)
                {
                    _rates = value;
                }
                Notify("rates");
            }
        }

        private void SetValutaValueInProperty()
        {

        }
    }
}
