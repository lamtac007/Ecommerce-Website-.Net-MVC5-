namespace Ecomercer_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int ID_Order { get; set; }

        public int? ID_User { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [Column("Price(vnđ)")]
        public double Price_vnđ_ { get; set; }

        public int? Amount { get; set; }

        [Column("TotalPrice(vnđ)")]
        public double? TotalPrice_vnđ_ { get; set; }

        public virtual User User { get; set; }
    }
}
