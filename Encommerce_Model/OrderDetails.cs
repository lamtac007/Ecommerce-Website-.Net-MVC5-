namespace Encommerce_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID_OrderDetails { get; set; }

        [StringLength(20)]
        public string OrderDetailsName { get; set; }

        public int ID_User { get; set; }

        public int ID_Order { get; set; }

        public double? TotalPrice { get; set; }

        [StringLength(50)]
        public string Status_ { get; set; }

        [Display(Name = "OrdertedDate")]
        [DataType(DataType.Date)]
        public DateTime? ODate { get; set; }

        public virtual Order Order { get; set; }

        public virtual User User { get; set; }
    }
}
