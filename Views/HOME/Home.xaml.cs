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
using WpfAppDemo.Models;
using WpfAppDemo.Repositories;
using WpfAppDemo.Views.OnBoarding;

namespace WpfAppDemo.Views.HOME
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {
        UserRepository userRepository = new UserRepository();
        private User? current_user;
        public Home()
        {
            InitializeComponent();
            current_user = new User();
        }
        public Home(User _user)
        {
            InitializeComponent();
            current_user = _user;
        }   

        private void AboutMe_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutMe());
        }
        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LogIn());
        }
        private void DeleteAcount_Click(object sender, RoutedEventArgs e)
        {
            //if(current_user == null)
            //{
            //    MessageBox.Show("No user is currently logged in.",
            //                    "Error",
            //                    MessageBoxButton.OK,
            //                    MessageBoxImage.Error);
            //    return;
            //}
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
                NavigationService.Navigate(new LogIn());

            }
        }
    }
}
