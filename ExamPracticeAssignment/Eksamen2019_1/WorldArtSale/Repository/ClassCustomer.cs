using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCustomer : ClassNotify
    {
        private int _customerID;
        private string _name;
        private string _address;
        private string _zipCity;
        private string _country;
        private string _email;
        private string _phoneNo;
        private string _customerCurrencyID;

        public ClassCustomer()
        {
            _customerID = 0;
            _name = "";
            _address = "";
            _zipCity = "";
            _country = "";
            _email = "";
            _phoneNo = "";
            _customerCurrencyID = "";
        }


        public int customerID
        {
            get { return _customerID; }
            set
            {
                if (_customerID != value)
                {
                    _customerID = value;
                }
                Notify("customerID");
            }
        }


        public string name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                }
                Notify("name");
            }
        }


        public string address
        {
            get { return _address; }
            set
            {
                if (_address != value)
                {
                    _address = value;
                }
                Notify("address");
            }
        }


        public string zipCity
        {
            get { return _zipCity; }
            set
            {
                if (_zipCity != value)
                {
                    _zipCity = value;
                }
                Notify("zipCity");
            }
        }


        public string country
        {
            get { return _country; }
            set
            {
                if (_country != value)
                {
                    _country = value;
                }
                Notify("country");
            }
        }


        public string email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                }
                Notify("email");
            }
        }


        public string phoneNo
        {
            get { return _phoneNo; }
            set
            {
                if (_phoneNo != value)
                {
                    _phoneNo = value;
                }
                Notify("phoneNo");
            }
        }


        public string customerCurrencyID
        {
            get { return _customerCurrencyID; }
            set
            {
                if (_customerCurrencyID != value)
                {
                    _customerCurrencyID = value;
                }
                Notify("customerCurrencyID");
            }
        }

    }
}
