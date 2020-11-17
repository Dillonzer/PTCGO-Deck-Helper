using PTCGO_Deck_Helper.API.Models;
using PTCGO_Deck_Helper.DeckImporter.Models;
using PTCGO_Deck_Helper.DecklistFunctions;
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
using System.Windows.Shapes;

namespace PTCGO_Deck_Helper
{
    /// <summary>
    /// Interaction logic for SetPrizes.xaml
    /// </summary>
    public partial class SetPrizes : Window
    {
        private Decklist _decklist = new Decklist();
        private List<Card> _cards = new List<Card>();

        public SetPrizes()
        {
            InitializeComponent();
        }

        public SetPrizes(Decklist decklist, List<Card> cards)
        {
            InitializeComponent();
            _decklist = decklist;
            _cards = cards;
            SetCardImages();

        }

        public void SetCardImages()
        {
            var images = GetChildren(grd_SetPrizes).OfType<Image>().ToList();
            var currentImage = 0;

            foreach (var pokemon in _decklist.Pokemon)
            {
                var cardImage = Functions.GetCardDetailsForSpecificCard(pokemon.Key, _cards);
                if(cardImage == null) { continue; }

                var bi = new BitmapImage(new Uri(cardImage.imageUrlHiRes));

                for (var i = 0; i < pokemon.Value; i++)
                {
                    images[currentImage].Source = bi;
                    currentImage++;
                }
            }

            foreach (var trainers in _decklist.Trainers)
            {
                var cardImage = Functions.GetCardDetailsForSpecificCard(trainers.Key, _cards);
                if (cardImage == null) { continue; }

                var bi = new BitmapImage(new Uri(cardImage.imageUrlHiRes));
                for (var i = 0; i < trainers.Value; i++)
                {
                    images[currentImage].Source = bi;
                    currentImage++;
                }
            }

            foreach (var energy in _decklist.Energy)
            {
                var cardImage = Functions.GetCardDetailsForSpecificCard(energy.Key, _cards);
                if (cardImage == null) { continue; }

                var bi = new BitmapImage(new Uri(cardImage.imageUrlHiRes));
                for (var i = 0; i < energy.Value; i++)
                {
                    images[currentImage].Source = bi;
                    currentImage++;
                }
            }
        }

        public static IEnumerable<Visual> GetChildren(Visual parent, bool recurse = true)
        {
            if (parent != null)
            {
                int count = VisualTreeHelper.GetChildrenCount(parent);
                for (int i = 0; i < count; i++)
                {
                    // Retrieve child visual at specified index value.
                    var child = VisualTreeHelper.GetChild(parent, i) as Visual;

                    if (child != null)
                    {
                        yield return child;

                        if (recurse)
                        {
                            foreach (var grandChild in GetChildren(child, true))
                            {
                                yield return grandChild;
                            }
                        }
                    }
                }
            }
        }

        private void img_Card_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
