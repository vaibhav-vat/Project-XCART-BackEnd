using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL.AdminBL
{
    public class UsersOperationsBL
    {

        DbXCART db;
        public UsersOperationsBL(DbXCART db)
        {
            this.db = db;
        }
        public IEnumerable<USERS> GetAllUsers(string status)
        {
            var data = db.USERS.Where(u => u.Status == status).ToList();
            return data;
        }

        public int ModifyUser(int uid)
        {
            var data = db.ORDERPLACED.Find(uid);
            if (data.OrderStatus == "Active")
            {
                data.OrderStatus = "Deactive";
            }
            else
            {
                data.OrderStatus = "Active";
            }
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();

            return 1;
        }
    }
}
