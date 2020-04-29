using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Logique d'interaction pour ArtistPresentation.xaml
    /// </summary>
    public partial class ArtistPresentation : UserControl
    {
        private ArtistFilter _artistFilter;
        public ArtistPresentation()
        {
            InitializeComponent();
            _artistFilter = new ArtistFilter(ArtistsLoader.All());
        }

        public void DisplayArtist()
        {
            int numberOfArtists =  Convert.ToInt32(Application.Current.MainWindow.ActualWidth) / 250;
            _artistFilter.SetElementNumber(numberOfArtists);
            ArtistList.ItemsSource = _artistFilter.Get();
            if(_artistFilter.isFullLeft())
            {
                LeftIcon.Visibility = Visibility.Hidden;
            }
            else
            {
                LeftIcon.Visibility = Visibility.Visible;
            }

            if(_artistFilter.isFullRight())
            {
                RightIcon.Visibility = Visibility.Hidden;
            }
            else
            {
                RightIcon.Visibility = Visibility.Visible;
            }
        }

        public void Update_size(object sender, RoutedEventArgs e)
        {
            DisplayArtist();
        }

        public void ArtistLeftDisplay(object sender, RoutedEventArgs e)
        {
            _artistFilter.MoveLeft();
            DisplayArtist();
        }

        public void ArtistRightDisplay(object sender, RoutedEventArgs e)
        {
            _artistFilter.MoveRight();
            DisplayArtist();
        }


    }
}
