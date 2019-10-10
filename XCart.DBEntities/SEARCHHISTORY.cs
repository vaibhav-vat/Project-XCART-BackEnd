namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    public class SEARCHHISTORY
    {
        [Key]
        public int SearchId { get; set; }

        public int? UserId { get; set; }

        [StringLength(50)]
        public string SearchTag { get; set; }

        [Column(TypeName = "date")]
        public DateTime? SearchDate { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
