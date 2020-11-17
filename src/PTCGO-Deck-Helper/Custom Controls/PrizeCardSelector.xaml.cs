using PTCGO_Deck_Helper.API.Models;
using PTCGO_Deck_Helper.DecklistFunctions;
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

namespace PTCGO_Deck_Helper.Custom_Controls
{
    /// <summary>
    /// Interaction logic for PrizeCardSelector.xaml
    /// </summary>
    public partial class PrizeCardSelector : UserControl
    {
        public KeyValuePair<string, int> _cardInfo;
        public List<Card> _cards;
        public int _cardCount;

        public PrizeCardSelector()
        {
            InitializeComponent();
        }

        public PrizeCardSelector(KeyValuePair<string, int> cardInfo, List<Card> cards)
        {
            InitializeComponent();
            _cardInfo = cardInfo;
            _cards = cards;
            _cardCount = cardInfo.Value;
            SetImageAndCount();
        }

        public void SetImageAndCount()
        {
            var card = Functions.GetCardDetailsForSpecificCard(_cardInfo.Key, _cards);
            if (card != null)
            {
                img_CardTitle.Source = new BitmapImage(new Uri(card.imageUrlHiRes));
            }
            else
            {
                tbx_CardName.Text = _cardInfo.Key;
                tbx_CardName.Visibility = Visibility.Visible;
            }

            tbx_CardCount.Text = _cardInfo.Value.ToString();
        }

        public void ChangeCount(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                _cardCount--;
            }
            else
            {
                _cardCount++;
            }

            tbx_CardCount.Text = _cardCount.ToString();
        }
    }
}
