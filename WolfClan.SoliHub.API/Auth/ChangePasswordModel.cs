using DataAnnotationsExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WolfClan.SoliHub.API.Auth
{
    public class ChangePasswordModel
    {
        [Email]
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string OldPassword { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
        [Required]
        [MinLength(6)]
        public string ConfirmNewPassword { get; set; }
    }
}
