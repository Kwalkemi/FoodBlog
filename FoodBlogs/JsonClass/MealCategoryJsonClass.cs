using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.JsonClass
{
    public class MealCategoryJsonClass
    {
        [JsonProperty("categories")]
        public List<MealCategoryJson> ilstMealCategory { get; set; }
    }

    public class MealCategoryJson
    {
        [JsonProperty("idCategory")]
        public string idCategory { get; set; }

        [JsonProperty("strCategory")]
        public string strCategory { get; set; }
        
        [JsonProperty("strCategoryThumb")]
        public string strCategoryThumb { get; set; }
        
        [JsonProperty("strCategoryDescription")]
        public string strCategoryDescription { get; set; }


    }
}