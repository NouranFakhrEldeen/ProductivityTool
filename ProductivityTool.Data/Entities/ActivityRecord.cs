namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ActivityRecord")]
    public partial class ActivityRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_ActivityRecordID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ActivityDate { get; set; }

        public int FK_ActivityID { get; set; }

        public int? FK_DemandID { get; set; }

        public int? FK_ProjectID { get; set; }

        public int? Size { get; set; }

        public int? ActualEffort_Hours { get; set; }

        public string Comment { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Demand Demand { get; set; }

        public virtual Project Project { get; set; }
    }
}
