namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public  class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ProjectName { get; set; }


        public virtual ICollection<ActivityRecord> ActivityRecords { get; set; }
    }
}
