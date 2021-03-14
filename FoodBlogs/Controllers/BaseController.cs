using FoodBlogs.Business_Layer;
using FoodBlogs.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLibrary;
using FoodBlogs.Models.MyModel;

namespace FoodBlogs.Controllers
{
    public class BaseController : Controller
    {
        [ChildActionOnly]
        public ActionResult PopularPost()
        {
            Business_Logic lBusiness_Logic = new Business_Logic();
            List<string> lstPostUniqueId = new List<string>();
            DBFunction lDBFunction = new DBFunction();
            string lstrQuery = "Select top 5 * from Post_Visit_Count order by Post_visit_count desc";
            DataTable ldtbTable = lDBFunction.FetchDataFromDatabase("FoodBlog", lstrQuery);

            foreach (DataRow dr in ldtbTable.Rows)
            {
                lstPostUniqueId.Add(Convert.ToString(dr["Post_Name"]));
            }
            ViewBag.listPopularPost = lBusiness_Logic.GetPostNameById(lstPostUniqueId);
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult RecentPost()
        {
            FoodBlogEntities foodBlogEntities = new FoodBlogEntities();
            List<Food_Blog_Master> lstFoodBlogMaster = foodBlogEntities.Food_Blog_Master.OrderByDescending(x => x.Created_Post_Date).Take(5).ToList();

            List<string> lstPostUniqueId = new List<string>();

            foreach (Food_Blog_Master lFood_Blog_Master in lstFoodBlogMaster)
            {
                lstPostUniqueId.Add(Convert.ToString(lFood_Blog_Master.Food_Blog_Post_Title));
            }
            ViewBag.listRecentPost = lstPostUniqueId;
            return PartialView("_RecentPost");
        }

        [HttpPost]
        public ActionResult Comment(string comment)
        {
            Comments aPost = new Comments();
            aPost.iFoodComments = new Food_Comments();
            DBFunction lDBFunction = new DBFunction();
            Dictionary<string, string> ldict = new Dictionary<string, string>();
            ldict.Add("Food_Comment_Description", aPost.iFoodComments.Food_Comment_Description);
            ldict.Add("Food_Comment_User_Name", aPost.iFoodComments.Food_Comment_User_Name);
            ldict.Add("Food_Comment_Email_id", aPost.iFoodComments.Food_Comment_Email_id);
            ldict.Add("Food_Comment_Page", aPost.istrUniqueId);
            //lDBFunction.InsertIntoTable("FoodBlog", "Food_Comments", ldict);
            return PartialView("_Comments", aPost );
        }
    }
}