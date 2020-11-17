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
        public bool _prized;
        public int _amountPrized;
        public Card _apiCardInfo;


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
            _apiCardInfo = Functions.GetCardDetailsForSpecificCard(_cardInfo.Key, _cards);
            if (_apiCardInfo != null)
            {
                img_CardTitle.Source = new BitmapImage(new Uri(_apiCardInfo.imageUrlHiRes));
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
            var decrease = false;
            var currentAmountPrized = 0;
            var prizeSpotsAvailable = new Dictionary<int, string>();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(SetPrizes))
                {
                    currentAmountPrized = int.Parse((window as SetPrizes).tbx_CurrentPrizeCount.Text);
                    prizeSpotsAvailable = (window as SetPrizes)._prizeCardSlots;
                }
            }

            if (e.ChangedButton == MouseButton.Left)
            {
                if (_cardCount > 0)
                {
                    if(currentAmountPrized == 6)
                    {
                        MessageBox.Show("You already have 6 prizes.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    _amountPrized++;
                    _cardCount--;
                    currentAmountPrized++;
                }
                else
                {
                    return;
                }
            }
            else
            {
                if (_cardCount < 4 && _cardCount < _cardInfo.Value)
                {
                    _amountPrized--;
                    _cardCount++;
                    currentAmountPrized--;
                    decrease = true;
                }
                else
                {
                    return;
                }
            }

            if(_cardCount != _cardInfo.Value)
            {
                _prized = true;
                img_CardTitle.Opacity = 0.25;
            }
            else
            {
                _prized = false;
                img_CardTitle.Opacity = 1;
            }

            tbx_CardCount.Text = _cardCount.ToString();

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(SetPrizes))
                {
                    (window as SetPrizes).tbx_CurrentPrizeCount.Text = currentAmountPrized.ToString();

                    foreach(var kvp in prizeSpotsAvailable)
                    {
                        if(decrease)
                        {
                            if(_cardInfo.Key == kvp.Value)
                            {
                                //DO A SWITCH ON THE KEY AND THEN HIDE THE SPECIFIC IMAGE
                                //RETURN
                            }
                        }
                    }

                    prizeSpotsAvailable.Add(prizeSpotsAvailable.Count, _cardInfo.Key);
                    //DO SWITCH ON COUNT AND SHOW IMAGE

                    //switch(currentAmountPrized)
                    //{
                    //    case 0:
                    //        if (decrease)
                    //        {
                    //            (window as SetPrizes).img_Prize1.Visibility = Visibility.Hidden;
                    //        }
                    //        break;
                    //    case 1:
                    //        if (decrease)
                    //        {
                    //            (window as SetPrizes).img_Prize2.Visibility = Visibility.Hidden;
                    //        }
                    //        else
                    //        {
                    //            (window as SetPrizes).img_Prize1.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                    //            (window as SetPrizes).img_Prize1.Visibility = Visibility.Visible;
                    //        }
                    //        break;
                    //    case 2:
                    //        if (decrease)
                    //        {
                    //            (window as SetPrizes).img_Prize3.Visibility = Visibility.Hidden;
                    //        }
                    //        else
                    //        {
                    //            (window as SetPrizes).img_Prize2.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                    //            (window as SetPrizes).img_Prize2.Visibility = Visibility.Visible;
                    //        }
                    //        break;
                    //    case 3:
                    //        if (decrease)
                    //        {
                    //            (window as SetPrizes).img_Prize4.Visibility = Visibility.Hidden;
                    //        }
                    //        else
                    //        {
                    //            (window as SetPrizes).img_Prize3.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                    //            (window as SetPrizes).img_Prize3.Visibility = Visibility.Visible;
                    //        }
                    //        break;
                    //    case 4:
                    //        if (decrease)
                    //        {
                    //            (window as SetPrizes).img_Prize5.Visibility = Visibility.Hidden;
                    //        }
                    //        else
                    //        {
                    //            (window as SetPrizes).img_Prize4.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                    //            (window as SetPrizes).img_Prize4.Visibility = Visibility.Visible;
                    //        }
                    //        break;
                    //    case 5:
                    //        if (decrease)
                    //        {
                    //            (window as SetPrizes).img_Prize6.Visibility = Visibility.Hidden;
                    //        }
                    //        else
                    //        {
                    //            (window as SetPrizes).img_Prize5.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                    //            (window as SetPrizes).img_Prize5.Visibility = Visibility.Visible;
                    //        }
                    //        break;
                    //    case 6:
                    //        if (decrease)
                    //        {

                    //        }
                    //        else
                    //        {
                    //            (window as SetPrizes).img_Prize6.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                    //            (window as SetPrizes).img_Prize6.Visibility = Visibility.Visible;
                    //        }
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
        }
    }
}
