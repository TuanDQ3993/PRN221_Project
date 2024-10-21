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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectPRN221_GroupJQK
{
    /// <summary>
    /// Interaction logic for ManageUser.xaml
    /// </summary>
    public partial class ManageUser : Page
    {
        public ManageUser()
        {
            InitializeComponent();
        }

        string[] elements = { "Name", "Email", "Phone", "Address" };
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            load();
            cbSearchBy.ItemsSource = elements;
            cbSearchBy.SelectedIndex = 0;
            loadRole();
        }

        private void load()
        {
            var users = PRN221_LibContext.Ins.Users.Include(u=>u.RoleNavigation).ToList();
            dgvUser.ItemsSource = users;
        }
        private void loadRole()
        {
            var role = PRN221_LibContext.Ins.Roles.Select(r => r.RoleName).ToList();
            cbRole.ItemsSource = role;
            role.Insert(0, "All");
            cbRole.SelectedIndex = 0;

        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text;
            string searchBy = cbSearchBy.SelectedItem.ToString();

            var query = PRN221_LibContext.Ins.Users.AsQueryable();
            if (searchBy == "Name")
            {
                query = query.Where(user => user.FullName.Contains(keyword));
            }
            else if (searchBy == "Email")
            {
                query = query.Where(user => user.Email.Contains(keyword));
            }
            else if (searchBy == "Phone")
            {
                query = query.Where(user => user.PhoneNumber.Contains(keyword));
            }
            else if (searchBy == "Address")
            {
                query = query.Where(user => user.Address.Contains(keyword));
            }

            // Hiển thị kết quả tìm kiếm
            dgvUser.ItemsSource = query.ToList();
        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedRole = cbRole.SelectedItem.ToString();
            var query = PRN221_LibContext.Ins.Users.AsQueryable();

            if (selectedRole != "All")
            {
                query = query.Where(user => user.RoleNavigation.RoleName == selectedRole);
            }
            dgvUser.ItemsSource = query.ToList();
        }
    }
}
