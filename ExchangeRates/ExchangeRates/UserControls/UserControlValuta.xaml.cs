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

namespace ExchangeRates.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlValuta.xaml
    /// </summary>
    public partial class UserControlValuta : UserControl
    {
        ClassBIZ BIZ;

        public UserControlValuta(ClassBIZ inBIZ)
        {
            InitializeComponent();
            BIZ = inBIZ;
            MainGrid.DataContext = BIZ;
        }
    }
}
