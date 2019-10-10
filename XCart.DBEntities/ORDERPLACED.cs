namespace XCart.DBEntities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;    

    public class ORDERPLACED
    {
        //public ORDER_PLACED()
        //{
        //    ORDERS_HISTORY = new HashSet<ORDERS_HISTORY>();
        //}

        [Key]
        public int OderId { get; set; }

        public int? UserId { get; set; }

        public int? OrderNo { get; set; }

        public int? ProductId { get; set; }

        public int? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }

        public int? OrderedQuantity { get; set; }

        public int? TotalAmount { get; set; }

        [StringLength(50)]
        public string OrderStatus { get; set; }

        [StringLength(50)]
        public string ModeOfPayment { get; set; }

        [StringLength(1000)]
        public string Address { get; set; }


       

        public virtual ICollection<PLACEDORDERADDRESS> PLACEDORDERADDRESS { get; set; }
        public virtual PRODUCTS PRODUCTS { get; set; }

        public virtual USERS USERS { get; set; }


    }
}
