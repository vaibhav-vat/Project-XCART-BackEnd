namespace XCart.DBEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
     

    public  class PRODUCTDESCRIPTION
    {
        [Key]
        public int DescriptionId { get; set; }

        public int? ProductId { get; set; }

        [StringLength(50)]
        public string ProductSubCategory1 { get; set; }

        [StringLength(10)]
        public string ProductGenderType { get; set; }

        [StringLength(50)]
        public string ProductBrand { get; set; }

        [StringLength(50)]
        public string ProductSubCategory2 { get; set; }

        [StringLength(2000)]
        public string ProductDescription { get; set; }

        public virtual PRODUCTS PRODUCTS { get; set; }
    }
}
