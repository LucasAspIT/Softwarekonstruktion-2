using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassBox : ClassNotify
    {
        private double _boxBuoyancy;
        private double _boxDepth;
        private double _boxHeight;
        private ClassMaterial _boxMaterial;
        private double _boxVolume;
        private double _boxWeight;
        private double _boxWide;
        private string _strBoxDepth;
        private string _strBoxHeight;
        private string _strBoxWide;

        /// <summary>
        /// Default constructor with initialised default values.
        /// </summary>
        public ClassBox()
        {
            boxBuoyancy = 0D;
            boxDepth = 0D;
            boxHeight = 0D;
            boxMaterial = new ClassMaterial(); 
            boxVolume = 0D;
            boxWeight = 0D;
            boxWide = 0D;
            strBoxDepth = "";
            strBoxHeight = "";
            strBoxWide = "";
        }

        /// <summary>
        /// Overloaded constructor that takes an instance of a ClassBox and creates a new copy, with no references between the new ClassBox and the inClassbox parameter.
        /// </summary>
        /// <param name="inClassbox"></param>
        public ClassBox(ClassBox inClassbox)
        {
            boxBuoyancy = inClassbox.boxBuoyancy;
            boxDepth = inClassbox.boxDepth;
            boxHeight = inClassbox.boxHeight;
            boxMaterial = new ClassMaterial(inClassbox.boxMaterial);
            boxVolume = inClassbox.boxVolume;
            boxWeight = inClassbox.boxWeight;
            boxWide = inClassbox.boxWide;
            strBoxDepth = inClassbox.strBoxDepth;
            strBoxHeight = inClassbox.strBoxHeight;
            strBoxWide = inClassbox.strBoxWide;
        }

        /// <summary>
        /// Overloaded constructor that takes and instance of a ClassBox and ClassMaterial to create a new copy, with no references between the new ClassBox and the input inClassbox and inClassMaterial.
        /// <br>This constructor is only used for "printing" a report.</br>
        /// </summary>
        /// <param name="inClassbox"></param>
        /// <param name="inClassMaterial"></param>
        public ClassBox(ClassBox inClassbox, ClassMaterial inClassMaterial)
        {
            boxBuoyancy = inClassbox.boxBuoyancy;
            boxDepth = inClassbox.boxDepth;
            boxHeight = inClassbox.boxHeight;
            boxMaterial = new ClassMaterial(inClassMaterial);
            boxVolume = inClassbox.boxVolume;
            boxWeight = inClassbox.boxWeight;
            boxWide = inClassbox.boxWide;
            strBoxDepth = inClassbox.strBoxDepth;
            strBoxHeight = inClassbox.strBoxHeight;
            strBoxWide = inClassbox.strBoxWide;
        }

        public double boxBuoyancy
        {
            get { return _boxBuoyancy; }
            set
            {
                if (_boxBuoyancy != value)
                {
                    _boxBuoyancy = value;
                }
                Notify("boxBuoyancy");
            }
        }


        public double boxDepth
        {
            get { return _boxDepth; }
            set
            {
                if (_boxDepth != value)
                {
                    _boxDepth = value;
                }
                Notify("boxDepth");
            }
        }


        public double boxHeight
        {
            get { return _boxHeight; }
            set
            {
                if (_boxHeight != value)
                {
                    _boxHeight = value;
                }
                Notify("boxHeight");
            }
        }


        public ClassMaterial boxMaterial
        {
            get { return _boxMaterial; }
            set
            {
                if (_boxMaterial != value)
                {
                    _boxMaterial = value;
                }
                Notify("boxMaterial");
            }
        }


        public double boxVolume
        {
            get { return _boxVolume; }
            set
            {
                if (_boxVolume != value)
                {
                    _boxVolume = value;
                }
                Notify("boxVolume");
            }
        }



        public double boxWeight
        {
            get { return _boxWeight; }
            set
            {
                if (_boxWeight != value)
                {
                    _boxWeight = value;
                }
                Notify("boxWeight");
            }
        }


        public double boxWide
        {
            get { return _boxWide; }
            set
            {
                if (_boxWide != value)
                {
                    _boxWide = value;
                }
                Notify("boxWide");
            }
        }


        public string strBoxDepth
        {
            get { return _strBoxDepth; }
            set
            {
                if (_strBoxDepth != value)
                {
                    _strBoxDepth = value;
                }
                Notify("strBoxDepth");
            }
        }


        public string strBoxHeight
        {
            get { return _strBoxHeight; }
            set
            {
                if (_strBoxHeight != value)
                {
                    _strBoxHeight = value;
                }
                Notify("strBoxHeight");
            }
        }


        public string strBoxWide
        {
            get { return _strBoxWide; }
            set
            {
                if (_strBoxWide != value)
                {
                    _strBoxWide = value;
                }
                Notify("strBoxWide");
            }
        }

        public void CalculateAllBox()
        {

        }

        public void CalculateMaterialBox()
        {

        }
    }
}
