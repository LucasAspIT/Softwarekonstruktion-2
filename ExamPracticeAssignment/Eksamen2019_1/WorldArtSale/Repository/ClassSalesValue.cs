﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassSalesValue : ClassNotify
    {
        private string _bidUSD;
        private string _bidEUR;
        private string _bidOwnValuta;
        private string _priceWithFeeUSD;
        private string _priceWithFeeEUR;
        private string _priceWithFeeOwnValuta;
        private ClassCurrency _classCurrency;

        public ClassSalesValue()
        {
            _bidUSD = "";
            _bidEUR = "";
            _bidOwnValuta = "";
            _priceWithFeeUSD = "";
            _priceWithFeeEUR = "";
            _priceWithFeeOwnValuta = "";
            _classCurrency = new ClassCurrency();
        }


        public string bidUSD
        {
            get { return _bidUSD; }
            set
            {
                if (_bidUSD != value)
                {
                    _bidUSD = value;
                }
                Notify("bidUSD");
            }
        }


        public string bidEUR
        {
            get { return _bidEUR; }
            set
            {
                if (_bidEUR != value)
                {
                    _bidEUR = value;
                }
                Notify("bidEUR");
            }
        }


        public string bidOwnValuta
        {
            get { return _bidOwnValuta; }
            set
            {
                if (_bidOwnValuta != value)
                {
                    _bidOwnValuta = value;
                }
                Notify("bidOwnValuta");
            }
        }


        public string priceWithFeeUSD
        {
            get { return _priceWithFeeUSD; }
            set
            {
                if (_priceWithFeeUSD != value)
                {
                    _priceWithFeeUSD = value;
                }
                Notify("priceWithFeeUSD");
            }
        }


        public string priceWithFeeEUR
        {
            get { return _priceWithFeeEUR; }
            set
            {
                if (_priceWithFeeEUR != value)
                {
                    _priceWithFeeEUR = value;
                }
                Notify("priceWithFeeEUR");
            }
        }


        public string priceWithFeeOwnValuta
        {
            get { return _priceWithFeeOwnValuta; }
            set
            {
                if (_priceWithFeeOwnValuta != value)
                {
                    _priceWithFeeOwnValuta = value;
                }
                Notify("priceWithFeeOwnValuta");
            }
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

    }
}
