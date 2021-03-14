using FoodBlogs.Business_Layer;
using FoodBlogs.JsonClass;
using FoodBlogs.Models.MyModel;
using FoodBlogs.Web_Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserLibrary;

namespace FoodBlogs.Controllers
{
    public class DrinksController : BaseController
    {
        // GET: Drinks
        public ActionResult Index()
        {
            List<Cocktail> lstCocktail = new List<Cocktail>();
            CocktailHeaderJsonClass drinksJsonClass = new CocktailHeaderJsonClass();
            ConsumingWebService cocktailWebService = new ConsumingWebService();
            drinksJsonClass = cocktailWebService.CallNonAlcoholicCocktailWebService();

            Cocktail cocktail = null;
            foreach (CocktailHeader cocktailHeader in drinksJsonClass.ilstCocktailHeader)
            {
                cocktail = new Cocktail();
                cocktail.CocktailId = Convert.ToInt32(cocktailHeader.idDrink);
                cocktail.CocktailName = cocktailHeader.strDrink;
                cocktail.CocktailUrl = cocktailHeader.strDrinkThumb;
                lstCocktail.Add(cocktail);
            }

            drinksJsonClass = cocktailWebService.CallAlcoholicCocktailWebService();
            foreach (CocktailHeader cocktailHeader in drinksJsonClass.ilstCocktailHeader)
            {
                cocktail = new Cocktail();
                cocktail.CocktailId = Convert.ToInt32(cocktailHeader.idDrink);
                cocktail.CocktailName = cocktailHeader.strDrink;
                cocktail.CocktailUrl = cocktailHeader.strDrinkThumb;
                lstCocktail.Add(cocktail);
            }

            lstCocktail = lstCocktail.OrderBy(x => x.CocktailName).ToList();
            return View(lstCocktail);

        }

        public ActionResult Detail(int aintId)
        {
            CocktailWebService webService = new CocktailWebService();
            Business_Logic lBusiness_Logic = new Business_Logic();
            CocktailDetailJsonClass cocktailDetailJson = new CocktailDetailJsonClass();
            cocktailDetailJson = webService.CocktailDetailWebService(aintId);
            string lstrIngredient = string.Empty;
            CocktailDetail cocktailDetail = new CocktailDetail();
            cocktailDetail.istrDrinkId = cocktailDetailJson.ilstCocktailDetail[0].idDrink;
            cocktailDetail.istrDrinkName = cocktailDetailJson.ilstCocktailDetail[0].strDrink;
            cocktailDetail.istrDrinkThumb = cocktailDetailJson.ilstCocktailDetail[0].strDrinkThumb;
            cocktailDetail.ilstIngredients = new List<string>();
            cocktailDetail.icomments = lBusiness_Logic.GetCommentlistByPostName();
            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient1))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient1;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure1))
                    lstrIngredient = lstrIngredient + " " +  cocktailDetailJson.ilstCocktailDetail[0].strMeasure1;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient2))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient2;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure2))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure2;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }
            
            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient3))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient3;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure3))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure3;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient4))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient4;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure4))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure4;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient5))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient5;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure5))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure5;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }
            
            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient6))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient6;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure6))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure6;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient7))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient7;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure7))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure7;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient8))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient8;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure8))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure8;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient9))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient9;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure9))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure9;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient10))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient10;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure10))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure10;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient11))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient11;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure11))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure11;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient12))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient12;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure12))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure12;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient13))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient13;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure13))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure13;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient14))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient14;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure14))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure14;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strIngredient15))
            {
                lstrIngredient = cocktailDetailJson.ilstCocktailDetail[0].strIngredient15;
                if (!string.IsNullOrEmpty(cocktailDetailJson.ilstCocktailDetail[0].strMeasure15))
                    lstrIngredient = lstrIngredient + " " + cocktailDetailJson.ilstCocktailDetail[0].strMeasure15;
                cocktailDetail.ilstIngredients.Add(lstrIngredient);
            }

            cocktailDetail.istrInstructions = cocktailDetailJson.ilstCocktailDetail[0].strInstructions;
            return View(cocktailDetail);
        }   
    }
}