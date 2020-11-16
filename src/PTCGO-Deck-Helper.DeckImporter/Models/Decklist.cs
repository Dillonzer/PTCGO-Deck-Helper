using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGO_Deck_Helper.DeckImporter.Models
{
    public class Decklist
    {
        public Dictionary<string, int> Pokemon { get; set; }
        public Dictionary<string, int> Trainers { get; set; }
        public Dictionary<string, int> Energy { get; set; }
    }
}
