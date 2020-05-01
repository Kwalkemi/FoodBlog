using FoodBlogs.Models;
using FoodBlogs.Models.MyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLibrary;
using FoodBlogs.Business_Layer;
using System.Data;
using System.Reflection;
using DocumentFormat.OpenXml.Drawing;
using System.Web.Hosting;

namespace FoodBlogs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Post lPost = null;
            XmlFunction lXmlFunction = new XmlFunction();
            List<Post> lstPost = new List<Post>();
            //string rootpath = HostingEnvironment.ApplicationPhysicalPath;
            string lstrPath = HostingEnvironment.ApplicationPhysicalPath + "Xml";
            lstrPath = lstrPath.Remove(lstrPath.IndexOf("Code\\FoodBlogs\\"));
            lstrPath = lstrPath + "Xml";
            string[] lstrFilearray = Directory.GetFiles(lstrPath);
            foreach (string lstrFile in lstrFilearray)
            {
                lPost = new Post();
                FileInfo fileInfo = new FileInfo(lstrFile);
                lPost.idtCreatedPost = fileInfo.LastWriteTime;
                
                string filename = lstrFile.Substring(lstrFile.LastIndexOf('\\') + 1);
                lPost.istrUniqueId = lXmlFunction.GetElementsAtNode(lstrPath, filename, "UniqueId").FirstOrDefault();
                lPost.istrPostHeading = lXmlFunction.GetElementsAtNode(lstrPath, filename, "Heading").FirstOrDefault();
                lPost.istrImage = lXmlFunction.GetElementsAtNode(lstrPath, filename, "Image").FirstOrDefault();
                string[] lstrFrontContent = lXmlFunction.GetElementsAtNode(lstrPath, filename, "FrontContent").FirstOrDefault().Split('*');
                if (lstrFrontContent != null && lstrFrontContent.Count() > 0)
                    lPost.istrFrontContent = lstrFrontContent.Aggregate("", (current, next) => current + "</br>" + next);
                lPost.ilstIngredient = lXmlFunction.GetElementsAtNode(lstrPath, filename, "Ingredient").FirstOrDefault().ToString().Split(',').ToList();
                string[] lstrBackContent = lXmlFunction.GetElementsAtNode(lstrPath, filename, "BackContent").FirstOrDefault().Split('*');
                if (lstrBackContent != null && lstrBackContent.Count() > 0)
                    lPost.istrBackContent = lstrBackContent.Aggregate("", (current, next) => current + "</br>" + next);
                lstPost.Add(lPost);
            }
            lstPost = lstPost.OrderByDescending(x => x.idtCreatedPost).ToList();
            return View(lstPost);
        }

        public ActionResult Post(string astrPostname)
        {
            Post lPost = new Post();
            lPost.iComment = new Food_Comments();
            Business_Logic lBusiness_Logic = new Business_Logic();
            FoodBlogEntities lFoodBlogEntities = new FoodBlogEntities();
            string filename = astrPostname + ".xml";
            XmlFunction lXmlFunction = new XmlFunction();
            string lstrPath = @"D:\Visual Studio Project\FoodBlogs\Xml";
            lPost.istrUniqueId = lXmlFunction.GetElementsAtNode(lstrPath, filename, "UniqueId").FirstOrDefault();
            lPost.istrPostHeading = lXmlFunction.GetElementsAtNode(lstrPath, filename, "Heading").FirstOrDefault();
            lPost.istrImage = lXmlFunction.GetElementsAtNode(lstrPath, filename, "Image").FirstOrDefault();
            string[] lstrFrontContent = lXmlFunction.GetElementsAtNode(lstrPath, filename, "FrontContent").FirstOrDefault().Split('*');
            if (lstrFrontContent != null && lstrFrontContent.Count() > 0)
                lPost.istrFrontContent = lstrFrontContent.Aggregate("", (current, next) => current + "</br>" + next);
            lPost.ilstIngredient = lXmlFunction.GetElementsAtNode(lstrPath, filename, "Ingredient").FirstOrDefault().ToString().Split(',').ToList();
            string[] lstrBackContent = lXmlFunction.GetElementsAtNode(lstrPath, filename, "BackContent").FirstOrDefault().Split('*');
            if (lstrBackContent != null && lstrBackContent.Count() > 0)
                lPost.istrBackContent = lstrBackContent.Aggregate("", (current, next) => current + "</br>" + next);

            lPost.ilstComment = lFoodBlogEntities.Food_Comments.Where(x => x.Food_Comment_Page == astrPostname).ToList();

            lBusiness_Logic.InsertOrUpdateVisitCount(astrPostname);

            return View(lPost);
        }

        public ActionResult Comment(Post aPost)
        {
            DBFunction lDBFunction = new DBFunction();
            Dictionary<string, string> ldict = new Dictionary<string, string>();
            ldict.Add("Food_Comment_Description", aPost.iComment.Food_Comment_Description);
            ldict.Add("Food_Comment_User_Name", aPost.iComment.Food_Comment_User_Name);
            ldict.Add("Food_Comment_Email_id", aPost.iComment.Food_Comment_Email_id);
            ldict.Add("Food_Comment_Page", aPost.istrUniqueId);
            lDBFunction.InsertIntoTable("FoodBlog", "Food_Comments", ldict);
            return RedirectToAction("Post", new { astrPostname = aPost.istrUniqueId });
        }

        [ChildActionOnly]
        public ActionResult PopularPost()
        {
            Business_Logic lBusiness_Logic = new Business_Logic();
            List<string> lstPostUniqueId = new List<string>();
            DBFunction lDBFunction = new DBFunction();
            string lstrQuery = "Select top 5 * from Post_Visit_Count order by Post_visit_count desc";
            DataTable ldtbTable = lDBFunction.FetchDataFromDatabase("FoodBlog", lstrQuery);

            foreach(DataRow dr in ldtbTable.Rows)
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



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}