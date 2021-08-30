using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BIZ;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ BIZ;
        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();
            MainGrid.DataContext = BIZ;
        }

        private void buttonAddMaterialToList_Click(object sender, RoutedEventArgs e)
        {
            if (BIZ.selectedMaterial.materialWeight > 0 && BIZ.selectedMaterial.materialDim > 0) // Make sure thickness is bigger than zero
            {
                BIZ.AddMaterialToSelectedList();
            }
        }

        private void buttonAddDimensionsToList_Click(object sender, RoutedEventArgs e)
        {
            if (BIZ.selectedBox.boxHeight > 0 && BIZ.selectedBox.boxWidth > 0 && BIZ.selectedBox.boxDepth > 0)
            {
                BIZ.AddBoxToSelectedList();
            }
        }

        private void buttonMakeReportAndShow_Click(object sender, RoutedEventArgs e)
        {
            BIZ.MakeReportFile();
        }
    }
}
