using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL
{
    public class PlaceAnOrderBL
    {
        DbXCART db = new DbXCART();
        //public PlaceAnOrderBL(DbXCART db)
        //{
        //    this.db = db;
        //}

        public Object getcurrentorders(int uid)
        {

          

            var res = from o in db.ORDERPLACED
                       where o.UserId == uid
                       join p in db.PRODUCTS on o.ProductId equals p.ProductId
                       select new
                       {
                           o.OderId,
                           o.OrderNo,
                           o.Price,
                           o.OrderDate,
                           o.OrderedQuantity,
                           o.TotalAmount,
                           o.OrderStatus,
                           o.ModeOfPayment,
                           o.Address,
                           p.ProductName,
                           p.Path
                       
                        };


            ArrayList al = new ArrayList();
            var ohis = db.ORDERSHISTORY.Where(oh => oh.UserId == uid).Select(oh => oh.OrderNo).Distinct().ToList();
            foreach (var item in ohis)
            {

                var data = from o in db.ORDERPLACED
                           where o.UserId == uid
                           join p in db.PRODUCTS on o.ProductId equals p.ProductId
                           select new
                           {
                               o.OderId,
                               o.OrderNo,
                               o.Price,
                               o.OrderDate,
                               o.OrderedQuantity,
                               o.TotalAmount,
                               o.OrderStatus,
                               o.ModeOfPayment,
                               o.Address,
                               p.ProductName,
                               p.Path

                           };


                al.Add(data);
            }

            







            return res;
        }

        public int RemoveOrder(int oid)
        {
            var po = db.ORDERPLACED.Where(op => op.OderId == oid).FirstOrDefault();
            db.ORDERPLACED.Remove(po);
            db.SaveChanges();
            return 2000;
        }

        public ArrayList getOrderHistory(int uid)
        {
            
            ArrayList al = new ArrayList();
            var ohis = db.ORDERSHISTORY.Where(oh => oh.UserId == uid).Select(oh => oh.OrderNo).Distinct().ToList();
            foreach (var item in ohis)
            {

                var data = from o in db.ORDERSHISTORY
                           where o.UserId == uid && o.OrderNo == item.Value
                           select new
                           {
                               o.DeliveryDate,
                               o.CustomerName,
                               o.ProductName,
                               o.OrderNo,
                               o.Price,
                               o.OrderDate,
                               o.Quantity,
                               o.TotalAmount,
                               o.OrderStatus,
                               o.ModeOfPayment,
                               o.DiliveryAddress,
                               o.Path,
                               o.OrderHistoryId,

                           };

               
                al.Add(data);
            }

            return al;

            
        }

        public int PlaceOrder(int uid, ADDRESSES address)
        {
            
            string addresssave = "State: " + address.State + " City: " + address.City + " Address Line: " + address.AddressLine + " Pin Code: " + address.PostalCode;  
            var cartdataOBJs = from c in db.CARTs
                           where c.UserId == uid
                           join p in db.PRODUCTS on c.ProductId equals p.ProductId
                           join u in db.USERS on c.UserId equals u.UserId
                           select new
                           {
                               u.UserId,
                               c.ProductId,
                               p.Price,
                               c.ItemQuantity
                           };
        var cartdata =  cartdataOBJs.ToList();



        
        ORDERPLACED PerOrder = new ORDERPLACED();
            if (cartdata.Count() != 0)
            {
                var oplace = db.ORDERPLACED.Where(op => op.UserId == uid).OrderByDescending(op => op.OrderNo).FirstOrDefault();
                var Orderplace = db.ORDERSHISTORY.Where(op => op.UserId == uid).FirstOrDefault();
                if (Orderplace == null)
                {
                    
                    if (oplace == null)
                    {
                        PerOrder.OrderNo = 1;
                    }
                    else
                    {
                        PerOrder.OrderNo = oplace.OrderNo + 1;
                    }
                }
                
                else
                {

                    if (oplace == null)
                    {
                        var CkOrdrNo = db.ORDERSHISTORY.Where(op => op.UserId == uid).OrderByDescending(op => op.OrderNo).FirstOrDefault();
                        PerOrder.OrderNo = CkOrdrNo.OrderNo + 1;
                    }
                    else
                    {
                        PerOrder.OrderNo = oplace.OrderNo + 1;
                    }
                    
                }

                foreach (var item in cartdata)
                {
                    ORDERPLACED orderplaced = new ORDERPLACED();
                    orderplaced.OrderNo= PerOrder.OrderNo;
                    orderplaced.UserId = uid;
                    orderplaced.ProductId = item.ProductId;
                    orderplaced.Price = item.Price;
                    orderplaced.OrderDate = DateTime.Now;
                    orderplaced.OrderedQuantity = item.ItemQuantity;
                    orderplaced.TotalAmount = orderplaced.Price * orderplaced.OrderedQuantity;
                    orderplaced.OrderStatus = "Pending";
                    orderplaced.ModeOfPayment = "cod";
                    orderplaced.Address = addresssave;

                    db.ORDERPLACED.Add(orderplaced);
                    db.SaveChanges();

                }

                var cartD = db.CARTs.Where(c => c.UserId == uid).Select(c => c).ToList();
                foreach (var item in cartD)
                {
                    db.CARTs.Remove(item);
                    db.SaveChanges();
                }
                return 2002;
            }
            else
            {
                return 4004;
            }


        }
    }
}
