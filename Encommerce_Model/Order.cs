namespace Encommerce_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Order")]
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int ID_Order { get; set; }

        public int ID_User { get; set; }

        public int ID_Product { get; set; }

        [StringLength(50)]
        public string ProductName { get; set; }

        [StringLength(10)]
        public string Unit { get; set; }

        [StringLength(200)]
        public string Image { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        public string PaymentMethod { get; set; }

        public double Price { get; set; }

        public int? Amount { get; set; }

        public double? TotalPrice { get; set; }

        [Column(TypeName = "DateTime2")]
        [Display(Name ="OrderDate")]
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }

    public class Cart
    {
        List<Order> items = new List<Order>();
        public IEnumerable<Order> Items
        {
            get { return items; }
        }
        public void Add(Product product,  int amount=1)
        {
            var item = items.FirstOrDefault(s => s.Product.ID_Product == product.ID_Product);
            if (item == null)
            {
                items.Add(new Order
                {
                    Product = product,
                    Amount = amount
                });
            }
            else
            {
                item.Amount += amount;
            }
        }
    }
}
