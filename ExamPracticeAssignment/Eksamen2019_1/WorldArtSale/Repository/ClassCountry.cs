using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCountry : ClassNotify
    {
        private int _id;
        private string _code;
        private string _countryName;
        private string _valutaName;

        public ClassCountry()
        {
            id = 0;
            code = "";
            countryName = "";
            valutaName = "";
        }

        public ClassCountry(ClassCountry inCountry)
        {
            id = inCountry.id;
            code = inCountry.code;
            countryName = inCountry.countryName;
            valutaName = inCountry.valutaName;
        }

        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                }
                Notify("id");
            }
        }


        public string code
        {
            get { return _code; }
            set
            {
                if (_code != value)
                {
                    _code = value;
                }
                Notify("code");
            }
        }


        public string countryName
        {
            get { return _countryName; }
            set
            {
                if (_countryName != value)
                {
                    _countryName = value;
                }
                Notify("countryName");
            }
        }


        public string valutaName
        {
            get { return _valutaName; }
            set
            {
                if (_valutaName != value)
                {
                    _valutaName = value;
                }
                Notify("valutaName");
            }
        }

    }
}
