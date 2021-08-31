using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    class ClassRates : ClassNotify
    {
        public ClassRates()
        {
            key = "";
            value = 0;
        }

        private string _key;
        private double _value;

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
                }
                Notify("value");
            }
        }

    }
}
