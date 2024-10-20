using ProjectPRN221_GroupJQK.Models;
using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Password;

            var user = PRN221_LibContext.Ins.Users
                       .SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                if (user.Role != null)
                {
                    if (user.Role == 1)
                    {
                        Admin admin=new Admin();
                        admin.Show();
                        this.Hide();


                    }
                    else
                    {
                        
                    }

                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }



        }

    }
}