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
    [Route("profile")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        AccountSettingBL bl;
        public ProfileController(DbXCART db)
        {
            bl = new AccountSettingBL(db);

        }


        [HttpGet("details/{uid}")]
        public object UserDetail(int uid)
        {
            return bl.GetProfile(uid);
        }

        [HttpPost("AddAddress/{uid}")]
        public int AddAddress(ADDRESSES address,int uid)
        {
            return bl.AddAddress(address, uid);
        }

        [HttpPut("EditProfile")]
        public int EditProfile(USERS user)
        {
            return bl.EditProfile(user);
        }


        [HttpPut("EditAddress")]
        public int EditAddress(ADDRESSES address)
        {
            return bl.EditAddress(address);
        }
    }
}