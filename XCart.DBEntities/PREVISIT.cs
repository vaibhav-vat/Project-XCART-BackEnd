namespace XCart.DBEntities


{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    public class PREVISIT
    {
        [Key]
        public int PreVisitId { get; set; }

        public int? ProductId { get; set; }

        public int? UserId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? PreVisitDate { get; set; }

        public virtual PRODUCTS PRODUCTS { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
