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
    [Route("cart")]
    [ApiController]
    public class CartController : ControllerBase
    {

        CartBL bl;


        public CartController(DbXCART db)
        {
            bl = new CartBL(db);
        }


        [HttpGet("AllCartItems/{uid}")]
        public object Get(int uid)
        {
            return bl.GetAllCartItems(uid);
        }


        [HttpGet("AddToCart/{uid}/{pid}")]
        public int AddToCart(int pid, int uid)
        {

            return bl.AddToCart(pid, uid);
        }

        [HttpGet("incquantity/{cid}")]
        public int incQuantity(int cid)
        {
            return bl.IncQuantity(cid);
        }

        [HttpGet("decquantity/{cid}")]
        public int DecQuantity(int cid)
        {
            return bl.DecQuantity(cid);
        }

        [HttpGet("remove/{cid}")]
        public int RemoveProduct(int cid)
        {
            return bl.RemoveProduct(cid);
        }


    }
}
 


