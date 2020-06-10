using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WolfClan.SoliHub.Models.ViewModels
{
    public class BaseVM
    {
        [Key]
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public long AdminUserId { get; set; }
    }
}
