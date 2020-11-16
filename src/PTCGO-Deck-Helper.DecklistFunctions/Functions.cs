using PTCGO_Deck_Helper.DeckImporter.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PTCGO_Deck_Helper.DecklistFunctions
{
    public static class Functions
    {
        public static ObservableCollection<string> GetUniqueCardsFromDeck(Decklist decklist)
        {
            var uniqueCards = new ObservableCollection<string>();
            var uniquePokemon = decklist.Pokemon.Keys.Select(x=>x).Distinct();
            var uniqueTrainers = decklist.Trainers.Keys.Select(x => x).Distinct();
            var uniqueEnergy = decklist.Energy.Keys.Select(x => x).Distinct();

            foreach(var poke in uniquePokemon)
            {
                uniqueCards.Add(poke);
            }
            foreach (var trainer in uniqueTrainers)
            {
                uniqueCards.Add(trainer);
            }
            foreach (var energy in uniqueEnergy)
            {
                uniqueCards.Add(energy);
            }

            return uniqueCards;
        }
    }
}
