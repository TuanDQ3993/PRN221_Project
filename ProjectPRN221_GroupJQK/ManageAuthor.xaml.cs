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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPRN221_GroupJQK
{
    /// <summary>
    /// Interaction logic for ManageAuthor.xaml
    /// </summary>
    public partial class ManageAuthor : Page
    {
        public ManageAuthor()
        {
            InitializeComponent();
        }
        string[] elements = { "Name" };
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            load();
            cbSearchBy.ItemsSource = elements;
            cbSearchBy.SelectedIndex = 0;
        }

        private void load()
        {
            var authors = PRN221_LibContext.Ins.Authors.Select(x => new
            {
                AuthorId=x.AuthorId,
                AuthorName=x.AuthorName,
            }).ToList();
            dgvAuthor.ItemsSource = authors;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text;
            string searchBy = cbSearchBy.SelectedItem.ToString();

            var query = PRN221_LibContext.Ins.Authors.AsQueryable();
            if (searchBy == "Name")
            {
                query = query.Where(author => author.AuthorName.Contains(keyword));
            }


            // Hiển thị kết quả tìm kiếm
            dgvAuthor.ItemsSource = query.ToList();
        }
    }
}
