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
        private double _boxWidth;
        private string _strBoxDepth;
        private string _strBoxHeight;
        private string _strBoxWidth;

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
            boxWidth = 0D;
            strBoxDepth = "";
            strBoxHeight = "";
            strBoxWidth = "";
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
            boxWidth = inClassbox.boxWidth;
            strBoxDepth = inClassbox.strBoxDepth;
            strBoxHeight = inClassbox.strBoxHeight;
            strBoxWidth = inClassbox.strBoxWidth;
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
            boxVolume = inClassbox.boxVolume;
            boxWeight = inClassbox.boxWeight;
            boxWidth = inClassbox.boxWidth;
            strBoxDepth = inClassbox.strBoxDepth;
            strBoxHeight = inClassbox.strBoxHeight;
            strBoxWidth = inClassbox.strBoxWidth;
            boxMaterial = new ClassMaterial(inClassMaterial);
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
                    CalculateAllBoxes();
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

        public double boxWidth
        {
            get { return _boxWidth; }
            set
            {
                if (_boxWidth != value)
                {
                    _boxWidth = value;
                }
                Notify("boxWidth");
            }
        }

        public string strBoxDepth
        {
            get { return _strBoxDepth; }
            set
            {
                if (_strBoxDepth != value)
                {
                    if (double.TryParse(value, out double x))
                    {
                        _strBoxDepth = value;
                        boxDepth = x;
                    }
                    if (value == "" || value == ",")
                    {
                        _strBoxDepth = value;
                    }
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
                    if (double.TryParse(value, out double x))
                    {
                        _strBoxHeight = value;
                        boxHeight = x;
                    }
                    if (value == "" || value == ",")
                    {
                        _strBoxHeight = value;
                    }
                }
                Notify("strBoxHeight");
            }
        }

        public string strBoxWidth
        {
            get { return _strBoxWidth; }
            set
            {
                if (_strBoxWidth != value)
                {
                    if (double.TryParse(value, out double x))
                    {
                        _strBoxWidth = value;
                        boxWidth = x;
                    }
                    if (value == "" || value == ",")
                    {
                    _strBoxWidth = value;
                    }
                }
                Notify("strBoxWidth");
            }
        }

        /// <summary>
        ///  Calculates the box volume and buoyancy.
        ///  <br>Results are saved in: boxVolume and boxBuoyancy</br>
        /// </summary>
        public void CalculateAllBoxes()
        {
            if (boxHeight > 0D && boxWidth > 0D && boxDepth > 0D) // Check if all values are above zero, otherwise it can't be calculated.
            {
                CalculateMaterialBoxes();
                boxVolume = boxHeight * boxWidth * boxDepth;
                boxBuoyancy = (boxVolume * 1000D) - boxWeight;
            }
        }

        /// <summary>
        /// Calculates the box weight.
        /// <br>Result is saved in: boxWeight</br>
        /// </summary>
        public void CalculateMaterialBoxes()
        {
            if (boxMaterial != null)
            {
                if (boxHeight > 0D && boxWidth > 0D && boxDepth > 0D) // Check if all values are above zero, otherwise it can't be calculated
                {
                    double matWeight = boxMaterial.materialWeight * 100D; // Takes the decimeter input and converts it to cubic metres.
                    double matDim = boxMaterial.materialDim / 1000D; // Takes the millimetre input and converts it to metres.

                    double mass1;
                    double mass2;

                    mass1 = boxHeight * boxWidth * boxDepth * matWeight; // Calculate the volume of the entire box
                    mass2 = (boxHeight - (matDim * 2D)) * (boxWidth - (matDim * 2D)) * (boxDepth - (matDim * 2D)) * matWeight; // Calculate the volume of the cavity (empty space) inside the box.

                    boxWeight = mass1 - mass2;
                }
            }
        }
    }
}
