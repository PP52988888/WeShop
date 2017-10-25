namespace WeShop.EFModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProReview")]
    public partial class ProReview
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProReview()
        {
            RevPhotoes = new HashSet<RevPhoto>();
        }

        public int Id { get; set; }

        [StringLength(11)]
        public string ProCode { get; set; }

        public int? CusId { get; set; }

        [Column(TypeName = "text")]
        public string Body { get; set; }

        public byte? State { get; set; }

        public byte? Rate { get; set; }

        public DateTime? CreateTime { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RevPhoto> RevPhotoes { get; set; }
    }
}
