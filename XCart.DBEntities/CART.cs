namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("CART")]
    public class CART
    {
        [Key]
        public int CartId { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public int? ItemQuantity { get; set; }

        public virtual PRODUCTS PRODUCTS { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
