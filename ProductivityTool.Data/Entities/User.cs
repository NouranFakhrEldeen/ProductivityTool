namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            UsersRolesProfiles = new HashSet<UsersRolesProfile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_UserID { get; set; }

        [StringLength(32)]
        public string AspnetUserID { get; set; }

        [Required]
        [StringLength(50)]
        public string NTAccount { get; set; }

        [Required]
        [StringLength(100)]
        public string GroupMail { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int FK_COETeamFunctionID { get; set; }

        public int? FK_COETeamID { get; set; }

        public bool? IsFunctionLeader { get; set; }

        public bool? IsTeamLeader { get; set; }

        [StringLength(100)]
        public string ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersRolesProfile> UsersRolesProfiles { get; set; }
    }
}
