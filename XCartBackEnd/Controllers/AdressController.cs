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
    [Route("address")]
    [ApiController]
    public class AdressController : ControllerBase
    {


         
        AddressBL bl;
        public AdressController(DbXCART db)
        {
            this.bl = new AddressBL(db);
        }

        [HttpGet("alladdress/{uid}")]
        public IEnumerable<ADDRESSES> Get(int uid)
        {
            return bl.GetAllAddress(uid);
        }


        [HttpGet("address/{aid}")]
        public ADDRESSES GetAddress(int aid)
        {
            return bl.AddressWithId(aid);
        }
      


        [HttpPost("create")]
        public int Post(ADDRESSES address)
       {
            return bl.AddAddress(address);
            
            
       }


        [HttpPut("edit")]
        public int Put(ADDRESSES address)
        {
            return bl.ModifyAddress(address);
           
        }

        [HttpDelete("delete/{aid}")]
        public int Delete(int aid)
        {
            return bl.DiscardAddress(aid);
        }
    }



}
