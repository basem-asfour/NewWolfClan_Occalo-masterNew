using System;
using System.ComponentModel.DataAnnotations;

namespace WolfClan.SoliHub.Models.ViewModels
{
	public class ContentPageVM : BaseVM
	{
		public int Id { get; set; }


        [Required]
        [Display(ResourceType = typeof(RM.Resources), Name = "TitleEN")]
        public string TitleEN { get; set; }

        [Required]
        public string TitleAR { get; set; }

	

		[Required]
		public string ContentEN { get; set; }

		[Required]
		public string ContentAR { get; set; }

		public bool IsActive { get; set; }

	}
}
