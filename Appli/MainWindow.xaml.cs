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

namespace WildCircus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataGenerator.Init();
            InitializeComponent();
            
        }

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.IsEnabled = false;
            User user = Login.GetUser();
            if (UserSingleton.GetInstance.IsAuthenticated)
            {
                DisplayLogout();
            }
            MainGrid.IsEnabled = true;
        }

        private void CreateUser_Button_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.IsEnabled = false;
            User user = CreateUser.GetNewUser();
            if(UserSingleton.GetInstance.IsAuthenticated)
            {
                DisplayLogout();
            }
            MainGrid.IsEnabled = true;
        }

        public void DisplayLogout()
        {
            Login_Button.Visibility = Visibility.Collapsed;
            CreateUser_Button.Visibility = Visibility.Collapsed;
            Logout_Button.Visibility = Visibility.Visible;
            Order_Button.Visibility = Visibility.Visible;
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            UserSingleton.Dispose();
            DisplayLogin();
            ShowList showList = new ShowList();
            Shop.Children.Clear();
            Shop.Children.Add(showList);
        }

        private void DisplayLogin()
        {
            Login_Button.Visibility = Visibility.Visible;
            CreateUser_Button.Visibility = Visibility.Visible;
            Logout_Button.Visibility = Visibility.Collapsed;
            Order_Button.Visibility= Visibility.Collapsed;
        }

        private void Order_Button_Click(object sender, RoutedEventArgs e)
        {
            ValidationOrder validationOrder = new ValidationOrder();
            Shop.Children.Clear();
            Shop.Children.Add(validationOrder);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            ShowList showList = new ShowList();
            Shop.Children.Clear();
            Shop.Children.Add(showList);
        }
    }
}
