using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodBlogs.Controllers
{
    public class UserPostController : Controller
    {
        // GET: UserPost
        public ActionResult Index()
        {
            return View();
        }
    }
}