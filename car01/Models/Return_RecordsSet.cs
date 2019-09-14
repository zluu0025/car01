namespace car01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Return_RecordsSet
    {
        [Key]
        [Column(Order = 0)]
        public string Actual_Return_Date { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrdersOrder_Id { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Return_Location_Id { get; set; }

        public virtual LocationSet LocationSet { get; set; }

        public virtual OrdersSet OrdersSet { get; set; }
    }
}
