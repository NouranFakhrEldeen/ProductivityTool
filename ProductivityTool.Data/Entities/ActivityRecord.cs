namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    
    public  class ActivityRecord
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime ActivityDate { get; set; }
        public int ActivityID { get; set; }

        public int? DemandID { get; set; }

        public int? ProjectID { get; set; }

        public int? Size { get; set; }

        public int? ActualEffort_Hours { get; set; }

        public string Comment { get; set; }

        public virtual Activity Activity { get; set; }

        public virtual Demand Demand { get; set; }

        public virtual Project Project { get; set; }
    }
}
