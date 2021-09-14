using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using IO;
using Newtonsoft.Json;
using System.Windows;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private ClassCurrency _classCurrency;
        private List<ClassCustomer> _listCustomer;
        private ClassCustomer _classCustomer;
        private ClassArt _classArt;
        private List<ClassArt> _listClassArt;
        private ClassCustomer _fallbackCustomer;
        private List<ClassCountry> _countryList;

        private ClassCallWebAPI classCallWebAPI = new ClassCallWebAPI();
        private ClassWorldArtSaleDB classWorldArtSaleDB = new ClassWorldArtSaleDB();


        public ClassBIZ()
        {
            _classCurrency = new ClassCurrency();
            _classCustomer = new ClassCustomer();

            listCustomer = classWorldArtSaleDB.GetAllCustomersFromDB();
            countryList = classWorldArtSaleDB.GetAllCountriesFromDB();
            listClassArt = classWorldArtSaleDB.GetAllArtFromDB();
        }


        public ClassCurrency classCurrency
        {
            get { return _classCurrency; }
            set
            {
                if (_classCurrency != value)
                {
                    _classCurrency = value;
                    if (value.rates.Count > 0)
                    {
                        classCurrency.SetValutaValueInProperty();
                    }
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

        public ClassCustomer fallbackCustomer
        {
            get { return _fallbackCustomer; }
            set
            {
                if (_fallbackCustomer != value)
                {
                    _fallbackCustomer = value;
                    classCustomer = new ClassCustomer(value);
                }
                Notify("fallbackCustomer");
            }
        }

        public List<ClassCountry> countryList
        {
            get { return _countryList; }
            set
            {
                if (_countryList != value)
                {
                    _countryList = value;
                }
                Notify("countryList");
            }
        }


        public async Task StartCurrencyApiCall()
        {
            try
            {
                while (true)
                {
                    // GetURLContents returns the contents of a url as a byte array.
                    string strJson = await classCallWebAPI.GetURLContentsAsync("https://openexchangerates.org/api/latest.json?app_id=3737daa413d14a59bf5738d0e6707c21&base=USD");

                    classCurrency = JsonConvert.DeserializeObject<ClassCurrency>(strJson);

                    await Task.Delay(60000);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetAllCurrencyIdAndNames()
        {

        }

        public void SaveCustomerToDB()
        {
            try
            {
                if (classCustomer.customerID == 0)
                {
                    classWorldArtSaleDB.SaveCustomerInDB(classCustomer);
                }
                else
                {
                    classWorldArtSaleDB.UpdateCustomerInDB(classCustomer);
                }
                listCustomer = classWorldArtSaleDB.GetAllCustomersFromDB();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
