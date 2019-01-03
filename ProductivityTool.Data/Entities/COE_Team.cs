namespace ProductivityTool.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public  class COE_Team
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string TeamName { get; set; }

        public virtual ICollection<COE_TeamFunction> COE_TeamFunction { get; set; }
    }
}
