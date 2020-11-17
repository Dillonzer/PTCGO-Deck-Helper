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
        public PrizeCard()
        {
            InitializeComponent();
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
            img_PrizeCard.Opacity = 0.25;
            img_PrizeCard.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
            tbx_CardName.Visibility = Visibility.Hidden;
        }

        public void SetPrize(string url)
        {
            if (!url.Contains("digitalocean"))
            {
                img_PrizeCard.Source = new BitmapImage(new Uri("/Resources/default-card-image.png", UriKind.Relative));
                tbx_CardName.Text = url;
                tbx_CardName.Visibility = Visibility.Visible;
            }
            else
            {
                img_PrizeCard.Source = new BitmapImage(new Uri(url));
            }
        }
    }
}
