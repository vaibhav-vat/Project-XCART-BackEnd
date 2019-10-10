using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using XCart.BL;
using XCart.DAL;
using XCart.DBEntities;
using XCart.ViewModel;

namespace XCartBackEnd.Controllers
{
    [Route("user")]
    [ApiController]
    
    public class LogInRegisterController : ControllerBase
    {

        SeqQuestions que = new SeqQuestions();
        private readonly LogInRegisterBL loginregisterbl;
        



        public LogInRegisterController(IConfiguration config)
        {
           
            loginregisterbl = new LogInRegisterBL(config);
        }



        [HttpGet("login/{email}/{password}")]
        public string LogIn(string email, string password)
        {
            
           var data = loginregisterbl.LogIn(email, password);
            
            
            

            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }
        
        [HttpGet("forgotlogin/{email}")]
        public string LogIn(string email)
        {

            var data = loginregisterbl.forgotLog(email);




            return Newtonsoft.Json.JsonConvert.SerializeObject(data);
        }

        [HttpPost("register")]
        public int Register(USERS user)
        {
            return loginregisterbl.Register(user);
        }

        [HttpPost("security")]
        public string SecCheck(USERS user)
        {
            
            return Newtonsoft.Json.JsonConvert.SerializeObject(loginregisterbl.check(user));
        }

        [HttpGet("details/{uid}")]
        public USERS Details(int uid)
        {
            return loginregisterbl.getdetails(uid);
        }


        [HttpGet("question")]
        public string[] secquestion()
        {
            var questions = que.getQuestions();
            return questions;

        }


        [HttpGet("logout")]
        public int Logout()
        {
            return loginregisterbl.Logout();
        }


    }
}
