using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        CurrencyAPICall CAC = new CurrencyAPICall();

        public ClassBIZ()
        {
            exRates = new ExchangeRates();
            rate = new ClassRates();
            GetData();
        }

        private ClassRates _rate;
        private ExchangeRates _exRates;
        private List<ClassRates> _listRates;

        public ClassRates rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                }
                Notify("rate");
            }
        }

        public ExchangeRates exRates
        {
            get { return _exRates; }
            set
            {
                if (_exRates != value)
                {
                    _exRates = value;
                }
                Notify("exRates");
            }
        }

        public List<ClassRates> listRates
        {
            get { return _listRates; }
            set
            {
                if (_listRates != value)
                {
                    _listRates = value;
                }
                Notify("listRates");
            }
        }


        private void GetData()
        {
            var task = Task.Run(async () => await CAC.GetAPIDataAsync());
            exRates = (ExchangeRates)task.Result;
            SetupListRates();
        }

        private void SetupListRates()
        {
            List<ClassRates> temp = new List<ClassRates>();

            foreach (var item in exRates.rates)
            {
                ClassRates cr = new ClassRates(exRates, item.Key, item.Value);
                temp.Add(cr);
            }
            listRates = temp;
        }
    }
}
