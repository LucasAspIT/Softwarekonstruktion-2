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
    /// Interaction logic for UserControlMeatPriceUpdate.xaml
    /// </summary>
    public partial class UserControlMeatPriceUpdate : UserControl
    {
        ClassBIZ BIZ;
        Grid gridLeft;
        Grid gridRight;

        public UserControlMeatPriceUpdate(ClassBIZ inBIZ, Grid inGrid)
        {
            InitializeComponent();
            BIZ = inBIZ;
            gridRight = inGrid;
            // MainGrid.DataContext = BIZ;
        }

        private void buttonGemGris_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGemKalv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGemOkse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGemKylling_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGemKalkun_Click(object sender, RoutedEventArgs e)
        {

        }

        private void buttonGemHest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void buttonExitUpdateMeat_Click(object sender, RoutedEventArgs e)
        {
            gridRight.Children.Remove(this);
        }
    }
}
