using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Models.MyModel
{
    public class CocktailDetail
    {
        public string istrDrinkId { get; set; }

        public string istrDrinkName { get; set; }

        public string istrDrinkAlternateName { get; set; }

        public string istrTags { get; set; }

        public string istrVideo { get; set; }

        public string istrCategory { get; set; }

        public string istrIBA { get; set; }

        public string istrAlcoholic { get; set; }

        public string istrGlass { get; set; }

        public string istrInstructions { get; set; }

        public string istrDrinkThumb { get; set; }

        public List<string> ilstIngredients { get; set; }

        public string istrDateModified { get; set; }
    }
}