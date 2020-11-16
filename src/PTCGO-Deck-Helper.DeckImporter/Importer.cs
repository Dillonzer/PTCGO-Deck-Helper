using PTCGO_Deck_Helper.DeckImporter.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace PTCGO_Deck_Helper.DeckImporter
{
    public static class Importer
    {
        public static Decklist CreateDecklist(string import)
        {
            try
            {
                var pokemon = new Dictionary<string, int>();
                var trainers = new Dictionary<string, int>();
                var energy = new Dictionary<string, int>();
                var collectPokemon = false;
                var collectTrainers = false;
                var collectEnergy = false;
                var totalCards = 0;

                var splitImport = import.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                foreach (var line in splitImport)
                {
                    if (line.StartsWith("**") || line == string.Empty)
                    {
                        continue;
                    }

                    if (line.StartsWith("##Pokémon"))
                    {
                        collectPokemon = true;
                        collectTrainers = false;
                        collectEnergy = false;
                        continue;
                    }

                    if (line.StartsWith("##Trainer Cards"))
                    {
                        collectTrainers = true;
                        collectEnergy = false;
                        collectPokemon = false;
                        continue;
                    }

                    if (line.StartsWith("##Energy"))
                    {
                        collectEnergy = true;
                        collectTrainers = false;
                        collectPokemon = false;
                        continue;
                    }

                    if (line.StartsWith("Total Cards - 60"))
                    {
                        break;
                    }

                    var lineItem = line.Split(" ");
                    var cardName = string.Empty;
                    for (var i = 2; i < lineItem.Length - 1; i++)
                    {
                        cardName += lineItem[i] + " ";
                    }

                    if (collectPokemon)
                    {
                        pokemon.Add(cardName.Trim(), int.Parse(lineItem[1]));
                        totalCards += int.Parse(lineItem[1]);
                    }

                    if (collectTrainers)
                    {
                        trainers.Add(cardName.Trim(), int.Parse(lineItem[1]));
                        totalCards += int.Parse(lineItem[1]);
                    }
                    if (collectEnergy)
                    {
                        energy.Add(cardName.Trim(), int.Parse(lineItem[1]));
                        totalCards += int.Parse(lineItem[1]);
                    }
                }

                var decklist = new Decklist()
                {
                    Pokemon = pokemon,
                    Trainers = trainers,
                    Energy = energy
                };

                decklist.TotalCards = totalCards;

                return decklist;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
