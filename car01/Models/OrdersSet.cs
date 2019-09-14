namespace car01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrdersSet")]
    public partial class OrdersSet
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdersSet()
        {
            Order_Car_LineSet = new HashSet<Order_Car_LineSet>();
            Return_RecordsSet = new HashSet<Return_RecordsSet>();
        }

        [Key]
        public int Order_Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string Renting_Start_Date { get; set; }

        [Required]
        public string Renting_End_Date { get; set; }

        [Required]
        public string Total_Renting_Fee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Car_LineSet> Order_Car_LineSet { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Return_RecordsSet> Return_RecordsSet { get; set; }
    }
}
