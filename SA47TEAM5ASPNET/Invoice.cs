namespace SA47TEAM5ASPNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetails>();
        }

        [StringLength(10)]
        public string InvoiceID { get; set; }

        [Column(TypeName = "date")]
        public DateTime InvoiceDate { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerID { get; set; }

        [Required]
        [StringLength(10)]
        public string PromoCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PromoAmt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal InvoiceAmt { get; set; }

        [Required]
        [StringLength(6)]
        public string PaymentStatus { get; set; }

        public virtual CartPromo CartPromo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<InvoiceDetails> InvoiceDetails { get; set; }
    }
}
