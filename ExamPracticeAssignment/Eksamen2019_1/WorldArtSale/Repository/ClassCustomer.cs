﻿using System;
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
        private string _maxBid;
        private ClassCountry _classCountry;


        public ClassCustomer()
        {
            customerID = 0;
            name = "";
            address = "";
            zipCity = "";
            country = "";
            email = "";
            phoneNo = "";
            customerCurrencyID = "";
            maxBid = "";
            classCountry = new ClassCountry();
        }

        public ClassCustomer(ClassCustomer inCustomer)
        {
            customerID = inCustomer.customerID;
            name = inCustomer.name;
            address = inCustomer.address;
            zipCity = inCustomer.zipCity;
            country = inCustomer.country;
            email = inCustomer.email;
            phoneNo = inCustomer.phoneNo;
            maxBid = inCustomer.maxBid;
            customerCurrencyID = inCustomer.customerCurrencyID;
            classCountry = new ClassCountry(inCustomer.classCountry);
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

        public string maxBid
        {
            get { return _maxBid; }
            set
            {
                if (_maxBid != value)
                {
                    _maxBid = value;
                }
                Notify("maxBid");
            }
        }

        public ClassCountry classCountry
        {
            get { return _classCountry; }
            set
            {
                if (_classCountry != value)
                {
                    _classCountry = value;
                }
                Notify("classCountry");
            }
        }
    }
}
