using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using IO;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        private List<ClassMaterial> _listMaterials;
        private ObservableCollection<ClassBox> _listSelectedBoxes;
        private ObservableCollection<ClassMaterial> _listSelectedMaterials;
        private ClassBox _selectedBox;
        private ClassMaterial _selectedMaterial;

        private ClassFileHandler CFH;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ClassBIZ()
        {

        }

        public List<ClassMaterial> listMaterials
        {
            get { return _listMaterials; }
            set
            {
                if (_listMaterials != value)
                {
                    _listMaterials = value;
                }
                Notify("listMaterials");
            }
        }

        public ObservableCollection<ClassBox> listSelectedBoxes
        {
            get { return _listSelectedBoxes; }
            set
            {
                if (_listSelectedBoxes != value)
                {
                    _listSelectedBoxes = value;
                }
                Notify("listSelectedBoxes");
            }
        }

        public ObservableCollection<ClassMaterial> listSelectedMaterials
        {
            get { return _listSelectedMaterials; }
            set
            {
                if (_listSelectedMaterials != value)
                {
                    _listSelectedMaterials = value;
                }
                Notify("_listSelectedMaterials");
            }
        }

        public ClassBox selectedBox
        {
            get { return _selectedBox; }
            set
            {
                if (_selectedBox != value)
                {
                    _selectedBox = value;
                }
                Notify("_selectedBox");
            }
        }
        public ClassMaterial selectedMaterial
        {
            get { return _selectedMaterial; }
            set
            {
                if (_selectedMaterial != value)
                {
                    _selectedMaterial = value;
                }
                Notify("selectedMaterial");
            }
        }

        public void AddBoxToSelectedList()
        {

        }

        public void AddMaterialToSelectedList()
        {

        }

        public void MakeReportFile()
        {

        }

        private string CalculatePercentageAboveTheWaterSurface(ClassBox inBox)
        {
            string res = "";

            return res;
        }

        private void SetUpMaterialList()
        {

        }
    }
}
