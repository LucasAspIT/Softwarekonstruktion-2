using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IO;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private List<ClassCustomer> _listCustomer;
        private List<ClassCountry> _listCountry;
        private List<ClassMeat> _listMeat;
        private ClassApiRates _apiRates;
        private ClassCustomer _selectedCustomer;
        private ClassCustomer _editOrNewCustomer;
        private ClassOrder _order;
        private bool _isEnabled;

        private ClassCallWebAPI CCWA = new ClassCallWebAPI();
        private ClassMeatGrossDB CMGDB = new ClassMeatGrossDB();

        // Unit test fields
        private int _Number2;
        private int _Number1;

        public ClassBIZ()
        {
            listCustomer = CMGDB.GetAllCustomersFromDB(); // Fill the list from the database so it can be displayed in the GUI.
            listCountry = CMGDB.GetAllCountriesFromDB();
            listMeat = CMGDB.GetAllMeatFromDB(); ;
            apiRates = new ClassApiRates();
            // selectedCustomer = new ClassCustomer();
            editOrNewCustomer = new ClassCustomer();
            order = new ClassOrder();
            isEnabled = false;

            // Unit test
            Number1 = 0;
            Number2 = 0;
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

        public List<ClassCountry> listCountry
        {
            get { return _listCountry; }
            set
            {
                if (_listCountry != value)
                {
                    _listCountry = value;
                }
                Notify("listCountry");
            }
        }

        public List<ClassMeat> listMeat
        {
            get { return _listMeat; }
            set
            {
                if (_listMeat != value)
                {
                    _listMeat = value;
                }
                Notify("listMeat");
            }
        }

        public ClassApiRates apiRates
        {
            get { return _apiRates; }
            set
            {
                if (_apiRates != value)
                {
                    _apiRates = value;
                }
                Notify("apiRates");
            }
        }

        public ClassCustomer selectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                if (_selectedCustomer != value)
                {
                    _selectedCustomer = value;
                    editOrNewCustomer = new ClassCustomer(value);
                }
                Notify("selectedCustomer");
            }
        }

        public ClassCustomer editOrNewCustomer
        {
            get { return _editOrNewCustomer; }
            set
            {
                if (_editOrNewCustomer != value)
                {
                    _editOrNewCustomer = value;
                }
                Notify("editOrNewCustomer");
            }
        }

        public ClassOrder order
        {
            get { return _order; }
            set
            {
                if (_order != value)
                {
                    _order = value;
                }
                Notify("order");
            }
        }

        public bool isEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (_isEnabled != value)
                {
                    _isEnabled = value;
                }
                Notify("isEnabled");
            }
        }

        public int Number1
        {
            get { return _Number1; }
            set
            {
                if (_Number1 != value)
                {
                    _Number1 = value;
                }
                Notify("Number1");
            }
        }

        public int Number2
        {
            get { return _Number2; }
            set
            {
                if (_Number2 != value)
                {
                    _Number2 = value;
                }
                Notify("Number2");
            }
        }

        public int CalcResAddition()
        {
            return Number1 + Number2;
        }

        public void UpdateListCustomer()
        {

        }

        public async Task<ClassApiRates> GetApiRates()
        {
            ClassApiRates temp = new ClassApiRates();

            return temp;
        }

        public void SetUpListCustomer()
        {
            listCustomer = CMGDB.GetAllCustomersFromDB();
        }

        public int SaveNewCustomer()
        {
            return CMGDB.SaveNewCustomerInDB(editOrNewCustomer);
            // CMGDB.GetAllCustomersFromDB();
        }

        public void UpdateCustomer()
        {
            CMGDB.UpdateCustomerInDB(editOrNewCustomer);
        }

        public void SaveSaleInDB()
        {

        }

        public void SaveNewMeatPrice(string inMeat, double inPrice, int inWeight)
        {

        }

        private void SetUpListCountry()
        {

        }
    }
}
