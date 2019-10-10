using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCart.DAL;
using XCart.DBEntities;

namespace XCart.BL
{
    public class AddressBL
    {
        DbXCART db;
        public AddressBL(DbXCART db)
        {
            this.db = db;
        }

        public IEnumerable<ADDRESSES> GetAllAddress(int uid)
        {
            return db.ADDRESSES.Where(a => a.UserId == uid).ToList();
        }

        public ADDRESSES AddressWithId(int aid)
        {
            return db.ADDRESSES.Find(aid);
        }

        public int AddAddress(ADDRESSES address)
        {
            if (address == null)
            {
                return 4004;
            }
            else
            {
                db.ADDRESSES.Add(address);
                db.SaveChanges();
                return 2002;
            }
        }

        public int ModifyAddress(ADDRESSES address)
        {
            if (address == null)
            { return 0; }

            else
            {

                db.Entry(address).State = EntityState.Modified;
                db.SaveChanges();

                return 1;
            }
        }
        public int DiscardAddress(int aid)
            {
                var address = db.ADDRESSES.Find(aid);
                db.ADDRESSES.Remove(address);
                db.SaveChanges();
                return 1;
            }   
    }
}
