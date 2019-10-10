using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL.AdminBL
{
    public class ProductsOperationsBL
    {
        DbXCART db;
        public ProductsOperationsBL( DbXCART db)
        {
            this.db = db;
        }

        public IEnumerable<PRODUCTS> GetAllProducts()
        {
            return db.PRODUCTS.Where(p => p.Status == "Active").ToList();
        }

        public IEnumerable<PRODUCTS> GetDeactiveProducts()
        {
            return db.PRODUCTS.Where(p => p.Status == "Deactive").ToList();
        }

        public PRODUCTS ProductWithId(int id)
        {
            return db.PRODUCTS.Find(id);
        }

        public IEnumerable<PRODUCTS> ProductsOfcategory(string category)
        {
            return db.PRODUCTS.Where(p => p.Category == category).ToList();
        }

        public int AddProduct(PRODUCTS product)
        {
            if (product == null)
            { return 0; }
            else
            {
                product.Status = "Active";
                db.PRODUCTS.Add(product);
                db.SaveChanges();
                return 1;
            }

        }

        
        public int ModifyProduct( PRODUCTS product)
        {
            var oldentry = db.PRODUCTS.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if ( product == null)
            { return 0; }
             else
            {
                oldentry.ProductName = product.ProductName;
                oldentry.Price = product.Price;
                oldentry.Path = product.Path;
                oldentry.TagLine = product.TagLine;
                oldentry.ProductShortDiscription = product.ProductShortDiscription;
                oldentry.Category = product.Category;

                db.Entry(oldentry).State = EntityState.Modified;
                db.SaveChanges();
                
                return 1;
            }

        }





        public int DiscardProduct(int id)
        {
            
            var Product = db.PRODUCTS.Find(id);
            Product.Status = "Deactive";
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();
            
            return 1;
        }

        public int RemoveProduct(int id)
        {

            var Product = db.PRODUCTS.Find(id);
            db.PRODUCTS.Remove(Product);
            db.SaveChanges();
            return 1;
        }

        public int Activate(int id)
        {
            var Product = db.PRODUCTS.Find(id);
            Product.Status = "Active";
            db.Entry(Product).State = EntityState.Modified;
            db.SaveChanges();

            return 1;
        }
    }
}


        //public ActionResult Index()
        //{
        //    var pRODUCTS = db.PRODUCTS.Include(p => p.SUPPLIERS);
        //    return View(pRODUCTS.ToList());
        //}

       
        //public ActionResult Create()
        //{
        //    ViewBag.SupplierId = new SelectList(db.SUPPLIERS, "SupplierId", "SupplierName");
        //    return View();
        //}
 
                
      
        