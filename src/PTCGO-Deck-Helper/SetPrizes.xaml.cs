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
                control.Height = 65;
                control.MouseDown += control.ChangeCount;
                stp_Pokemon.Children.Add(control);
            }

            foreach (var trainers in _decklist.Trainers)
            {
                var control = new PrizeCardSelector(trainers, _cards);
                control.Height = 65;
                control.MouseDown += control.ChangeCount;
                stp_Trainers.Children.Add(control);
            }

            foreach (var energy in _decklist.Energy)
            {
                var control = new PrizeCardSelector(energy, _cards);
                control.Height = 65;
                control.MouseDown += control.ChangeCount;
                stp_Energy.Children.Add(control);
            }
        }

        private void btn_SubmitPrizes_Click(object sender, RoutedEventArgs e)
        {
            foreach(PrizeCardSelector pokemon in stp_Pokemon.Children)
            {
                if(pokemon._prized)
                {
                    if (_prizes.Count() < 6)
                    {
                        for (var i = 0; i < pokemon._amountPrized; i++)
                        {
                            if (pokemon._apiCardInfo == null)
                            {
                                _prizes.Add(pokemon._cardInfo.Key);
                            }
                            else
                            {
                                _prizes.Add(pokemon._apiCardInfo.imageUrlHiRes);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have too many prizes selected. Please try again.");
                        _prizes = new List<string>();
                        return;
                    }
                }
            }

            foreach (PrizeCardSelector trainers in stp_Trainers.Children)
            {
                if (trainers._prized)
                {
                    if (_prizes.Count() < 6)
                    {
                        for (var i = 0; i < trainers._amountPrized; i++)
                        {
                            if (trainers._apiCardInfo == null)
                            {
                                _prizes.Add(trainers._cardInfo.Key);
                            }
                            else
                            {
                                _prizes.Add(trainers._apiCardInfo.imageUrlHiRes);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have too many prizes selected. Please try again.");
                        _prizes = new List<string>();
                        return;
                    }
                }
                
            }

            foreach (PrizeCardSelector energy in stp_Energy.Children)
            {
                if (energy._prized)
                {
                    if (_prizes.Count() < 6)
                    {
                        for (var i = 0; i < energy._amountPrized; i++)
                        {
                            if (energy._apiCardInfo == null)
                            {
                                _prizes.Add(energy._cardInfo.Key);
                            }
                            else
                            {
                                _prizes.Add(energy._apiCardInfo.imageUrlHiRes);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("You have too many prizes selected. Please try again.");
                        _prizes = new List<string>();
                        return;
                    }
                }
                
            }

            if(_prizes.Count != 6)
            {
                MessageBox.Show("You have not selected 6 prizes. Please try again."); 
                _prizes = new List<string>();
                return;
            }

            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).prz_One.SetPrize(_prizes[0]);
                    (window as MainWindow).prz_Two.SetPrize(_prizes[1]);
                    (window as MainWindow).prz_Three.SetPrize(_prizes[2]);
                    (window as MainWindow).prz_Four.SetPrize(_prizes[3]);
                    (window as MainWindow).prz_Five.SetPrize(_prizes[4]);
                    (window as MainWindow).prz_Six.SetPrize(_prizes[5]);
                }
            }

            Close();
        }
    }
}
