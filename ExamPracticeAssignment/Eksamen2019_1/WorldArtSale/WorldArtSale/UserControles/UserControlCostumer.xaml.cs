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

namespace GUI
{
    /// <summary>
    /// Interaction logic for UserControlCostumer.xaml
    /// </summary>
    public partial class UserControlCostumer : UserControl
    {
        ClassBIZ BIZ;

        public UserControlCostumer(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
            GridCostumer.DataContext = BIZ;
        }

        private void buttonNewCustomer_Click(object sender, RoutedEventArgs e)
        {
            OpenAllTextBoxForEdit();
            BIZ.classCustomer = new ClassCustomer();
        }

        private void OpenAllTextBoxForEdit()
        {
            textBoxName.IsReadOnly = false;
            textBoxAddress.IsReadOnly = false;
            textBoxZipCity.IsReadOnly = false;
            textBoxCountry.IsReadOnly = false;
            textBoxMail.IsReadOnly = false;
            textBoxPhone.IsReadOnly = false;
            textBoxMaxBid.IsReadOnly = false;
            buttonCreateUpdate.Visibility = Visibility.Visible;
            buttonCancel.Visibility = Visibility.Visible;
            buttonNewCustomer.Visibility = Visibility.Hidden;
            buttonEditCustomer.Visibility = Visibility.Hidden;
        }

        private void CloseAllTextBoxForEdit()
        {
            textBoxName.IsReadOnly = true;
            textBoxAddress.IsReadOnly = true;
            textBoxZipCity.IsReadOnly = true;
            textBoxCountry.IsReadOnly = true;
            textBoxMail.IsReadOnly = true;
            textBoxPhone.IsReadOnly = true;
            textBoxMaxBid.IsReadOnly = true;
            buttonCreateUpdate.Visibility = Visibility.Hidden;
            buttonCancel.Visibility = Visibility.Hidden;
            buttonNewCustomer.Visibility = Visibility.Visible;
            buttonEditCustomer.Visibility = Visibility.Visible;
        }

        private void buttonCreateUpdate_Click(object sender, RoutedEventArgs e)
        {
            BIZ.SaveCustomerToDB();
            CloseAllTextBoxForEdit();
        }
    }
}
