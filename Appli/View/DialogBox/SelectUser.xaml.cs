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
    /// Logique d'interaction pour SelectUser.xaml
    /// </summary>
    public partial class SelectUser : Window
    {
        public User currentUser = null;
        public SelectUser()
        {
            InitializeComponent();
        }

        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            currentUser = Login.GetUser();
            this.Close();
        }

        private void CreateAccountButton_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            currentUser = CreateUser.GetNewUser();
            this.Close();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }

        public static User RegisterUser()
        {
            SelectUser newUser = new SelectUser();
            newUser.ShowDialog();
            return newUser.currentUser;
        }

    }
}
