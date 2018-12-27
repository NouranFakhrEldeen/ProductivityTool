namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RoleProfile")]
    public partial class RoleProfile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoleProfile()
        {
            RoleProfileActivityCategories = new HashSet<RoleProfileActivityCategory>();
            UsersRolesProfiles = new HashSet<UsersRolesProfile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_RoleProfileID { get; set; }

        public int FK_COETeamFunctionID { get; set; }

        [StringLength(100)]
        public string ProfileName { get; set; }

        public virtual COE_TeamFunction COE_TeamFunction { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleProfileActivityCategory> RoleProfileActivityCategories { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersRolesProfile> UsersRolesProfiles { get; set; }
    }
}
