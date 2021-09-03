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
using ExchangeRates.UserControls;

namespace ExchangeRates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ BIZ;
        UserControlValuta UCV;

        /// <summary>
        /// InitializeComponent() er et kald til metoden i classen Window som bygger brugergrænsefladen til noget der kan grafisk vises på en skærm.
        /// Dette metodekald skal *altid* stå først i constructoren.
        /// 
        /// I constructoren initialiseres den tomme instant af ClassBIZ.
        /// 
        /// MainGrid.DataContext = BIZ; Her oprettes forbindelsen mellem GUI og ClassBIZ hvor man finder de properties der holder de værdier/data der skal vises på brugergrænsefladen.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            BIZ = new ClassBIZ();
            UCV = new UserControlValuta(BIZ);
            MainGrid.Children.Add(UCV);
        }
    }
}
