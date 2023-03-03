namespace Encommerce_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        EncommerceDBContext db = new EncommerceDBContext();
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            Feedbacks = new HashSet<Feedback>();
            Orders = new HashSet<Order>();
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int ID_User { get; set; }
        [Required(ErrorMessage = "The UserName must not null!")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "The Password must not null!")]
        
        [StringLength(20)]
        public string Password { get; set; }
        public string Image { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Input value for Email please!")]
        [StringLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        public int? PhoneNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if(Password != null && Password.Split(' ').Length < 8)
        //    {
        //        yield return new ValidationResult("The Password has to more than 7 charactor!", new[] { "Password" });
        //    }
        //}
    }
}
