namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class COE_TeamFunction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public COE_TeamFunction()
        {
            RoleProfiles = new HashSet<RoleProfile>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_COETeamFunctionID { get; set; }

        public int FK_COETeamID { get; set; }

        [Required]
        [StringLength(100)]
        public string FunctionName { get; set; }

        public virtual COE_Team COE_Team { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleProfile> RoleProfiles { get; set; }
    }
}
