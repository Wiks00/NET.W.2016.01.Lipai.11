namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShawarmaRecipe")]
    public partial class ShawarmaRecipe
    {
        public int ShawarmaRecipeID { get; set; }

        public int Weght { get; set; }

        public int? IngradientID { get; set; }

        public int? ShawarmaID { get; set; }

        public virtual Ingradient Ingradient { get; set; }

        public virtual Shawarma Shawarma { get; set; }
    }
}
