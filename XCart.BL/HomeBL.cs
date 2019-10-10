using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL
{
    public class HomeBL
    {
        private DbXCART db;
        
        public HomeBL(DbXCART _db)
        {
            
            db = _db;
        }

        public IEnumerable<PRODUCTS> getAllProduct()
        {
           return db.PRODUCTS.ToList();
        }

        public IEnumerable<PRODUCTS> seachProduct(string search)
        {
            if (search == null)
            {
                return db.PRODUCTS.ToList();
            }
            else
            {
                return db.PRODUCTS.Where(p => p.ProductName.Contains(search) || p.Category.Contains(search)).ToList();

            }
        }

        public object cate()
        {
            var data = db.PRODUCTS.Select(p => p.Category).Distinct();
            return data;
                
        }

        public object catesearch(string category)
        {
            var data = db.PRODUCTS.Where(p => p.Category.Contains(category)).Select(p => p);
            return data;
        }
        public PRODUCTS ProductWithId(int id)
        {
            return db.PRODUCTS.Find(id);
        }
    }
}
