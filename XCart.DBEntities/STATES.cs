namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    [Table("STATES")]
    public class STATES
    {
        //public STATE()
        //{
        //    CITIES = new HashSet<CITy>();
        //}
        [Key]
        public int StateId { get; set; }

        [StringLength(50)]
        public string StateName { get; set; }

        public virtual ICollection<CITIES> CITIES { get; set; }
    }
}
