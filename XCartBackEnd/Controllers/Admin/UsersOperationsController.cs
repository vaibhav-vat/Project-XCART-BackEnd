using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XCart.BL.AdminBL;
using XCart.DBEntities;

namespace XCartBackEnd.Controllers.Admin
{
    [Route("Adminusers")]
    [ApiController]
    public class UsersOperationsController : ControllerBase
    {




     

            private readonly UsersOperationsBL userbl;
            public UsersOperationsController(UsersOperationsBL _userbl)
            {
                userbl = _userbl;
            }


            [HttpGet("all/{status}")]
       
            public IEnumerable<USERS> AllProducts(string status)
            {

                return userbl.GetAllUsers(status);
            }


            [HttpPut("status/{uid}")]
            public int Get(int uid)
            {
                return userbl.ModifyUser(uid);
            }
      
    }
}