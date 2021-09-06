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
        UserControlExchangerates userControlExchangerates;
        UserControlCostumer userControlCostumer;
        UserControlAuctionItem userControlAuctionItem;
        UserControlBidCalculation userControlBidCalculation;
        ClassBIZ BIZ;

        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();

            userControlExchangerates = new UserControlExchangerates(BIZ);
            userControlCostumer = new UserControlCostumer(BIZ);
            userControlAuctionItem = new UserControlAuctionItem(BIZ);
            userControlBidCalculation = new UserControlBidCalculation(BIZ);

            GridBottom.Children.Add(userControlExchangerates);
            GridTopLeft.Children.Add(userControlCostumer);
            GridTopRight.Children.Add(userControlAuctionItem);
            GridTopMiddle.Children.Add(userControlBidCalculation);
        }
    }
}