using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using FoodBlogs.JsonClass;
using Newtonsoft.Json;

namespace FoodBlogs.Web_Service
{
    public class CocktailWebService
    {
        public CocktailHeaderJsonClass CocktailListWebService(string astrUrl)
        {
            var webClient = new WebClient();
            var response = webClient.DownloadString(astrUrl);
            var JsonObject = JsonConvert.DeserializeObject<CocktailHeaderJsonClass>(response);
            
            return (CocktailHeaderJsonClass)JsonObject;
        }

        public CocktailDetailJsonClass CocktailDetailWebService(int aintCocktailId)
        {
            var webClient = new WebClient();
            string Url = "https://www.thecocktaildb.com/api/json/v1/1/lookup.php?i=" + aintCocktailId;
            var response = webClient.DownloadString(Url);
            var JsonObject = JsonConvert.DeserializeObject<CocktailDetailJsonClass>(response);

            return (CocktailDetailJsonClass)JsonObject;
        }
    }
}