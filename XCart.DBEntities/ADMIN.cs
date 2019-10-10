namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("ADMINS")]
    public class ADMINS
    {
        [Key]
        [StringLength(100)]
        public string AdminEmailId { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(1000)]
        public string Password { get; set; }
    }
}
