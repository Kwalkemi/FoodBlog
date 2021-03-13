using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserLibrary;
using FoodBlogs.Models;

namespace FoodBlogs.Business_Layer
{
    public class Business_Logic
    {
        string istrDatabase { get { return "FoodBlog"; } }
        public void InsertOrUpdateVisitCount(string astrPostName)
        {
            DBFunction lDBFunction = new DBFunction();
            Dictionary<string, string> ldict = new Dictionary<string, string>();
            ldict.Add("Post_Name", astrPostName);
            if (lDBFunction.CheckRecordExists(istrDatabase, "Post_Visit_Count", ldict))
            {
                string lstrQuery = "Select Post_visit_count from Post_Visit_Count where Post_Name = '" + astrPostName + "'";
                int PostCount = Convert.ToInt32(lDBFunction.FetchScalarFromDatabase(istrDatabase, lstrQuery));
                PostCount++;
                lstrQuery = "Update Post_Visit_Count set Post_visit_count = " + PostCount + " where Post_Name = '" + astrPostName + "'";
                lDBFunction.UpdateTable(istrDatabase, lstrQuery);
            }
            else
            {
                ldict.Add("Post_visit_count", "0");
                lDBFunction.InsertIntoTable(istrDatabase, "Post_Visit_Count", ldict);
            }
        }

        public List<string> GetPostNameById(List<string> alstPostUniqueId)
        {
            List<string> lstPostTitle = new List<string>();
            FoodBlogEntities lFoodBlogEntities = new FoodBlogEntities();
            foreach (string lFood_Blog in alstPostUniqueId)
            {
                string lstrFoodTitle = lFoodBlogEntities.Food_Blog_Master.FirstOrDefault(x => x.Food_Blog_Post_Unique_Id == lFood_Blog).Food_Blog_Post_Title;
                lstPostTitle.Add(lstrFoodTitle);
            }
            return lstPostTitle;
        }

        public List<string> GetFormattedList(List<string> astrList)
        {
            string lstrValue = string.Empty;
            int index = 0;
            List<string> lstDuplicatelist = new List<string>();
            lstDuplicatelist.AddRange(astrList);
            foreach (string str in lstDuplicatelist)
            {
                if (str.Contains("h5%"))
                {
                    lstrValue = str;
                    index = astrList.IndexOf(str);
                    if (index != -1)
                    {
                        astrList[index] = str.Replace("h5%", "<h5>");
                        lstrValue = str.Replace("h5%", "<h5>");
                    }
                    if (lstrValue.Contains("%h5"))
                    {
                        if (index != -1)
                            astrList[index] = lstrValue.Replace("%h5", "</h5>");
                    }
                }
            }
            return astrList;
        }
    }
}