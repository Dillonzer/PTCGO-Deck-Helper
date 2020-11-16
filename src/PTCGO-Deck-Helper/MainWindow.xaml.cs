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

namespace PTCGO_Deck_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Decklist _decklist = new Decklist();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImportDecklist_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var import = Clipboard.GetText();
                _decklist = Importer.CreateDecklist(import);
                prz_One.SetComboBoxValues(_decklist);
                prz_Two.SetComboBoxValues(_decklist);
                prz_Three.SetComboBoxValues(_decklist);
                prz_Four.SetComboBoxValues(_decklist);
                prz_Five.SetComboBoxValues(_decklist);
                prz_Six.SetComboBoxValues(_decklist);
            }
            else
            {
                MessageBox.Show("There is no decklist!");
            }
        }
    }
}
