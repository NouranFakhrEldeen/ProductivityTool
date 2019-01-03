namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class COE_TeamFunction
    {

        [Key]
        public int ID { get; set; }

        public int COETeamID { get; set; }

        [Required]
        public string FunctionName { get; set; }

        public virtual COE_Team COE_Team { get; set; }
        public virtual ICollection<RoleProfile> RoleProfiles { get; set; }
    }
}
