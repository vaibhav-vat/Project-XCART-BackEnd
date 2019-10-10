using System;
using System.Collections.Generic;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using XCart.Common;

namespace XCart.BL
{
    public class AccountSettingBL
    {

        DbXCART db;
        public AccountSettingBL(DbXCART db)
        {
            this.db = db;
        }

        public IEnumerable<object> Getdetails(int uid)
        {
            var user = from u in db.USERS
                       where u.UserId == uid
                       join ad in db.ADDRESSES on u.UserId equals ad.UserId
                       select new
                       {

                           u.FirstName,
                           u.LastName,
                           u.EmailId,
                           u.PhoneNo,
                           u.Gender,
                           u.DateOfBirth,
                           u.Question,
                           u.Answer,
                           ad.State,
                           ad.City,
                           ad.PostalCode,
                           ad.AddressLine


                       };

            return user;
        }

        public object GetProfile(int uid)
        {
            var user = db.USERS.Find(uid);
            return user;
        }

        public int AddAddress(ADDRESSES address,int uid)
        {
            //var address = new ADDRESSES();
            address.UserId = uid;
            db.ADDRESSES.Add(address);
            db.SaveChanges();
            return 2002;
        }

        public int EditProfile(USERS user)
        {

            var oldentry = db.USERS.Find(user.UserId);
            if (user.DateOfBirth != null)
            {
                oldentry.DateOfBirth = user.DateOfBirth;
            }
            if (user.Gender != null)
            {
                oldentry.Gender = user.Gender;
            }
            if (user.FirstName != null)
            {
                oldentry.FirstName = user.FirstName;
            }
            if ( user.LastName != null)
            {
                oldentry.LastName = user.LastName;
            }
            if (user.PhoneNo != null)
            {
                oldentry.PhoneNo = user.PhoneNo;
            }

            if (user.EmailId != null && oldentry.EmailId != user.EmailId)
            {
                var data = db.USERS.Where(u => u.EmailId == user.EmailId).FirstOrDefault();
                if (data != null)
                {
                    return 4000;
                }
                else
                {
                    oldentry.EmailId = user.EmailId;
                }
            }
            if (user.Password != null)
            {
                
                oldentry.Password = Hash.Hashing(user.Password);
            }
            if (user.Question != null)
            {
                oldentry.Question = user.Question;
            }
            if (user.Answer != null)
            {
                oldentry.Answer = user.Answer;
            }
            if (user.Role == "admin")
            {
                oldentry.Role = "admin";
            }

            db.Entry(oldentry).State = EntityState.Modified;
            db.SaveChanges();
            return 2002;
        }


        public int EditAddress(ADDRESSES address)
        {

            db.Entry(address).State = EntityState.Modified;
            db.SaveChanges();
            return 2002;
        }
    }
}
