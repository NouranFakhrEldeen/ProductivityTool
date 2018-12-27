namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Demand")]
    public partial class Demand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Demand()
        {
            ActivityRecords = new HashSet<ActivityRecord>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_DemandID { get; set; }

        [StringLength(100)]
        public string DemandType { get; set; }

        [Required]
        [StringLength(100)]
        public string DemandNumber { get; set; }

        [Required]
        [StringLength(100)]
        public string DemandName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityRecord> ActivityRecords { get; set; }
    }
}
