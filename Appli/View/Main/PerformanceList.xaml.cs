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
using WildCircus.Control.Filter;

namespace WildCircus
{
    /// <summary>
    /// Logique d'interaction pour PerformanceList.xaml
    /// </summary>
    public partial class PerformanceList : UserControl
    {
        private List<Performance> _performances;

        public PerformanceList(Show show)
        {
            InitializeComponent();
            using(var context = new WildCircusContext())
            {
                List<Performance> performances = context.Performances.Where(x => show.Performances.Contains(x)).ToList();
                _performances = performances;
                PerformanceListView.ItemsSource = performances;
            }
        }

        private void BuyTicket(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var performance = button.CommandParameter as Performance;
            BuyTicket buyTicket = new BuyTicket(performance);
            this.Content = buyTicket;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Performance> currentPerformance = _performances;
            if(From_DatePicker.SelectedDate != null)
            {
                DateTime currentDate = (DateTime)From_DatePicker.SelectedDate;
                currentPerformance = PerformancesFilter.FilterAfter(currentPerformance, currentDate);
            }

            if (To_DatePicker.SelectedDate != null)
            {
                DateTime currentDate = (DateTime)To_DatePicker.SelectedDate;
                currentPerformance = PerformancesFilter.FilterBefore(currentPerformance, currentDate);
            }

            PerformanceListView.ItemsSource = currentPerformance;

        }

        private void BackToShows_Click(object sender, RoutedEventArgs e)
        {
            UIElement shopElement = TreeUI.GetElementByName("Shop");
            Grid shopGrid = (Grid)shopElement;
            shopGrid.Children.Clear();

            ShowList showList = new ShowList();
            shopGrid.Children.Add(showList);
        }
    }
}
