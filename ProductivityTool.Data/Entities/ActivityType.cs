namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class ActivityType
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
        [ForeignKey("ActivityCategory")]
        public int ActivityCategoryId { get; set; }
        public virtual ActivityCategory ActivityCategory { get; set; }
    }
}
