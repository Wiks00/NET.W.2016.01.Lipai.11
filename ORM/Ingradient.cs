namespace ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ingradient")]
    public partial class Ingradient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ingradient()
        {
            ShawarmaRecipe = new HashSet<ShawarmaRecipe>();
        }

        public int IngradientID { get; set; }

        [Required]
        [StringLength(50)]
        public string IngradientName { get; set; }

        public int TotalWeght { get; set; }

        public int? CategoryID { get; set; }

        public virtual IngradientCategory IngradientCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShawarmaRecipe> ShawarmaRecipe { get; set; }
    }
}
