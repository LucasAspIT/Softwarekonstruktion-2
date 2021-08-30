using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using IO;
using Repository;
using System.Diagnostics;

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
            _listMaterials = new List<ClassMaterial>();
            _listSelectedBoxes = new ObservableCollection<ClassBox>();
            _listSelectedMaterials = new ObservableCollection<ClassMaterial>();
            _selectedBox = new ClassBox();
            _selectedMaterial = new ClassMaterial();
            CFH = new ClassFileHandler();
            SetUpMaterialList();
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
                Notify("listSelectedMaterials");
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
                Notify("selectedBox");
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
            listSelectedBoxes.Add(new ClassBox(selectedBox));
        }

        public void AddMaterialToSelectedList()
        {
            listSelectedMaterials.Add(new ClassMaterial(selectedMaterial));
        }

        public void MakeReportFile()
        {
            string strReport = $"\n\n\t\t{DateTime.Now.ToString("dd-MM-yyyy")} - FLYDEBOKS RAPPORT\n\n";

            foreach (ClassMaterial material in listSelectedMaterials)
            {
                strReport += $" - - {material.materialDim} mm. {material.materialName}\n\n";
                strReport += $"\t\tHeight\t\tWidth\t\tDepth\t\t\t\tBuoyancy\t\t\t\t\tBox Weight\t\t\t% above the water surface\n";
                foreach (ClassBox box in listSelectedBoxes)
                {
                    ClassBox tempBox = new ClassBox(box, material);
                    strReport += $"\t\t{tempBox.boxHeight}\t\t\t{tempBox.boxWidth}\t\t\t{tempBox.boxDepth}\t\t\t=\t\t{tempBox.boxBuoyancy.ToString("#0.0000")}" +
                                 $" kg.\t\t#\t\t{tempBox.boxWeight.ToString("#0.0000")}\t\t\t\t{CalculatePercentageAboveTheWaterSurface(tempBox)} \n";
                }
                strReport += $"\n * * * * * * *\n\n";
            }

            string filePath = CFH.WriteTextToFile(strReport);

            Process.Start(filePath);
        }

        private string CalculatePercentageAboveTheWaterSurface(ClassBox inBox)
        {
            string res = "";

            double calcRes = ((inBox.boxVolume * 1000) - inBox.boxWeight) * 100 / (inBox.boxVolume * 1000);

            if (calcRes < 0)
            {
                calcRes = 0;
            }

            res = calcRes.ToString("#0.00");

            return res;
        }

        private void SetUpMaterialList()
        {
            listMaterials.Add(new ClassMaterial("Træ", 0.987, 0));
            listMaterials.Add(new ClassMaterial("Plast", 3.378, 0));
            listMaterials.Add(new ClassMaterial("Glas", 14.251, 0));
            listMaterials.Add(new ClassMaterial("Jern", 25.477, 0));
        }
    }
}
