namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     
    //using XCART.Models;

    [Table("USERS")]
    public class USERS
    {
        //public USER()
        //{
        //    ADDRESSES = new HashSet<ADDRESS>();
        //    CARTs = new HashSet<CART>();
        //    FEEDBACKS = new HashSet<FEEDBACK>();
        //    ORDER_PLACED = new HashSet<ORDER_PLACED>();
        //    PRE_VISIT = new HashSet<PRE_VISIT>();
        //    SEARCH_HISTORY = new HashSet<SEARCH_HISTORY>();
        //    WISHLISTS = new HashSet<WISHLIST>();
        //}

        [Key]
        public int UserId { get; set; }

        [StringLength(50)]
        public string EmailId { get; set; }

        [StringLength(1000)]
        public string Password { get; set; }

        [StringLength(15)]
        public string PhoneNo { get; set; }

        [Column(TypeName = "date")]
        public DateTime? TimeStamp { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(200)]
        public string Question { get; set; }

        [StringLength(200)]
        public string Answer { get; set; }
        [StringLength(10)]
        public string Role { get; set; }
        [StringLength(10)]
        public string Status { get; set; }


        //public SECURITYQUESTIONS SECURITYQUESTIONS { get; set; }


        public virtual ICollection<ADDRESSES> ADDRESSES { get; set; }

        public virtual ICollection<CART> CART { get; set; }

        public virtual ICollection<FEEDBACKS> FEEDBACKS { get; set; }

        public virtual ICollection<ORDERPLACED> ORDERPLACED { get; set; }

        public virtual ICollection<PREVISIT> PREVISIT { get; set; }

        public virtual ICollection<SEARCHHISTORY> SEARCHHISTORY { get; set; }

        public virtual ICollection<WISHLISTS> WISHLISTS { get; set; }
    }
}
