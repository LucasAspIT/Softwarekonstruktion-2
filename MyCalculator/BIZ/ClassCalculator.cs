using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIZ
{
    public class ClassCalculator : ClassNotify
    {

        private double _resPlus;
        private double _resMinus;
        private double _resGange;
        private double _resDiv;
        private string _tal1;
        private string _tal2;


        public ClassCalculator()
        {
            tal1 = "0";
            tal2 = "0";
            tal1Doub = 0D;
            tal2Doub = 0D;
        }

        public double tal1Doub { get; set; }
        public double tal2Doub { get; set; }

        public string tal1
        {
            get { return _tal1; }
            set
            {
                if (_tal1 != value)
                {
                    if (value == "")
                    {
                        _tal1 = "";
                        tal1Doub = 0;
                        StartCalc();
                    }

                    if (value == "-")
                    {
                        _tal1 = "-";
                        tal1Doub = 0;
                        StartCalc();
                    }

                    if (double.TryParse(value, out double x))
                    {
                        _tal1 = value;
                        tal1Doub = x;
                        StartCalc();
                    }
                }
                Notify("tal1");
            }
        }

        public string tal2
        {
            get { return _tal2; }
            set
            {
                if (_tal2 != value)
                {
                    if (value == "")
                    {
                        _tal2 = "";
                        tal2Doub = 0;
                        StartCalc();
                    }
                    
                    if (value == "-")
                    {
                        _tal2 = "-";
                        tal2Doub = 0;
                        StartCalc();
                    }

                    if (double.TryParse(value, out double x))
                    {
                        _tal2 = value;
                        tal2Doub = x;
                        StartCalc();
                    }
                }
                Notify("tal2");
            }
        }


        public double resPlus
        {
            get { return _resPlus; }
            set
            {
                if (_resPlus != value)
                {
                    _resPlus = value;
                }
                Notify("resPlus");
            }
        }

        public double resMinus
        {
            get { return _resMinus; }
            set
            {
                if (_resMinus != value)
                {
                    _resMinus = value;
                }
                Notify("resMinus");
            }
        }

        public double resGange
        {
            get { return _resGange; }
            set
            {
                if (_resGange != value)
                {
                    _resGange = value;
                }
                Notify("resGange");
            }
        }


        public double resDiv
        {
            get { return _resDiv; }
            set
            {
                if (_resDiv != value)
                {
                    _resDiv = value;
                }
                Notify("resDiv");
            }
        }

        private void StartCalc()
        {
            resPlus = CalcResPlus();
            resMinus = CalcResMinus();
            resGange = CalcResGange();
            resDiv = CalcResDiv();
        }

        /// <summary>
        /// Adds two numbers together
        /// </summary>
        /// <returns>A double with the result</returns>
        public double CalcResPlus()
        {
            return tal1Doub + tal2Doub;
        }

        public double CalcResMinus()
        {
            return tal1Doub - tal2Doub;
        }

        public double CalcResGange()
        {
            return tal1Doub * tal2Doub;
        }

        public double CalcResDiv()
        {
            double res = 0D;

            if (tal2Doub != 0D)
            {
                res = tal1Doub / tal2Doub;
            }

            return res;
        }
    }
}
