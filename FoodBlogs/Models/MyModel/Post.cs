using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Models.MyModel
{
    public class Post
    {
        public string istrUniqueId { get; set; }
        public string istrPostHeading { get; set; }
        public string istrFrontContent { get; set; }
        public string istrImage { get; set; }
        public List<string> ilstIngredient { get; set; }
        public string istrBackContent { get; set; }
        public DateTime idtCreatedPost { get; set; }
        public Food_Comments iComment { get; set; }
        public List<Food_Comments> ilstComment { get; set; }
    }
}