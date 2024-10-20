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
using System.Windows.Shapes;

namespace ProjectPRN221_GroupJQK
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnBooks_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManageBook());
        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManageUser());
        }

        private void btnAuthors_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManageAuthor());
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void btnCategories_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManageCategory());
        }

        private void btnPublishers_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManagePublisher());
        }

        private void btnTransactions_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Navigate(new ManageTransaction());
        }
    }
}
