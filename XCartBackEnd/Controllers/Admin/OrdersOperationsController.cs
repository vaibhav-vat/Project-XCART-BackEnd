using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XCart.BL.AdminBL;
using XCart.DAL;
using XCart.DBEntities;

namespace XCartBackEnd.Controllers.Admin
{
    [Route("Admin/orders")]
    [ApiController]
    public class OrdersOperationsController : ControllerBase
    {
 
        private readonly OrdersOperationsBL orderbl;
        public OrdersOperationsController(DbXCART db)
        {
            orderbl = new OrdersOperationsBL(db);
        }


        [HttpGet("all/{status}")]

        public object AllordersOfStatus(string status)
        {

            return orderbl.GetAllOrdersOfStatus(status);
        }
        [HttpGet("allorders")]

        public object AllOrders()
        {

            return orderbl.GetAllOrders();
        }

        [HttpGet("status/{oid}")]
        public int Get(int oid)
        {
            return orderbl.ModifyProduct(oid);
        }

        [HttpGet("orderHistory")]

        public object OrderHistory()
        {

            return orderbl.OrderHistory();
        }


    }
}