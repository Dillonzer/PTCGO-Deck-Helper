using PTCGO_Deck_Helper.DeckImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PTCGO_Deck_Helper.DeckImporter;
using PTCGO_Deck_Helper.API.Models;
using PTCGO_Deck_Helper.API;

namespace PTCGO_Deck_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Decklist _decklist = new Decklist();
        List<Card> _cards = new List<Card>();

        public MainWindow()
        {
            InitializeComponent();
            _cards = APIHelper.GetCards().ToList();
            if(Properties.Settings.Default.ReversedPrizeHighlighting)
            {
                menu_ReversePrizeHighlighting.IsChecked = true;
            }

            
        }

        private void ImportDecklist_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var import = Clipboard.GetText();
                _decklist = Importer.CreateDecklist(import);

                if (_decklist.TotalCards != 60 || _decklist == null)
                {
                    MessageBox.Show("The decklist imported is invalid. Please re-copy and try again.", "Error");
                    return;
                }
                else
                {
                    MessageBox.Show($"This is the decklist you imported:\n{import}", "Decklist");
                }                
            }
            else
            {
                MessageBox.Show("There is no decklist on your clipboard!", "Error");
            }
        }

        private void btn_SetPrizes_Click(object sender, RoutedEventArgs e)
        {
            if(_decklist.TotalCards != 60 || _decklist == null)
            {
                MessageBox.Show("Looks like you don't have a decklist imported. Please import a decklist first.", "Error");
                return;
            }

            prz_One.Reset();
            prz_Two.Reset();
            prz_Three.Reset();
            prz_Four.Reset();
            prz_Five.Reset();
            prz_Six.Reset();

            var setPrizes = new SetPrizes(_decklist, _cards);
            setPrizes.Show();
        }

        private void menu_ReversePrizeHighlighting_Click(object sender, RoutedEventArgs e)
        {
            if(menu_ReversePrizeHighlighting.IsChecked)
            {
                Properties.Settings.Default.ReversedPrizeHighlighting = true;
            }
            else
            {
                Properties.Settings.Default.ReversedPrizeHighlighting = false;
            }

            Properties.Settings.Default.Save();
        }
    }
}
