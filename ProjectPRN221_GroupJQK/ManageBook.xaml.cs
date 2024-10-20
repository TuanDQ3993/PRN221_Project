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

        string[] elements = { "Title", "Author", "Publisher", "Year" };

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            load();
            loadCategory();
            cbSearchBy.ItemsSource = elements;
            cbSearchBy.SelectedIndex = 0;
        }
        private void load()
        {
            var books = PRN221_LibContext.Ins.Books.Include(x => x.Author).Include(x => x.Category).Include(x => x.Publisher).ToList();
            dgvBook.ItemsSource = books;
        }

        private void loadCategory()
        {
            var cate = PRN221_LibContext.Ins.Categories.Select(x => x.CategoryName).ToList();
            cbCategory.ItemsSource = cate;
            cate.Insert(0, "All");
            cbCategory.SelectedIndex = 0;

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text; 
            string searchBy = cbSearchBy.SelectedItem.ToString(); 

            var query = PRN221_LibContext.Ins.Books.AsQueryable(); 
            if (searchBy == "Title")
            {
                query = query.Where(book => book.Title.Contains(keyword));
            }
            else if (searchBy == "Author")
            {
                query = query.Where(book => book.Author.AuthorName.Contains(keyword));
            }
            else if (searchBy == "Publisher")
            {
                query = query.Where(book => book.Publisher.PublisherName.Contains(keyword));
            }
            else if (searchBy == "Year")
            {
                if (int.TryParse(keyword, out int year))
                {
                    query = query.Where(book => book.YearPublished == year);
                }
                else
                {
                    MessageBox.Show("Please enter a valid year", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            // Hiển thị kết quả tìm kiếm
            dgvBook.ItemsSource = query.ToList();
        }

        private void cbCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedCategory = cbCategory.SelectedItem.ToString(); 
            var query = PRN221_LibContext.Ins.Books.AsQueryable();

            if (selectedCategory != "All")
            {
                query = query.Where(book => book.Category.CategoryName == selectedCategory); 
            }
            dgvBook.ItemsSource = query.ToList();
        }
    }
}
