namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PriceController")]
    public partial class PriceController
    {
        public int PriceControllerID { get; set; }

        public int Price { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public int? ShawarmaID { get; set; }

        public int? SellingPointID { get; set; }

        public virtual SellingPoint SellingPoint { get; set; }

        public virtual Shawarma Shawarma { get; set; }
    }
}
