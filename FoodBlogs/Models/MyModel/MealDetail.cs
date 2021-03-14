using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Models.MyModel
{
    public class MealDetail :BaseModel
    {
        public int iintMealId { get; set; }

        public string istrMealName { get; set; }

        public string istrDrinkAlternateName { get; set; }

        public string istrTags { get; set; }

        public string istrYouVideo { get; set; }

        public string istrCategory { get; set; }

        public string istrArea { get; set; }

        public string istrAlcoholic { get; set; }

        public string istrInstructions { get; set; }

        public string istrMealThumb { get; set; }

        public List<string> ilstIngredients { get; set; }

        public string istrDateModified { get; set; }
    }
}