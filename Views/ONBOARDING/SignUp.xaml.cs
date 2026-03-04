using System.Windows;
using System.Windows.Controls;
using WpfAppDemo.Models;
using WpfAppDemo.Repositories;

namespace WpfAppDemo.Views.OnBoarding
{
    public partial class SignUp : Page
    {
        private UserRepository _userRepository = new UserRepository();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            string FirstName = txtFirstName.Text.Trim();
            string LastName = txtLastName.Text.Trim();
            string Email = txtNewUserName.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string ConfirmPassword = txtConfirmedPassword.Text.Trim();

            // Check if all fields are filled.
            if (string.IsNullOrEmpty(FirstName) || 
                string.IsNullOrEmpty(LastName) ||
                string.IsNullOrEmpty(Email) || 
                string.IsNullOrEmpty(Password) ||
                string.IsNullOrEmpty(ConfirmPassword))
            {
                MessageBox.Show("Please fill in all fields.",
                                "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            // Check if the confirmed password matches the original password.
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Password does not match.",
                                "Warning",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }
            
            User useracc = new User
            {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
            this._userRepository.Save_Info(useracc); // Save the new user information to the database.
            MessageBox.Show("Account created successfully!");
            NavigationService.Navigate(new LogIn());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }
    }
}
