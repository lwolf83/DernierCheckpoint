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
    /// Logique d'interaction pour DetailArtiste.xaml
    /// </summary>
    public partial class DetailArtiste : Window
    {
        public DetailArtiste(Artist artist)
        {
            InitializeComponent();
            DataContext = artist;
        }

        public static void DisplayArtist(Artist artist)
        {
            DetailArtiste newArtiste = new DetailArtiste(artist);
            newArtiste.ShowDialog();
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            Application curApp = Application.Current;
            Window mainWindow = curApp.MainWindow;
            this.Left = mainWindow.Left + (mainWindow.Width - this.ActualWidth) / 2;
            this.Top = mainWindow.Top + (mainWindow.Height - this.ActualHeight) / 2;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
