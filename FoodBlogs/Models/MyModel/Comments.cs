using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Models.MyModel
{
    public class Comments
    {
        public string istrUniqueId { get; set; }
        public Food_Comments iFoodComments { get; set; }

        public List<CommentList> ilstcommentLists { get; set; }
    }

    public class CommentList
    {
        public string username { get; set; }

        public string commentbody { get; set; }
    }
}