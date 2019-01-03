namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Activity
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int? SizingUnitID { get; set; }

        public int ActivityTypeId { get; set; }
        public virtual ActivityType ActivityType { get; set; }

        public virtual lkp_SizingUnit lkp_SizingUnit { get; set; }
        public virtual ICollection<ActivityRecord> ActivityRecords { get; set; }

    }
}
