using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XCart.BL;
using XCart.DAL;
using XCart.DBEntities;

namespace XCartBackEnd.Controllers
{
    [Route("order")]
    [ApiController]
    public class PlaceAnOrderController : ControllerBase
    {
        PlaceAnOrderBL bl;


        public PlaceAnOrderController(DbXCART db)
        {
            bl = new PlaceAnOrderBL();
        }


        [HttpGet("currentorders/{uid}")]
        public IActionResult CurrentOrders(int uid)
        {

           return Ok(bl.getcurrentorders(uid));

        }
        [HttpPost("PlaceOrder/{uid}")]
        public int PlaceOrder(int uid,ADDRESSES address )
        {
            return bl.PlaceOrder(uid,address);
        }


        [HttpGet("orderHistory/{uid}")]
        public object OrdersHistory(int uid)
        {

            return bl.getOrderHistory(uid);

        }

        [HttpGet("remove/{oid}")]
        public int OrderRemove(int oid)
        {

            return bl.RemoveOrder(oid);

        }

    } 
}







//public ActionResult Details(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    ORDERPLACED oRDERPLACED = db.ORDERPLACED.Find(id);
//    if (oRDERPLACED == null)
//    {
//        return HttpNotFound();
//    }
//    return View(oRDERPLACED);
//}

//public ActionResult Create()
//{
//    var 



//Id = Session[0].ToString();
//    int UId = Convert.ToInt32(UserId);
//    var cartdata = db.CARTs.Where(c => c.UserId == UId).Select(c => c).ToList();
//    ORDERPLACED orderplaced = new ORDERPLACED();
//    if (cartdata.Count != 0)
//    {
//        var Orderplace = db.ORDERPLACED.Where(op => op.UserId == UId).FirstOrDefault();
//        if (Orderplace == null)
//        {
//            orderplaced.OrderNo = 1;
//        }
//        else
//        {
//            var CkOrdrNo = db.ORDERPLACED.Where(op => op.UserId == UId).OrderByDescending(op => op.OrderNo).FirstOrDefault();
//            orderplaced.OrderNo = CkOrdrNo.OrderNo + 1;
//        }

//        foreach (var item in cartdata)
//        {
//            orderplaced.UserId = UId;
//            orderplaced.ProductId = item.ProductId;
//            orderplaced.Price = item.PRODUCTS.Price;
//            orderplaced.OrderDate = DateTime.Now;
//            orderplaced.OrderedQuantity = item.ItemQuantity;
//            orderplaced.TotalAmount = orderplaced.Price * orderplaced.OrderedQuantity;
//            orderplaced.OrderStatus = "Pending";
//            orderplaced.ModeOfPayment = "COD";
//            db.ORDERPLACED.Add(orderplaced);
//            db.SaveChanges();

//        }


//        return RedirectToAction("Index", "OrderPlacedByUser");
//    }
//    else
//    {
//        return RedirectToAction("Index", "CARTBasket");
//    }

//    //ViewBag.AddressId = new SelectList(db.ADDRESSES, "AddressId", "State", oRDERPLACED.AddressId);
//    //ViewBag.ProductId = new SelectList(db.PRODUCTS, "ProductId", "ProductName", oRDERPLACED.ProductId);
//    //ViewBag.UserId = new SelectList(db.USERS, "UserId", "EmailId", oRDERPLACED.UserId);
//    return View();
//}


//public ActionResult Edit(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    ORDERPLACED oRDERPLACED = db.ORDERPLACED.Find(id);
//    if (oRDERPLACED == null)
//    {
//        return HttpNotFound();
//    }
//    ViewBag.AddressId = new SelectList(db.ADDRESSES, "AddressId", "State", oRDERPLACED.AddressId);
//    ViewBag.ProductId = new SelectList(db.PRODUCTS, "ProductId", "ProductName", oRDERPLACED.ProductId);
//    ViewBag.UserId = new SelectList(db.USERS, "UserId", "EmailId", oRDERPLACED.UserId);
//    return View(oRDERPLACED);
//}

//[HttpPost]
//[ValidateAntiForgeryToken]
//public ActionResult Edit([Bind(Include = "OderId,UserId,OrderNo,ProductId,Price,OrderDate,OrderedQuantity,TotalAmount,OrderStatus,ModeOfPayment,AddressId")] ORDERPLACED oRDERPLACED)
//{
//    if (ModelState.IsValid)
//    {
//        db.Entry(oRDERPLACED).State = EntityState.Modified;
//        db.SaveChanges();
//        return RedirectToAction("Index");
//    }
//    ViewBag.AddressId = new SelectList(db.ADDRESSES, "AddressId", "State", oRDERPLACED.AddressId);
//    ViewBag.ProductId = new SelectList(db.PRODUCTS, "ProductId", "ProductName", oRDERPLACED.ProductId);
//    ViewBag.UserId = new SelectList(db.USERS, "UserId", "EmailId", oRDERPLACED.UserId);
//    return View(oRDERPLACED);
//}

//public ActionResult Delete(int? id)
//{
//    if (id == null)
//    {
//        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//    }
//    ORDERPLACED oRDERPLACED = db.ORDERPLACED.Find(id);
//    if (oRDERPLACED == null)
//    {
//        return HttpNotFound();
//    }
//    return View(oRDERPLACED);
//}


//public ActionResult DeleteConfirmed(int id)
//{
//    ORDERPLACED oRDERPLACED = db.ORDERPLACED.Find(id);
//    db.ORDERPLACED.Remove(oRDERPLACED);
//    db.SaveChanges();
//    return RedirectToAction("Index");
//}

