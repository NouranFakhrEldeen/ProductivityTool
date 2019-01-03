namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

  
    public  class Demand
    {

        [Key]  
        public int Id { get; set; }

        public string DemandType { get; set; }

        [Required]
        
        public string DemandNumber { get; set; }

        [Required]
        
        public string DemandName { get; set; }

        public virtual ICollection<ActivityRecord> ActivityRecords { get; set; }
    }
}
