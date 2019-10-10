using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using XCart.Common;
using XCart.DAL;
using XCart.DBEntities;
using XCart.ViewModel;


namespace XCart.BL
{
    public class LogInRegisterBL
    {
        LoginSuccess ls;
        private DbXCART db = new DbXCART();

        public LogInRegisterBL(IConfiguration _config)
        {
            
            ls = new LoginSuccess(_config);
        }
        public USERS getdetails(int uid)
        {
            return db.USERS.Find(uid);
        }


        public LoginSuccess LogIn(string Uemail, string Upassword)
        {
            Upassword=Hash.Hashing(Upassword);
            var Data = db.USERS.Where(u => u.EmailId == Uemail && u.Password == Upassword).Select(s => s).FirstOrDefault();
            if (Data != null)
            {
                if (Data.Role == "admin")
                {

                    ls.id = Data.UserId;
                    ls.Role = Data.Role;
                    ls.token = ls.GenerateJSONWebToken(Data.Role);
                    ls.firstName = Data.FirstName;
                    return ls;
                    //return "No Record Found! Please Register First ";

                }

                if (Data.Role == "customer")
                {
                    ls.id = Data.UserId;
                    ls.Role = Data.Role;
                    ls.token = ls.GenerateJSONWebToken(Data.Role);
                    ls.firstName = Data.FirstName;
                    return ls;


                }
            }
            else
            {
                Data = db.USERS.Where(u => u.EmailId == Uemail || u.Password == Upassword).Select(s => s).FirstOrDefault();
                if (Data != null)
                { ls.id = -2; }
                else
                { ls.id = -1; }
                
                ls.Role = "anonymous";
                ls.token = ls.GenerateJSONWebToken("anonymous");
                return ls;
            }
            return null;
            
               
        }

        public object check(USERS user)
        {
            var Data = db.USERS.Where(u => u.UserId == user.UserId).Select(s => s).FirstOrDefault();
            if (Data != null)
            {
                ls.que = Data.Question;
                ls.ans = Data.Answer;
                return ls;
            }
            else
            {
                return "4000";
            }
        }

        public object forgotLog(string Uemail)
        {
            var Data = db.USERS.Where(u => u.EmailId == Uemail).Select(s => s).FirstOrDefault();
            if(Data != null)
            {
                ls.Role = Data.Role;
                ls.id = Data.UserId;
                return ls;
             }
            else
            {
                ls.Role = "anonymous";
                ls.id = -10;
                return ls;
            }
            
        }

        public int Register(USERS user)
        {
            var data = db.USERS.Where(u => u.EmailId == user.EmailId).FirstOrDefault();
            if (data != null)
            {
                return 4000;
            }
            if (user != null)
            { 
                user.Role = "customer";
                user.TimeStamp = DateTime.Now;
                 user.Password =  Hash.Hashing(user.Password);
                db.USERS.Add(user);
                db.SaveChanges();
                return 2000;
            }

            return 4004;

        }


        public int Logout()
        {
            // return "Logout successfull";
            return 2001;
        }





    }
}
