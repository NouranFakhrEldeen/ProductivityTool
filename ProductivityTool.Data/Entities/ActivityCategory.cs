namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    
    public  class ActivityCategory
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ActivityType> ActivityTypes { get; set; }

        public virtual ICollection<RoleProfile> RoleProfiles { get; set; }
    }
}
