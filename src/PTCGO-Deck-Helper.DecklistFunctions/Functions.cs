﻿using PTCGO_Deck_Helper.API;
using PTCGO_Deck_Helper.API.Models;
using PTCGO_Deck_Helper.DeckImporter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PTCGO_Deck_Helper.DecklistFunctions
{
    public static class Functions
    {
        public static ObservableCollection<string> GetUniqueCardsFromDeck(Decklist decklist)
        {
            var uniqueCards = new ObservableCollection<string>();
            var uniquePokemon = decklist.Pokemon.Keys.Select(x => x).Distinct();
            var uniqueTrainers = decklist.Trainers.Keys.Select(x => x).Distinct();
            var uniqueEnergy = decklist.Energy.Keys.Select(x => x).Distinct();

            foreach (var poke in uniquePokemon)
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

        public static Card GetCardDetailsForSpecificCard(string card, List<Card> cards)
        {
            var set = card.Split(" ").LastOrDefault().Trim(); ;
            var cardName = card.Substring(0, card.LastIndexOf(" "));
            
            //Just used with the way I made the names in my API
            cardName = cardName.Replace("-GX", " GX");
            cardName = cardName.Replace("-EX", " EX");

            return cards.Where(x => x.set.ptcgoCode.ToLower() == set.ToLower() && x.name.ToLower() == cardName.ToLower()).FirstOrDefault();
        }
    }
}
