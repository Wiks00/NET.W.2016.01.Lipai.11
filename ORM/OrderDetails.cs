namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Quantity { get; set; }

        public int? OrderHeaderID { get; set; }

        public int? ShawarmaID { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }

        public virtual Shawarma Shawarma { get; set; }
    }
}
