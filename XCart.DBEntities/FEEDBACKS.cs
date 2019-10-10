namespace XCart.DBEntities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    [Table("FEEDBACKS")]
    public class FEEDBACKS
    {
        [Key]
        public int FeedbackId { get; set; }

        public int ProductId { get; set; }

        public int? UserId { get; set; }

        public int? Rating { get; set; }

        [StringLength(550)]
        public string ReviewComment { get; set; }

        public virtual PRODUCTS PRODUCTS { get; set; }

        public virtual USERS USERS { get; set; }
    }
}
