using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private ClassCurrency _classCurrency;
        private List<ClassCustomer> _listCustomer;
        private ClassCustomer _classCustomer;
        private ClassArt _classArt;
        private List<ClassArt> _listClassArt;

        public ClassBIZ()
        {
            _classCurrency = new ClassCurrency();
            _listCustomer = new List<ClassCustomer>();
            _classCustomer = new ClassCustomer();
            _classArt = new ClassArt();
            _listClassArt = new List<ClassArt>();
        }


        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (_classCurrency != value)
                {
                    _classCurrency = value;
                }
                Notify("classCurrency");
            }
        }


        public List<ClassCustomer> listCustomer
        {
            get { return _listCustomer; }
            set
            {
                if (_listCustomer != value)
                {
                    _listCustomer = value;
                }
                Notify("listCustomer");
            }
        }


        public ClassCustomer classCustomer
        {
            get { return _classCustomer; }
            set
            {
                if (_classCustomer != value)
                {
                    _classCustomer = value;
                }
                Notify("classCustomer");
            }
        }


        public ClassArt classArt
        {
            get { return _classArt; }
            set
            {
                if (_classArt != value)
                {
                    _classArt = value;
                }
                Notify("classArt");
            }
        }


        public List<ClassArt> listClassArt
        {
            get { return _listClassArt; }
            set
            {
                if (_listClassArt != value)
                {
                    _listClassArt = value;
                }
                Notify("listClassArt");
            }
        }

        public async Task StartCurrencyApiCall()
        {

        }

        private void GetAllCurrencyIdAndNames()
        {

        }
    }
}
