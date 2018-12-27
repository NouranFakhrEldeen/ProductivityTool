namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RoleProfileActivityCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PK_RoleProfileActivityID { get; set; }

        public int? FK_RoleProfileID { get; set; }

        public int? FK_ActivityCategoryID { get; set; }

        public virtual ActivityCategory ActivityCategory { get; set; }

        public virtual RoleProfile RoleProfile { get; set; }
    }
}
