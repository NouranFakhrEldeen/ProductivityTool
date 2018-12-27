namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            ActivityRecords = new HashSet<ActivityRecord>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_ActivityID { get; set; }

        public int? FK_ActivityTypeID { get; set; }

        [Column("Activity")]
        [StringLength(100)]
        public string Activity1 { get; set; }

        public int? FK_SizingUnitID { get; set; }

        public virtual ActivityType ActivityType { get; set; }

        public virtual lkp_SizingUnit lkp_SizingUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityRecord> ActivityRecords { get; set; }
    }
}
