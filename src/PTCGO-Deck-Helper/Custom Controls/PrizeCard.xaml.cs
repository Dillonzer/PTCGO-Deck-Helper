using PTCGO_Deck_Helper.DeckImporter.Models;
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
using PTCGO_Deck_Helper.DecklistFunctions;

namespace PTCGO_Deck_Helper.Custom_Controls
{
    /// <summary>
    /// Interaction logic for PrizeCard.xaml
    /// </summary>
    public partial class PrizeCard : UserControl
    {
        bool _initialLoad = true;

        public PrizeCard()
        {
            InitializeComponent();
        }

        public void SetComboBoxValues(Decklist decklist)
        {
            var uniqueValues = Functions.GetUniqueCardsFromDeck(decklist);
            cmb_SelectPrize.ItemsSource = uniqueValues;
            cmb_SelectPrize.SelectedIndex = 0;
        }

        private void cmb_SelectPrize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(_initialLoad) { _initialLoad = false; return; }

            cmb_SelectPrize.Visibility = Visibility.Hidden;

            txt_PrizeCard.Text = cmb_SelectPrize.SelectedItem.ToString();
            txt_PrizeCard.Visibility = Visibility.Visible;
        }

        private void txt_PrizeCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txt_PrizeCard.Text = "DRAWN";
        }
    }
}
