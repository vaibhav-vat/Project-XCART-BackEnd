namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    public class ORDERSHISTORY
    {
        [Key]
        public int OrderHistoryId { get; set; }
        public int? UserId { get; set; }

        public int? OrderNo { get; set; }

        public int? ProductId { get; set; }

        [StringLength(110)]
        public string ProductName { get; set; }
        [StringLength(110)]
        public string CustomerName { get; set; }
        public int? Price { get; set; }

        [Column(TypeName = "date")]
        public DateTime? OrderDate { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DeliveryDate { get; set; }

        [StringLength(1500)]
        public string Path { get; set; }

        public int? TotalAmount { get; set; }

        public int? Quantity { get; set; }


        [StringLength(50)]
        public string OrderStatus { get; set; }

   

        [StringLength(500)]
        public string DiliveryAddress { get; set; }

        [StringLength(50)]
        public string ModeOfPayment { get; set; }

       
    }
}
