using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Models.MyModel
{
    public class Post : BaseModel
    {
        public string istrUniqueId { get; set; }
        public string istrPostHeading { get; set; }
        public string istrFrontContent { get; set; }
        public string istrImage { get; set; }
        public List<string> ilstIngredient { get; set; }
        public List<string> ilstBackContent { get; set; }
        public DateTime idtCreatedPost { get; set; }
    }
}