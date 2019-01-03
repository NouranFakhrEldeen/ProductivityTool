namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NTAccount { get; set; }
        [Required]
        public string GroupMail { get; set; }
        [Required]
        public string Name { get; set; }
        public bool? IsFunctionLeader { get; set; }
        public bool? IsTeamLeader { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Password { get; set; }
        [Flags]
        enum Roles { User = 1, FunctionLead = 2, TeamsLead = 4, Admin = 8 }
        public virtual ICollection<RoleProfile>  RoleProfiles { get; set; }
        //public virtual ICollection<UsersRolesProfile> UsersRolesProfiles { get; set; }
    }
}
