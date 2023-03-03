namespace Ecomercer_Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int ID_Fed { get; set; }

        public int? ID_User { get; set; }

        [Column(TypeName = "ntext")]
        public string FeedbackA { get; set; }

        public virtual User User { get; set; }
    }
}
