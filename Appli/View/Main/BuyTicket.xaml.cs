using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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

            if(UserSingleton.GetInstance.IsAuthenticated && CheckQuantity())
            {
                List<Seat> seatsVIP = SeatsFactory.CreateSeats("VIP", VipQuantity.GetQuantity());
                List<Seat> seatsNormal = SeatsFactory.CreateSeats("Normal", NormalQuantity.GetQuantity());
                List<Seat> seatsECO = SeatsFactory.CreateSeats("Eco", EcoQuantity.GetQuantity());

                List<Seat> seats = seatsVIP;
                seats.AddRange(seatsNormal);
                seats.AddRange(seatsECO);

                Reservation reservation = ReservationFactory.Create(_performance, seats);
                reservation.Save();
                
                ValidationOrder validationOrder = new ValidationOrder();
                this.Content = validationOrder;
            }
        }

        private bool CheckQuantity()
        {
            bool isAtLeastOneSeat = (VipQuantity.GetQuantity() > 0);
            isAtLeastOneSeat |= (NormalQuantity.GetQuantity() > 0);
            isAtLeastOneSeat |= (EcoQuantity.GetQuantity() > 0);

            return isAtLeastOneSeat;
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
