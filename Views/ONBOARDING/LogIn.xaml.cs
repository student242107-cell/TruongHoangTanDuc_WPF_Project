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
using WpfAppDemo.Repositories;
using WpfAppDemo.Views.HOME;
using WpfAppDemo.Models;

namespace WpfAppDemo.Views.OnBoarding
{
    public partial class LogIn : Page
    {
        private readonly UserRepository _userRepository = new UserRepository();
        public LogIn()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Check if the Username and Password are entered.
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both email and password.",
                                "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            // Check if the entered Username and Password are all correct.
            User? _user = this._userRepository.FindByUserName(email);
            if (_user == null || _user.Password != password)
            {
                MessageBox.Show("Invalid email or password.",
                                "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }
            NavigationService.Navigate(new Home(_user));
        }

        private void NewAcc_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SignUp());
        }
    }
}
