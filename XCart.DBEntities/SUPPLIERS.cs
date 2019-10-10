namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    [Table("SUPPLIERS")]
    public class SUPPLIERS
    {
        //public SUPPLIER()
        //{
        //    ADDRESSES = new HashSet<ADDRESS>();
        //    PRODUCTS = new HashSet<PRODUCT>();
        //}


        [Key]
        public int SupplierId { get; set; }

        [StringLength(50)]
        public string SupplierName { get; set; }

        public virtual ICollection<ADDRESSES> ADDRESSES { get; set; }

        public virtual ICollection<PRODUCTS> PRODUCTS { get; set; }
    }
}
