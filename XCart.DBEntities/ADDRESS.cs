namespace XCart.DBEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ADDRESSES")]
    public class ADDRESSES
    {
        //public ADDRESS()
        //{
        //    ORDER_PLACED = new HashSet<ORDER_PLACED>();
        //}
        [Key]
      
        public int AddressId { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(10000)]
        public string AddressLine { get; set; }

        public int? UserId { get; set; }

        public int? SupplierId { get; set; }

        public virtual SUPPLIERS SUPPLIERS { get; set; }

        public virtual USERS USERS { get; set; }
       
    }
}
