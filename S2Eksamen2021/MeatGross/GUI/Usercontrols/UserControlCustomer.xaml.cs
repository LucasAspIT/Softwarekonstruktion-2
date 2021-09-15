﻿using System;
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

        private void buttonEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            gridLeft.Children.Add(UCCE);
        }

        private void buttonNewCustomer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
