using FoodBlogs.Business_Layer;
using FoodBlogs.JsonClass;
using FoodBlogs.Models.MyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FoodBlogs.Controllers
{
    public class MealController : BaseController
    {
        // GET: Meal
        public ActionResult Index()
        {
            List<MealCategory> lstmealCategory = new List<MealCategory>();
            MealCategory mealCategory = null;
            ConsumingWebService consumingWebService = new ConsumingWebService();
            MealCategoryJsonClass mealCategoryJsonClass = consumingWebService.CallMealCategoryWebService();
            if (mealCategoryJsonClass.ilstMealCategory != null && mealCategoryJsonClass.ilstMealCategory.Count > 0)
            {
                foreach (MealCategoryJson category in mealCategoryJsonClass.ilstMealCategory)
                {
                    mealCategory = new MealCategory();
                    mealCategory.iintCategoryId = Convert.ToInt32(category.idCategory);
                    mealCategory.istrCategoryName = category.strCategory;
                    mealCategory.istrCategoryThumb = category.strCategoryThumb;
                    mealCategory.istrCategoryDescription = category.strCategoryDescription;
                    lstmealCategory.Add(mealCategory);
                }
            }
            return View(lstmealCategory);
        }

        public ActionResult MealList(string astrCategoryName)
        {
            List<MealList> lstmealList = new List<MealList>();
            MealList mealList = null;
            ConsumingWebService consumingWebService = new ConsumingWebService();
            MealListJsonClass mealListJsonClass = consumingWebService.CallMealListWebService(astrCategoryName);
            if (mealListJsonClass.ilstMealList != null && mealListJsonClass.ilstMealList.Count > 0)
            {
                foreach (MealListJson meal in mealListJsonClass.ilstMealList)
                {
                    mealList = new MealList();
                    mealList.iintMealId = Convert.ToInt32(meal.idMeal);
                    mealList.istrMealName = meal.strMeal;
                    mealList.istrMealThumb = meal.strMealThumb;
                    lstmealList.Add(mealList);
                }
            }

            return View(lstmealList);
        }
    }
}