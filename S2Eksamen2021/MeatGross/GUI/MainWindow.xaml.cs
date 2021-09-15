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

        Usercontrols.UserControlCustomer UCCustomer;
        Usercontrols.UserControlOrderMeat UCOrderMeat;
        Usercontrols.UserControlCustomerEdit UCCustomerEdit;
        Usercontrols.UserControlMeatPriceUpdate UCMeatPriceUpdate;

        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();

            UCCustomerEdit = new Usercontrols.UserControlCustomerEdit(BIZ, LeftGrid);
            UCCustomer = new Usercontrols.UserControlCustomer(BIZ, LeftGrid, UCCustomerEdit);
            UCOrderMeat = new Usercontrols.UserControlOrderMeat(BIZ, RightGrid, UCMeatPriceUpdate);
            UCMeatPriceUpdate = new Usercontrols.UserControlMeatPriceUpdate(BIZ, RightGrid);

            LeftGrid.Children.Add(UCCustomer);
            RightGrid.Children.Add(UCOrderMeat);
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // await BIZ.StartCurrencyApiCall();
        }
    }
}
