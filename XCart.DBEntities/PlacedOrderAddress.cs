
namespace XCart.DBEntities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PLACEDORDERADDRESS")]
    public class PLACEDORDERADDRESS
    {
       
        [Key]

        public int AddressId { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        [StringLength(100)]
        public string AddressLine { get; set; }

        public int? OrderNo { get; set; }

        public virtual ORDERPLACED ORDERPLACED { get; set; }
       
    }
}
