namespace XCart.DBEntities

{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    [Table("WISHLISTS")]
    public class WISHLISTS
    {
        [Key]
        public int WishListId { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public virtual PRODUCTS PRODUCTS { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
