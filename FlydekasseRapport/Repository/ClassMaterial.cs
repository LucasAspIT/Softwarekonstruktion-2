using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassMaterial : ClassNotify
    {
        int _materialDim;
        string _materialName;
        double _materialWeight;

        /// <summary>
        /// Default constructor with initialised default values.
        /// </summary>
        public ClassMaterial()
        {
            materialDim = 0;
            materialName = "";
            materialWeight = 0D;
        }

        /// <summary>
        /// Overloaded constructor that takes an instance of a ClassMaterial and creates a new copy, with no references between the new ClassMaterial and the inMaterial parameter.
        /// </summary>
        /// <param name="inMaterial"></param>
        public ClassMaterial(ClassMaterial inMaterial)
        {
            materialDim = inMaterial.materialDim;
            materialName = inMaterial.materialName;
            materialWeight = inMaterial.materialWeight;
        }

        /// <summary>
        /// Overlaoded constructor that takes the parameters (arguments) and creates a new instance of a ClassMaterial.
        /// </summary>
        /// <param name="inName"></param>
        /// <param name="inWeight"></param>
        /// <param name="inDim"></param>
        public ClassMaterial(string inName, double inWeight, int inDim)
        {
            materialDim = inDim;
            materialName = inName;
            materialWeight = inWeight;
        }

        public int materialDim
        {
            get { return _materialDim; }
            set
            {
                if (_materialDim != value)
                {
                    _materialDim = value;
                }
                Notify("materialDim");
            }
        }

        public string materialName
        {
            get { return _materialName; }
            set
            {
                if (_materialName != value)
                {
                    _materialName = value;
                }
                Notify("materialName");
            }
        }

        public double materialWeight
        {
            get { return _materialWeight; }
            set
            {
                if (_materialWeight != value)
                {
                    _materialWeight = value;
                }
                Notify("materialWeight");
            }
        }

    }
}
