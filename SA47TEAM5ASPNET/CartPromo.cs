namespace SA47TEAM5ASPNET
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CartPromo")]
    public partial class CartPromo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CartPromo()
        {
            Invoice = new HashSet<Invoice>();
        }

        [Key]
        [StringLength(10)]
        public string PromoCode { get; set; }

        public short Discount { get; set; }

        [Column(TypeName = "date")]
        public DateTime ValidStart { get; set; }

        public int PromoDuration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
