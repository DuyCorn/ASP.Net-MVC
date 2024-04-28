using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DoAn.ApiControllers
{
    public class BrandsController : ApiController
    {
        public List<Brand> Get()
        {
            WebDBContext db = new WebDBContext();
            List<Brand> brands = db.Brands.ToList();
            return brands;
        }

        public Brand GetBrandByID(long id)
        {
            WebDBContext db = new WebDBContext();
            Brand brand = db.Brands.Where(row => row.BrandID == id).FirstOrDefault();
            return brand;
        }
        public void PostBrand(Brand newBr)
        {
            WebDBContext db = new WebDBContext();
            db.Brands.Add(newBr);
            db.SaveChanges();
        }
        public void PutBrand(Brand brand)
        {
            WebDBContext db = new WebDBContext();
            Brand oldBrand = db.Brands.Where(row => row.BrandID == brand.BrandID).FirstOrDefault();
            oldBrand.BrandName = brand.BrandName;
            db.SaveChanges();
        }
        public void DeleteBrand(long id)
        {
            WebDBContext db = new WebDBContext();
            Brand oldBrand = db.Brands.Where(row => row.BrandID == id).FirstOrDefault();
            db.Brands.Remove(oldBrand);
            db.SaveChanges();
        }
    }
}
