using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.JsonClass
{
    public class MealDetailJsonClass
    {
        [JsonProperty("meals")]
        public List<MealDetailJson> ilstMealDetail { get; set; }
    }

    public class MealDetailJson
    {
        [JsonProperty("idMeal")]
        public string idMeal { get; set; }

        [JsonProperty("strMeal")]
        public string strMeal { get; set; }

        [JsonProperty("strDrinkAlternate")]
        public string strDrinkAlternate { get; set; }

        [JsonProperty("strTags")]
        public string strTags { get; set; }

        [JsonProperty("strYoutube")]
        public string strYoutube { get; set; }

        [JsonProperty("strCategory")]
        public string strCategory { get; set; }

        [JsonProperty("strArea")]
        public string strArea { get; set; }

        [JsonProperty("strAlcoholic")]
        public string strAlcoholic { get; set; }

        [JsonProperty("strInstructions")]
        public string strInstructions { get; set; }

        [JsonProperty("strMealThumb")]
        public string strMealThumb { get; set; }

        [JsonProperty("strIngredient1")]
        public string strIngredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string strIngredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string strIngredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string strIngredient4 { get; set; }

        [JsonProperty("strIngredient5")]
        public string strIngredient5 { get; set; }

        [JsonProperty("strIngredient6")]
        public string strIngredient6 { get; set; }

        [JsonProperty("strIngredient7")]
        public string strIngredient7 { get; set; }

        [JsonProperty("strIngredient8")]
        public string strIngredient8 { get; set; }

        [JsonProperty("strIngredient9")]
        public string strIngredient9 { get; set; }

        [JsonProperty("strIngredient10")]
        public string strIngredient10 { get; set; }

        [JsonProperty("strIngredient11")]
        public string strIngredient11 { get; set; }

        [JsonProperty("strIngredient12")]
        public string strIngredient12 { get; set; }

        [JsonProperty("strIngredient13")]
        public string strIngredient13 { get; set; }

        [JsonProperty("strIngredient14")]
        public string strIngredient14 { get; set; }

        [JsonProperty("strIngredient15")]
        public string strIngredient15 { get; set; }

        [JsonProperty("strIngredient16")]
        public string strIngredient16 { get; set; }

        [JsonProperty("strIngredient17")]
        public string strIngredient17 { get; set; }

        [JsonProperty("strIngredient18")]
        public string strIngredient18 { get; set; }

        [JsonProperty("strIngredient19")]
        public string strIngredient19 { get; set; }

        [JsonProperty("strIngredient20")]
        public string strIngredient20 { get; set; }

        [JsonProperty("strMeasure1")]
        public string strMeasure1 { get; set; }

        [JsonProperty("strMeasure2")]
        public string strMeasure2 { get; set; }

        [JsonProperty("strMeasure3")]
        public string strMeasure3 { get; set; }

        [JsonProperty("strMeasure4")]
        public string strMeasure4 { get; set; }

        [JsonProperty("strMeasure5")]
        public string strMeasure5 { get; set; }

        [JsonProperty("strMeasure6")]
        public string strMeasure6 { get; set; }

        [JsonProperty("strMeasure7")]
        public string strMeasure7 { get; set; }

        [JsonProperty("strMeasure8")]
        public string strMeasure8 { get; set; }

        [JsonProperty("strMeasure9")]
        public string strMeasure9 { get; set; }

        [JsonProperty("strMeasure10")]
        public string strMeasure10 { get; set; }

        [JsonProperty("strMeasure11")]
        public string strMeasure11 { get; set; }

        [JsonProperty("strMeasure12")]
        public string strMeasure12 { get; set; }

        [JsonProperty("strMeasure13")]
        public string strMeasure13 { get; set; }

        [JsonProperty("strMeasure14")]
        public string strMeasure14 { get; set; }

        [JsonProperty("strMeasure15")]
        public string strMeasure15 { get; set; }

        [JsonProperty("strMeasure16")]
        public string strMeasure16 { get; set; }

        [JsonProperty("strMeasure17")]
        public string strMeasure17 { get; set; }

        [JsonProperty("strMeasure18")]
        public string strMeasure18 { get; set; }

        [JsonProperty("strMeasure19")]
        public string strMeasure19 { get; set; }

        [JsonProperty("strMeasure20")]
        public string strMeasure20 { get; set; }

        [JsonProperty("strSource")]
        public string strSource { get; set; }

        [JsonProperty("strImageSource")]
        public string strImageSource { get; set; }

        [JsonProperty("strCreativeCommonsConfirmed")]
        public string strCreativeCommonsConfirmed { get; set; }

        [JsonProperty("dateModified")]
        public string dateModified { get; set; }
    }
}