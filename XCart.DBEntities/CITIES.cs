namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("CITIES")]
    public class CITIES
    {
        [Key]
        public int CityId { get; set; }

        public int? StateId { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        public virtual STATES STATES { get; set; }
    }
}
