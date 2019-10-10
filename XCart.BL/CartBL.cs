using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL
{
    public class CartBL
    {
        DbXCART db;
        public CartBL(DbXCART db)
        {
            this.db = db;
        }

        public object GetAllCartItems(int uid)
        {
            var cart = from c in db.CARTs
                                  where c.UserId == uid
                                  join p in db.PRODUCTS on c.ProductId equals p.ProductId
                                  select new
                                  {
                                     c.CartId,
                                     p.Path,
                                     p.ProductName,
                                     p.Price,
                                     c.ItemQuantity

                                  };
            return cart;
        }

        public int AddToCart(int pid, int uid)
        {
            if (uid == -1)
            { return -1; }
            PRODUCTS product = db.PRODUCTS.Find(pid);


            if (product == null)
            {
                return 4004;
            }
            
            CART chk = db.CARTs.Where(c => c.UserId == uid && c.ProductId == pid).FirstOrDefault();
            CART cartobj = new CART();
            if (chk == null)
            {

                cartobj.UserId = uid;
                cartobj.ProductId = product.ProductId;
                cartobj.ItemQuantity = 1;
                db.CARTs.Add(cartobj);
                db.SaveChanges();
                return 2000;
            }
            else
            {
                
                chk.ItemQuantity += 1;

                db.Entry(chk).State = EntityState.Modified;
                db.SaveChanges();
                return 2001;


            }

           
        }
    

        public int IncQuantity(int cid)
        {
            var cart =  db.CARTs.Find(cid); 
            cart.ItemQuantity += 1;

            db.Entry(cart).State = EntityState.Modified;
            db.SaveChanges();
            return 2000;
            
        }


        public int DecQuantity(int cid)
        {
            var cart = db.CARTs.Find(cid);
            
                cart.ItemQuantity -= 1;
            
            if (cart.ItemQuantity == 0)
            {
                db.CARTs.Remove(cart);
                db.SaveChanges();
                return 2001;
            }
            db.Entry(cart).State = EntityState.Modified;
            db.SaveChanges();
            return 2000;

        }
        public int RemoveProduct(int cid)
        {
            var cart = db.CARTs.Find(cid);
            db.CARTs.Remove(cart);
            db.SaveChanges();
            return 2000;
        }
    }
}
