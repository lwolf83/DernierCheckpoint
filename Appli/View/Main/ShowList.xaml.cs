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
    /// Logique d'interaction pour ShowList.xaml
    /// </summary>
    public partial class ShowList : UserControl
    {
        public ShowList()
        {
            InitializeComponent();
            using(var context = new WildCircusContext())
            {
                List<Performance> performances = context.Performances.ToList();
                ShowListView.ItemsSource = context.Shows.ToList();
            }
        }

        private void SeeListPerformance(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var show = button.CommandParameter as Show;
            PerformanceList performanceList = new PerformanceList(show);
            this.Content = performanceList;
        }
    }
}
