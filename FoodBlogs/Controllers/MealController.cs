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
                    mealCategory.istrCategoryDescription = category.strCategoryDescription.Replace("\r\n", "<br/>");
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

        public ActionResult MealDetail(int aintMealId)
        {
            MealDetail mealDetail = new MealDetail();
            Business_Logic lBusiness_Logic = new Business_Logic();
            string lstrIngredient = string.Empty;
            ConsumingWebService consumingWebService = new ConsumingWebService();
            MealDetailJsonClass mealDetailJsonClass = consumingWebService.CallMealDetailWebService(aintMealId);
            mealDetail.icomments = lBusiness_Logic.GetCommentlistByPostName();
            if (mealDetailJsonClass.ilstMealDetail != null && mealDetailJsonClass.ilstMealDetail.Count > 0)
            {
                foreach (MealDetailJson meal in mealDetailJsonClass.ilstMealDetail)
                {
                    mealDetail.ilstIngredients = new List<string>();
                    mealDetail.iintMealId = Convert.ToInt32(meal.idMeal);
                    mealDetail.istrMealName = meal.strMeal;
                    mealDetail.istrMealThumb = meal.strMealThumb;
                    mealDetail.istrTags = meal.strTags;
                    mealDetail.istrYouVideo = meal.strYoutube;
                    mealDetail.istrCategory = meal.strCategory;
                    mealDetail.istrInstructions = meal.strInstructions.Replace("\r\n", "<br/>");

                    if (!string.IsNullOrEmpty(meal.strIngredient1))
                    {
                        lstrIngredient = meal.strIngredient1;
                        if (!string.IsNullOrEmpty(meal.strMeasure1))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure1;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient2))
                    {
                        lstrIngredient = meal.strIngredient2;
                        if (!string.IsNullOrEmpty(meal.strMeasure2))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure2;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient3))
                    {
                        lstrIngredient = meal.strIngredient3;
                        if (!string.IsNullOrEmpty(meal.strMeasure3))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure3;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient4))
                    {
                        lstrIngredient = meal.strIngredient4;
                        if (!string.IsNullOrEmpty(meal.strMeasure4))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure4;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient5))
                    {
                        lstrIngredient = meal.strIngredient5;
                        if (!string.IsNullOrEmpty(meal.strMeasure5))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure5;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient6))
                    {
                        lstrIngredient = meal.strIngredient6;
                        if (!string.IsNullOrEmpty(meal.strMeasure6))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure6;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient7))
                    {
                        lstrIngredient = meal.strIngredient7;
                        if (!string.IsNullOrEmpty(meal.strMeasure7))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure7;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient8))
                    {
                        lstrIngredient = meal.strIngredient8;
                        if (!string.IsNullOrEmpty(meal.strMeasure8))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure8;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient9))
                    {
                        lstrIngredient = meal.strIngredient9;
                        if (!string.IsNullOrEmpty(meal.strMeasure9))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure9;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient10))
                    {
                        lstrIngredient = meal.strIngredient10;
                        if (!string.IsNullOrEmpty(meal.strMeasure10))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure10;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient11))
                    {
                        lstrIngredient = meal.strIngredient11;
                        if (!string.IsNullOrEmpty(meal.strMeasure11))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure11;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient12))
                    {
                        lstrIngredient = meal.strIngredient12;
                        if (!string.IsNullOrEmpty(meal.strMeasure12))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure12;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient13))
                    {
                        lstrIngredient = meal.strIngredient13;
                        if (!string.IsNullOrEmpty(meal.strMeasure13))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure13;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient14))
                    {
                        lstrIngredient = meal.strIngredient14;
                        if (!string.IsNullOrEmpty(meal.strMeasure14))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure14;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    if (!string.IsNullOrEmpty(meal.strIngredient15))
                    {
                        lstrIngredient = meal.strIngredient15;
                        if (!string.IsNullOrEmpty(meal.strMeasure15))
                            lstrIngredient = lstrIngredient + " " + meal.strMeasure15;
                        mealDetail.ilstIngredients.Add(lstrIngredient);
                    }

                    
                }
            }

            return View(mealDetail);
        }
    }
}