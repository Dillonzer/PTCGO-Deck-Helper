using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGO_Deck_Helper.API.Models
{
    public class Card
    {
        public string id { get; set; }
        public string name { get; set; }
        public Set set { get; set; }
        public string number { get; set; }
        public string imageUrlHiRes { get; set; }
        public int tcgPlayerCardId { get; set; }
        public string tcgPlayerCardUrl { get; set; }
        public string legalityIcon { get; set; }
    }
}
