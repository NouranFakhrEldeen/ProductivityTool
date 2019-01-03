namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public class RoleProfile
    {
        [Key]
        public int Id { get; set; }
        public string ProfileName { get; set; }
        public int COETeamFunctionID { get; set; }
        public virtual COE_TeamFunction COE_TeamFunction { get; set; }
        //public virtual ICollection<RoleProfileActivityCategory> RoleProfileActivityCategories { get; set; }
        public virtual ICollection<ActivityCategory> ActivityCategories { get; set; }
        public virtual ICollection<User> Users { get; set; }

    }
}
