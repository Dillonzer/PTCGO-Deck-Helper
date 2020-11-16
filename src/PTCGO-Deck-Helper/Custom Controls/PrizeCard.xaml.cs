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
using PTCGO_Deck_Helper.API.Models;
using System.Linq;

namespace PTCGO_Deck_Helper.Custom_Controls
{
    /// <summary>
    /// Interaction logic for PrizeCard.xaml
    /// </summary>
    public partial class PrizeCard : UserControl
    {
        List<Card> _cards = new List<Card>();

        public PrizeCard()
        {
            InitializeComponent();
        }

        public void SetComboBoxValues(Decklist decklist, List<Card> cards)
        {
            var uniqueValues = Functions.GetUniqueCardsFromDeck(decklist);
            cmb_SelectPrize.ItemsSource = uniqueValues;
            cmb_SelectPrize.SelectedIndex = 0;
            if(!_cards.Any()) { _cards = cards; }
        }

        private void img_PrizeCard_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (img_PrizeCard.Opacity == 0.25)
            {
                img_PrizeCard.Opacity = 1;
            }
            else
            {
                img_PrizeCard.Opacity = 0.25;
            }
        }

        public void Reset()
        {
            cmb_SelectPrize.SelectedIndex = 0;
            cmb_SelectPrize.Visibility = Visibility.Visible;
            btn_SetPrize.Visibility = Visibility.Visible;
            img_PrizeCard.Opacity = 0.25;
            img_PrizeCard.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
        }

        private void btn_SetPrize_Click(object sender, RoutedEventArgs e)
        {
            cmb_SelectPrize.Visibility = Visibility.Hidden;
            btn_SetPrize.Visibility = Visibility.Hidden;
            var cardString = cmb_SelectPrize.SelectedItem.ToString();
            img_PrizeCard.Source = new BitmapImage(new Uri(Functions.GetCardDetailsForSpecificCard(cardString, _cards).imageUrlHiRes));
        }
    }
}
