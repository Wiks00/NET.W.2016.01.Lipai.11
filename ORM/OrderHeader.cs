namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderHeader")]
    public partial class OrderHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderHeader()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public int OrderHeaderID { get; set; }

        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }

        public int? SellerID { get; set; }

        public int? ShawarmaID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Seller Seller { get; set; }

        public virtual Shawarma Shawarma { get; set; }
    }
}
