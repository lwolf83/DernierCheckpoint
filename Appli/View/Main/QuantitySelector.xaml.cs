using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Logique d'interaction pour QuantitySelector.xaml
    /// </summary>
    public partial class QuantitySelector : UserControl
    {
        BuyTicket _parent = null;

        public QuantitySelector()
        {
            InitializeComponent();
        }

        public void ParentUIMakeSum()
        {


        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            Quantity.Text = Regex.Replace(Quantity.Text, @"\s+", "");
            e.Handled = Regex.IsMatch(e.Text, "[^\\d]+");
        }

        private void PlusButton_Click(object sender, RoutedEventArgs e)
        {
            string qty = CheckQuantity(Quantity.Text);
            int newQuantity = Convert.ToInt32(qty) + 1;
            Quantity.Text = newQuantity.ToString();
        }

        private string CheckQuantity(string qty)
        {
            qty = Regex.Replace(qty, @"\s+", "");
            qty = (qty == String.Empty) ? "0" : qty;
            return qty;
        }

        private void MinusButton_Click(object sender, RoutedEventArgs e)
        {
            string qty = CheckQuantity(Quantity.Text);
            int newQuantity = Convert.ToInt32(qty) - 1;
            newQuantity = newQuantity < 0 ? 0 : newQuantity;
            Quantity.Text = newQuantity.ToString();
        }

        public int GetQuantity()
        {
            return Convert.ToInt32(CheckQuantity(Quantity.Text));
        }

        private void Quantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(_parent is null)
            { 
                _parent = FindParent<BuyTicket>(this); 
            }
            _parent.MakeSum();
        }

        public static T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
                return parent;
            else
                return FindParent<T>(parentObject);
        }

    }
}
