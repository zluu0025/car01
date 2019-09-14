namespace car01.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order_Car_LineSet
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrdersOrder_Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CarsCar_Id { get; set; }

        [Required]
        public string Order_dates { get; set; }

        public virtual CarsSet CarsSet { get; set; }

        public virtual OrdersSet OrdersSet { get; set; }
    }
}
