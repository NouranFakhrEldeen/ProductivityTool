namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class lkp_SizingUnit
    {

        [Key]
        public int PK_SizingUnitID { get; set; }
        [Required]
        public string SizingUnit { get; set; }
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
