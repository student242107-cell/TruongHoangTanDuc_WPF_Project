using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WpfAppDemo.Models;
using WpfAppDemo.Repositories;
using WpfAppDemo.Views.OnBoarding;

namespace WpfAppDemo.Views.HOME
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        UserRepository userRepository = new UserRepository();
        private User? current_user;
        public HomePage()
        {
            InitializeComponent();
            current_user = new User();
        }
        public HomePage(User _user)
        {
            InitializeComponent();
            current_user = _user;
        }

        private void AboutMe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutMePage());
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogInPage());
        }
        private void DeleteAcount_Click(object sender, RoutedEventArgs e)
        {
            var Confirm_Delete = MessageBox.Show("Are you sure you want to delete your account?",
                                                "Confirm Deletion",
                                                MessageBoxButton.YesNo,
                                                MessageBoxImage.Warning);
            if (Confirm_Delete == MessageBoxResult.No)
                return;
            else
            {
                userRepository.Delete_Info(current_user);
                MessageBox.Show("Account deleted successfully.");
                NavigationService.Navigate(new LogInPage());

            }
        }
    }
}
