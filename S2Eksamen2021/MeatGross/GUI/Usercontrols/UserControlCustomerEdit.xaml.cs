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

namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlCustomerEdit.xaml
    /// </summary>
    public partial class UserControlCustomerEdit : UserControl
    {
        ClassBIZ BIZ;
        Grid gridLeft;
        Grid gridRight;

        public UserControlCustomerEdit(ClassBIZ inBIZ, Grid inGrid)
        {
            InitializeComponent();
            BIZ = inBIZ;
            gridLeft = inGrid;
            // MainGrid.DataContext = BIZ;

        }

        private void buttonSaveCustomer_Click(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Save nothing, and remove the overlaying UserControl.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonRegret_Click(object sender, RoutedEventArgs e)
        {
            gridLeft.Children.Remove(this);
        }

        private void SaveCustomerData()
        {

        }
    }
}
