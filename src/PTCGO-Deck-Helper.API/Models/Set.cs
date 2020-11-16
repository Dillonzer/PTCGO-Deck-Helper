using System;
using System.Collections.Generic;
using System.Text;

namespace PTCGO_Deck_Helper.API.Models
{
    public class Set
    {
        public string code { get; set; }
        public string ptcgoCode { get; set; }
        public string name { get; set; }
        public string releaseDate { get; set; }
        public string symbolUrl { get; set; }
        public bool standardLegal { get; set; }
        public bool expandedLegal { get; set; }
    }
}
