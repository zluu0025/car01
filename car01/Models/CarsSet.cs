namespace car01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CarsSet")]
    public partial class CarsSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarsSet()
        {
            Order_Car_LineSet = new HashSet<Order_Car_LineSet>();
        }

        [Key]
        public int Car_Id { get; set; }

        [Required]
        public string Car_Type { get; set; }

        [Required]
        public string Car_MarK { get; set; }

        [Required]
        public string Car_Vin { get; set; }

        [Required]
        public string Car_Price { get; set; }

        [Required]
        public string Car_License_Plate { get; set; }

        public int LocationLocatio_Id1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Car_LineSet> Order_Car_LineSet { get; set; }

        public virtual LocationSet LocationSet { get; set; }
    }
}
