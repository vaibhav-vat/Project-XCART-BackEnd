using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL.AdminBL
{
    public class OrdersOperationsBL
    {


        DbXCART db;
        public OrdersOperationsBL(DbXCART db)
        {
            this.db = db;
        }

        public object GetAllOrdersOfStatus(string status)
        {
            var data = from o in db.ORDERPLACED
                       where o.OrderStatus == status
                       join p in db.PRODUCTS on o.ProductId equals p.ProductId
                       join u in db.USERS on o.UserId equals u.UserId
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
                           p.Path,
                           u.FirstName,
                           u.LastName,
                           u.PhoneNo
                           
                           

                       };
            return data;
        }

        public object OrderHistory()
        {
            return db.ORDERSHISTORY.ToList();
        }

        public object GetAllOrders()
        {
            var data = from o in db.ORDERPLACED
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
            return data;
        }




        public int ModifyProduct(int oid)
        {

            var dataO = from o in db.ORDERPLACED
                       where o.OderId == oid
                       join p in db.PRODUCTS on o.ProductId equals p.ProductId
                       join u in db.USERS on o.UserId equals u.UserId
                       select new
                       {
                          p.ProductName,
                          p.Price,
                          p.Path,
                          u.FirstName,
                          u.LastName,
                          o.UserId,
                          o.TotalAmount,
                           o.OrderedQuantity,
                           o.OrderDate,
                           o.Address,
                           o.ModeOfPayment,
                           o.ProductId,
                           o.OrderNo,
                       };
              var data = dataO.FirstOrDefault();

            if (data != null)
            {
                ORDERSHISTORY oh = new ORDERSHISTORY();

                oh.ProductName = data.ProductName;
                oh.Price = data.Price;
                oh.UserId = data.UserId;
                oh.CustomerName = data.FirstName +" " +data.LastName;
                oh.TotalAmount = data.TotalAmount;
                oh.Quantity = data.OrderedQuantity;
                oh.OrderDate = data.OrderDate;
                oh.DiliveryAddress = data.Address;
                oh.ModeOfPayment = data.ModeOfPayment;
                oh.ProductId = data.ProductId;
                oh.DeliveryDate = DateTime.Now;
                oh.OrderNo = data.OrderNo;
                oh.OrderStatus = "Delivered";
                oh.Path = data.Path;

                db.ORDERSHISTORY.Add(oh);
                db.SaveChanges();
                var dataD = db.ORDERPLACED.Find(oid);
                db.ORDERPLACED.Remove(dataD);
                db.SaveChanges();
                return 1;
            }
            return 0;
        }

    }






}    