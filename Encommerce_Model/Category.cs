namespace Encommerce_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category : IValidatableObject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int ID_Category { get; set; }

        [StringLength(50, MinimumLength =2, ErrorMessage ="The string length of CategoryName must be 2 -> 50")]
        public string CategoryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }

        public IEnumerable<ValidationResult>Validate(ValidationContext validationContext)
        {
            if (CategoryName != null && CategoryName.Split(' ').Length > 1 && CategoryName.Split(' ').Length <51)
                yield return new ValidationResult("This Category Name has to exits!",
                    new[] { "CategoryName" });
        }
    }
}
