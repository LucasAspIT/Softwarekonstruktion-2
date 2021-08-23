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
    /// Interaction logic for UserControlWinner.xaml
    /// </summary>
    public partial class UserControlWinner : UserControl
    {
        private Grid _grid;
        private ClassTextBoxHandler _ctbh;

        public UserControlWinner(ClassTextBoxHandler CTBH, Grid inGrid)
        {
            InitializeComponent();
            _grid = inGrid;
            _ctbh = CTBH;

            if (_ctbh.actualSign.ToUpper() == "O")
            {
                labelWinnerText.Content = "Tillykke, O vandt";
                labelWinnerText.Background = Brushes.Red;
                labelWinnerText.Foreground = Brushes.Yellow;
            }
            else
            {
                labelWinnerText.Content = "Tillykke, X vandt";
                labelWinnerText.Background = Brushes.Blue;
                labelWinnerText.Foreground = Brushes.Yellow;
            }
        }

        private void labelWinnerText_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _ctbh.ResetAll();
            _grid.Children.Clear();
        }
    }
}
