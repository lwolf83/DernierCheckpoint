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
using System.Windows.Shapes;

namespace WildCircus
{
    /// <summary>
    /// Logique d'interaction pour Login.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        public User Result { get; private set; }
        public CreateUser()
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

        public static User GetNewUser()
        {
            CreateUser newUser = new CreateUser();
            newUser.ShowDialog();
            return newUser.Result;
        }

        private void CancelForm_Click(object sender, RoutedEventArgs e)
        { 
            this.DialogResult = false;
        }

        private void ValidForm_Click(object sender, RoutedEventArgs e)
        {
            Result = UserFactory.Create(Login_TextBox.Text, Password_TextBox.Password, Email_TextBox.Text);
            if(!Result.Exists())
            {
                Result.Add();
                UserSingleton.GetInstance.Set(Result);
                this.DialogResult = true;
                MainWindow mainWindow = TreeUI.GetElementByName("MainWindowElement") as MainWindow;
                mainWindow.DisplayLogout();
            }
            else
            {
                ErrorLabel.Content = "This user already exists";
            }
            
        }
    }
}
