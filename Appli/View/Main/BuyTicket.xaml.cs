using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using WildCircus.View.Main;

namespace WildCircus
{
    /// <summary>
    /// Logique d'interaction pour BuyTicket.xaml
    /// </summary>
    public partial class BuyTicket : UserControl
    {
        private Performance _performance;
        public BuyTicket(Performance performance)
        {
            InitializeComponent();
            _performance = performance;
        }

        public void MakeSum()
        {
            Int32 VipPrice = 50 * VipQuantity.GetQuantity();
            Int32 NormalPrice = 30 * NormalQuantity.GetQuantity();
            Int32 EcoPrice = 15 * EcoQuantity.GetQuantity();

            Int32 TotalPrice = VipPrice + NormalPrice + EcoPrice;

            Total_Textblock.Text = TotalPrice.ToString();
        }

        private void BuyButton_Click(object sender, RoutedEventArgs e)
        {
            if(!UserSingleton.GetInstance.IsAuthenticated)
            {
                SelectUser.RegisterUser();
            }

            if(UserSingleton.GetInstance.IsAuthenticated)
            {
                List<Seat> seatsVIP = CreateSeats("VIP", VipQuantity.GetQuantity());
                List<Seat> seatsNormal = CreateSeats("Normal", NormalQuantity.GetQuantity());
                List<Seat> seatsECO = CreateSeats("Eco", EcoQuantity.GetQuantity());

                List<Seat> seats = seatsVIP;
                seats.AddRange(seatsNormal);
                seats.AddRange(seatsECO);

                Reservation reservation = ReservationFactory.Create(_performance, seats);
                reservation.Save();
                ValidationOrder validationOrder = new ValidationOrder(reservation);
                this.Content = validationOrder;
            }
        }

        private List<Seat> CreateSeats(string cat, int quantity)
        {
            Category category = CategoriesLoader.Get(cat);
            List<Seat> seats = new List<Seat>();
            for (int i = 0; i < quantity; i++)
            {
                Seat seat = new Seat()
                {
                    Category = category
                };
                seats.Add(seat);
            }
            return seats;
        }

        private void BackToPerformance_Click(object sender, RoutedEventArgs e)
        {
            UIElement shopElement = TreeUI.GetElementByName("Shop");

            Grid shopGrid = (Grid)shopElement;
            shopGrid.Children.Clear();
            PerformanceList performanceList = new PerformanceList(_performance.GetShow());
            shopGrid.Children.Add(performanceList);
        }
    }
}
