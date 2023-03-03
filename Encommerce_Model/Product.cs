namespace Encommerce_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Orders = new HashSet<Order>();
        }

        public int ID_Category { get; set; }

        [Key]
        public int ID_Product { get; set; }

        [StringLength(50, MinimumLength =2, ErrorMessage ="The string lenth of ProductName must to 2 -> 50")]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        
        [StringLength(20)]
        public string Origin { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DataType(DataType.Currency)]
        public double? PriceF { get; set; }

        
        [StringLength(10)]
        public string Unit { get; set; }

        [DataType(DataType.Currency)]
        public double? Sale { get; set; }

        [Display(Name = "Date Manafacture")]
        [DataType(DataType.Date)]
        public DateTime? DateManufacture { get; set; }

        [Display(Name = "Expiration Date")]
        [DataType(DataType.Date)]
        public DateTime? ExpirationDate { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string DescriptionDTS { get; set; }

        [Display(Name = "Date Update")]
        [DataType(DataType.Date)]
        public DateTime? Update { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
