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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        ClassTextBoxHandler CTBH;

        public MainWindow()
        {
            InitializeComponent();
            CTBH = new ClassTextBoxHandler();
            MainGrid.DataContext = CTBH;
        }

        private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TextBox myTextBox = (TextBox)sender;

            if (CTBH.RegTextBoxClick(myTextBox.Tag.ToString()))
            {
                UserControlWinner UCW = new UserControlWinner(CTBH, this.WinnerGrid);
                WinnerGrid.Children.Add(UCW);
            }
        }
    }
}
