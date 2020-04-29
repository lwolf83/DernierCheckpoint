using System;
using System.Collections.Generic;
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

namespace WildCircus
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public User Result { get; private set; }

        public Login()
        {
            InitializeComponent();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
            Login_TextBox.Focus();
        }

        public static User GetUser()
        {
            Login newUser = new Login();
            newUser.ShowDialog();
            return newUser.Result;
        }

        private void CancelForm_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void LogInForm_Click(object sender, RoutedEventArgs e)
        {
            Result = UserFactory.Create(Login_TextBox.Text, Password_TextBox.Password);
            if (!Result.Exists())
            {
                ErrorLabel.Content = "This user already exists.";
                
            }
            else if(!Result.IsPasswordValid())
            {
                ErrorLabel.Content = "Wrong password.";
            }
            else
            {
                Result.Load();
                UserSingleton.GetInstance.Set(Result);
                this.DialogResult = true;
                MainWindow mainWindow = TreeUI.GetElementByName("MainWindowElement") as MainWindow;
                mainWindow.DisplayLogout();
            }

        }

    }
}
