namespace car01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationSet")]
    public partial class LocationSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LocationSet()
        {
            CarsSets = new HashSet<CarsSet>();
            Return_RecordsSet = new HashSet<Return_RecordsSet>();
        }

        [Key]
        public int Locatio_Id { get; set; }

        [Required]
        public string Location_Name { get; set; }

        [Required]
        public string Latitude { get; set; }

        [Required]
        public string Longtitude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarsSet> CarsSets { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Return_RecordsSet> Return_RecordsSet { get; set; }
    }
}
