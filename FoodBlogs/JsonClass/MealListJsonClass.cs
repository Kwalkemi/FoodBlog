using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.JsonClass
{
    public class MealListJsonClass
    {
        [JsonProperty("meals")]
        public List<MealListJson> ilstMealList { get; set; }
    }

    public class MealListJson
    {
        [JsonProperty("strMeal")]
        public string strMeal { get; set; }

        [JsonProperty("strMealThumb")]
        public string strMealThumb { get; set; }

        [JsonProperty("idMeal")]
        public string idMeal { get; set; }

    }
}