﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace MTG_DeckBuilder
{
    /// <summary>
    /// Interaction logic for DeckBuilderWindow.xaml
    /// </summary>
    public partial class DeckBuilderWindow : Window
    {
        public DeckBuilderWindow()
        {
            InitializeComponent();

        }

        private void ExitMenuItem_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}