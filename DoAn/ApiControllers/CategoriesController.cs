using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoAn.ApiControllers
{
    public class CategoriesController : ApiController
    {
        public List<Category> Get()
        {
            WebDBContext db = new WebDBContext();
            List<Category> categories = db.Categories.ToList();
            return categories;
        }
    }
}
