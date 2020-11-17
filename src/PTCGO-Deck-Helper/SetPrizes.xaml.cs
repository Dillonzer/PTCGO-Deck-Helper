using PTCGO_Deck_Helper.API.Models;
using PTCGO_Deck_Helper.Custom_Controls;
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
        public List<string> _prizes = new List<string>();

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
            foreach(var pokemon in _decklist.Pokemon)
            {
                var control = new PrizeCardSelector(pokemon, _cards);
                control.Height = 50;
                control.MouseDown += control.ChangeCount;
                stp_Pokemon.Children.Add(control);
            }

            foreach (var trainers in _decklist.Trainers)
            {
                var control = new PrizeCardSelector(trainers, _cards);
                control.Height = 50;
                control.MouseDown += control.ChangeCount;
                stp_Trainers.Children.Add(control);
            }

            foreach (var energy in _decklist.Energy)
            {
                var control = new PrizeCardSelector(energy, _cards);
                control.Height = 50;
                control.MouseDown += control.ChangeCount;
                stp_Energy.Children.Add(control);
            }
        }
    }
}
