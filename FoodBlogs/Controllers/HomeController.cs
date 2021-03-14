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
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            Post lPost = null;
            XmlFunction lXmlFunction = new XmlFunction();
            Business_Logic lBusiness_Logic = new Business_Logic();
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
                lBusiness_Logic.GetFormattedList(lPost.ilstIngredient);
                string[] lstrBackContent = lXmlFunction.GetElementsAtNode(lstrPath, filename, "BackContent").FirstOrDefault().Split('*');
                lPost.ilstBackContent = lBusiness_Logic.GetFormattedList(lstrBackContent.ToList());

                lstPost.Add(lPost);
            }
            lstPost = lstPost.OrderByDescending(x => x.idtCreatedPost).ToList();
            return View(lstPost);
        }


        public ActionResult Post(string astrPostname)
        {
            Post lPost = new Post();
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
            ///lPost.ilstIngredient.ForEach(x => { if(x.Contains("h3%") || x.Contains("%h3")){ x = x.Replace("h3%", "<h3>"); x = x.Replace("%h3","</h3>"); } });
            lBusiness_Logic.GetFormattedList(lPost.ilstIngredient);

            string[] lstrBackContent = lXmlFunction.GetElementsAtNode(lstrPath, filename, "BackContent").FirstOrDefault().Split('*');
            lPost.ilstBackContent = lBusiness_Logic.GetFormattedList(lstrBackContent.ToList());

            lPost.icomments = lBusiness_Logic.GetCommentlistByPostName(astrPostname);
            
            lBusiness_Logic.InsertOrUpdateVisitCount(astrPostname);

            return View(lPost);
        }

        [ChildActionOnly]
        public ActionResult NewRecipe()
        {
            return PartialView();
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