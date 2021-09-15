﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassCustomer : ClassNotify
    {
        private int _id;
        private string _companyName;
        private string _address;
        private string _zipCity;
        private string _phone;
        private string _mail;
        private string _contactName;
        private ClassCountry _country;

        public ClassCustomer()
        {
            id = 0;
            companyName = "";
            address = "";
            zipCity = "";
            phone = "";
            mail = "";
            contactName = "";
            country = new ClassCountry();
        }

        public ClassCustomer(ClassCustomer inClassCustomer)
        {
            id = inClassCustomer.id;
            companyName = inClassCustomer.companyName;
            address = inClassCustomer.address;
            zipCity = inClassCustomer.zipCity;
            phone = inClassCustomer.phone;
            mail = inClassCustomer.mail;
            contactName = inClassCustomer.contactName;
            country = new ClassCountry(inClassCustomer.country);
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


        public string companyName
        {
            get { return _companyName; }
            set
            {
                if (_companyName != value)
                {
                    _companyName = value;
                }
                Notify("companyName");
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


        public string phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                }
                Notify("phone");
            }
        }


        public string mail
        {
            get { return _mail; }
            set
            {
                if (_mail != value)
                {
                    _mail = value;
                }
                Notify("mail");
            }
        }


        public string contactName
        {
            get { return _contactName; }
            set
            {
                if (_contactName != value)
                {
                    _contactName = value;
                }
                Notify("contactName");
            }
        }


        public ClassCountry country
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

    }
}
