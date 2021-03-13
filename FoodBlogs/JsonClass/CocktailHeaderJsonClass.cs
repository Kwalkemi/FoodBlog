using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.JsonClass
{
    public class CocktailHeaderJsonClass
    {
        [JsonProperty("drinks")]
        public List<CocktailHeader> ilstCocktailHeader { get; set; }
        
    }

    public class CocktailHeader
    {
        [JsonProperty("idDrink")]
        public string idDrink { get; set; }

        [JsonProperty("strDrink")]
        public string strDrink { get; set; }

        [JsonProperty("strDrinkThumb")]
        public string strDrinkThumb { get; set; }
    }


}