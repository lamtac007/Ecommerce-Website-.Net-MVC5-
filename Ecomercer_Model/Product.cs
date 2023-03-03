namespace Ecomercer_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        public int? ID_Category { get; set; }

        [Key]
        public int ID_Product { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(20)]
        public string Origin { get; set; }

        [Column("Price(vnđ)")]
        public double Price_vnđ_ { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [Column("Sale(%)")]
        public double? Sale___ { get; set; }

        public DateTime? DateManufacture { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string DescriptionDTS { get; set; }

        public virtual Category Category { get; set; }
    }
}
