namespace SA47TEAM5ASPNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CategoryDiscount")]
    public partial class CategoryDiscount
    {
        [Key]
        [StringLength(10)]
        public string DiscountID { get; set; }

        public short DiscountAmt { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidStart { get; set; }

        public int DiscountDuration { get; set; }

        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
    }
}
