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
    /// Logique d'interaction pour ValidationOrder.xaml
    /// </summary>
    public partial class ValidationOrder : UserControl
    {
        public ValidationOrder()
        {
            InitializeComponent();
            var context = new WildCircusContext();
            var categories = context.Categories.ToList();
            var seats = context.Seats.ToList();
            var performances = context.Performances.ToList();
            List<Reservation> reservations = context.Reservations.Where(r => r.User == UserSingleton.GetInstance.user).ToList();
            PerformanceListView.ItemsSource = reservations;


        }
    }
}
