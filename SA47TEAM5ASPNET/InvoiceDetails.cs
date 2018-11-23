namespace SA47TEAM5ASPNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class InvoiceDetails
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string InvoiceID { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookID { get; set; }

        public int Unit { get; set; }

        [Column(TypeName = "numeric")]
        public decimal UnitPrice { get; set; }

        [Column(TypeName = "numeric")]
        public decimal DiscountAmt { get; set; }

        public virtual Book Book { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}
