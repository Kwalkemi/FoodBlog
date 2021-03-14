using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Models.MyModel
{
    public class Cocktail :BaseModel
    {
        public int CocktailId { get; set; }

        public string CocktailName { get; set; }

        public string CocktailUrl { get; set; }
    }
}