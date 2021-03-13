using FoodBlogs.JsonClass;
using FoodBlogs.Web_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodBlogs.Business_Layer
{
    public class ConsumingWebService
    {
        public CocktailHeaderJsonClass CallNonAlcoholicCocktailWebService()
        {
            CocktailWebService lCocktailWebService = new CocktailWebService();
            string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?a=Non_Alcoholic";
            return lCocktailWebService.CocktailListWebService(url);
        }

        public CocktailHeaderJsonClass CallAlcoholicCocktailWebService()
        {
            CocktailWebService lCocktailWebService = new CocktailWebService();
            string url = "https://www.thecocktaildb.com/api/json/v1/1/filter.php?a=Alcoholic";
            return lCocktailWebService.CocktailListWebService(url);
        }

        public CocktailDetailJsonClass CallCocktailDetailWebService(int aintCocktailId)
        {
            CocktailWebService lCocktailWebService = new CocktailWebService();
            return lCocktailWebService.CocktailDetailWebService(aintCocktailId);
        }

        public MealCategoryJsonClass CallMealCategoryWebService()
        {
            MealWebService mealWebService = new MealWebService();
            return mealWebService.MealCategoryWebService();
        }

        public MealListJsonClass CallMealListWebService(string astrCategoryName)
        {
            MealWebService mealWebService = new MealWebService();
            return mealWebService.MealListWebService(astrCategoryName);
        }

        public MealDetailJsonClass CallMealDetailWebService(int aintMealId)
        {
            MealWebService mealWebService = new MealWebService();
            return mealWebService.MealDetailWebService(aintMealId);
        }
    }
}