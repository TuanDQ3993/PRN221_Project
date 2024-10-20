using Microsoft.EntityFrameworkCore;
using ProjectPRN221_GroupJQK.Models;
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
using System.Windows.Shapes;

namespace ProjectPRN221_GroupJQK
{
    /// <summary>
    /// Interaction logic for ManageBook.xaml
    /// </summary>
    public partial class ManageBook : Page
    {
        public ManageBook()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            load();
        }
        private void load()
        {
            var books = PRN221_LibContext.Ins.Books.Include(x => x.Author).Include(x => x.Category).Include(x => x.Publisher).ToList();
            dgvBook.ItemsSource = books;
        }

        
    }
}
