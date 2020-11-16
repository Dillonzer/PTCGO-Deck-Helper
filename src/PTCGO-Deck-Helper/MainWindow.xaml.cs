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

namespace PTCGO_Deck_Helper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ImportDecklist_Click(object sender, RoutedEventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                var decklist = Clipboard.GetText();
                var imported = DeckImporter.Importer.CreateDecklist(decklist);
            }
            else
            {
                MessageBox.Show("There is no decklist!");
            }
        }
    }
}
