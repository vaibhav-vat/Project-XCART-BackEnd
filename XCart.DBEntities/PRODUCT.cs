namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    [Table("PRODUCTS")]
    public class PRODUCTS
    {
        //public PRODUCT()
        //{
        //    CARTS = new HashSet<CART>();
        //    FEEDBACKS = new HashSet<FEEDBACK>();
        //    ORDER_PLACED = new HashSet<ORDER_PLACED>();
        //    PICTURES = new HashSet<PICTURE>();
        //    PRE_VISIT = new HashSet<PRE_VISIT>();
        //    PRODUCT_DESCRIPTION = new HashSet<PRODUCT_DESCRIPTION>();
        //    WISHLISTS = new HashSet<WISHLIST>();
        //}
        [Key]
        public int ProductId { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        public int? Price { get; set; }

        [StringLength(50000)]
        public string ProductShortDiscription { get; set; }

        public int? Stock { get; set; }

        public int? SupplierId { get; set; }

        public int? ProductDiscount { get; set; }

        [StringLength(1500)]
        public string Path { get; set; }

        [StringLength(1500)]
        public string Category { get; set; }
        [StringLength(1500)]
        public string TagLine { get; set; }
        [StringLength(10)]
        public string Status { get; set; }

        public virtual ICollection<CART> CARTS { get; set; }

        public virtual ICollection<FEEDBACKS> FEEDBACKS { get; set; }

        public virtual ICollection<ORDERPLACED> ORDERPLACED { get; set; }

        

        public virtual ICollection<PREVISIT> PREVISIT { get; set; }

        public virtual ICollection<PRODUCTDESCRIPTION> PRODUCTDESCRIPTION { get; set; }

        public virtual SUPPLIERS SUPPLIERS { get; set; }

        public virtual ICollection<WISHLISTS> WISHLISTS { get; set; }
    }
}
