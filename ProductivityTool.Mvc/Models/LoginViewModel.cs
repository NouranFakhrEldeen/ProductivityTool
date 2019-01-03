using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace ProductivityTool.Mvc.Models
{
    
        public class LoginViewModel
        {
            [Required]
            [Display(Name = "GroupMail")]
            [EmailAddress]
            public string GroupMail { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }


            public string ReturnUrl { get; set; }

        
      
    }
}