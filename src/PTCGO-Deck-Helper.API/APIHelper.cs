using Newtonsoft.Json;
using PTCGO_Deck_Helper.API.Models;
using RestSharp;
using System;
using System.Collections.Generic;

namespace PTCGO_Deck_Helper.API
{
    public static class APIHelper
    {
        public static IEnumerable<Card> GetCards(string locale = Locale.en_US)
        {
            var client = new RestClient("https://ptcg-api.herokuapp.com/api/cards");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<IEnumerable<Card>>(response.Content);
        }
    }
}
