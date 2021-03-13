using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using FoodBlogs.JsonClass;

namespace FoodBlogs.Web_Service
{
    public class MealWebService
    {
        public MealCategoryJsonClass MealCategoryWebService()
        {
            var webClient = new WebClient();
            string lstrUrl = "https://www.themealdb.com/api/json/v1/1/categories.php";
            var response = webClient.DownloadString(lstrUrl);
            var JsonObject = JsonConvert.DeserializeObject<MealCategoryJsonClass>(response);

            return (MealCategoryJsonClass)JsonObject;
        }

        public MealListJsonClass MealListWebService(string astrCategoryName)
        {
            var webClient = new WebClient();
            string lstrUrl = "https://www.themealdb.com/api/json/v1/1/filter.php?c=" + astrCategoryName;
            var response = webClient.DownloadString(lstrUrl);
            var JsonObject = JsonConvert.DeserializeObject<MealListJsonClass>(response);

            return (MealListJsonClass)JsonObject;
        }

        public MealDetailJsonClass MealDetailWebService(int aintId)
        {
            var webClient = new WebClient();
            string lstrUrl = "https://www.themealdb.com/api/json/v1/1/lookup.php?i=" + aintId;
            var response = webClient.DownloadString(lstrUrl);
            var JsonObject = JsonConvert.DeserializeObject<MealDetailJsonClass>(response);

            return (MealDetailJsonClass)JsonObject;
        }
    }
}