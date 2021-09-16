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
using Repository;

namespace GUI.Usercontrols
{
    /// <summary>
    /// Interaction logic for UserControlCustomer.xaml
    /// </summary>
    public partial class UserControlCustomer : UserControl
    {
        ClassBIZ BIZ;
        Grid gridLeft;
        Grid gridRight;
        UserControlCustomerEdit UCCE;

        public UserControlCustomer(ClassBIZ inBIZ, Grid inGrid, UserControlCustomerEdit inUC)
        {
            InitializeComponent();
            BIZ = inBIZ;
            gridLeft = inGrid;
            UCCE = inUC;
            MainGrid.DataContext = BIZ;
        }

        /// <summary>
        /// Open the UserControl UCCE to edit the currently selected customer in the ComboBox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (BIZ.selectedCustomer != null && BIZ.selectedCustomer.id > 0) // Can only edit if a customer is selected, otherwise do nothing
            {
            BIZ.editOrNewCustomer = new ClassCustomer(BIZ.selectedCustomer); // Keep the selected customer's data as we want to edit it
            gridLeft.Children.Add(UCCE);
            }
        }

        /// <summary>
        /// Open the UserControl UCCE so a new customer can be added.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            BIZ.editOrNewCustomer = new ClassCustomer(); // Empty the selected customer's data as we want to create a new customer
            gridLeft.Children.Add(UCCE);
        }
    }
}
