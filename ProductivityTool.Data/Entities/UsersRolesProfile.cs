namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsersRolesProfile
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_UserRoleProfileID { get; set; }

        public int FK_UserID { get; set; }

        public int FK_RoleProfileID { get; set; }

        public bool IsPrimaryRoleProfile { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public virtual RoleProfile RoleProfile { get; set; }

        public virtual User User { get; set; }
    }
}
