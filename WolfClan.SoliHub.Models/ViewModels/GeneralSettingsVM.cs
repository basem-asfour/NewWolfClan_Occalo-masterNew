using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WolfClan.SoliHub.Models.ViewModels
{
    public class GeneralSettingsVM : BaseVM
    {
        [Required,StringLength(100,ErrorMessage ="your Title can contains only 100 character")]
        public string TitleEN { get; set; }
        [Required, MaxLength(100, ErrorMessage = "العنوان يجب الا يزيد عن 100 حرف")]
        public string TitleAR { get; set; }
        [Required, MaxLength(1000, ErrorMessage = "your Welcome words can contains only 1000 character")]
        public string WelWordsEN { get; set; }
        [Required, MaxLength(1000, ErrorMessage = "نص الترحيب يجب الا يزيد عن 1000 حرف")]
        public string WelWordsAR { get; set; }
        [Required, MaxLength(1000, ErrorMessage = "MetaDesc can contains only 1000 character")]
        public string MetaDesc { get; set; }
        [Required, MaxLength(1000, ErrorMessage = "MetaKW can contains only 1000 character")]
        public string MetaKW { get; set; }
        [MaxLength(1000, ErrorMessage = "Facebook can contains only 1000 character")]
        public string Facebook { get; set; }
        [MaxLength(1000, ErrorMessage = "Twitter can contains only 1000 character")]
        public string Twitter { get; set; }
        [MaxLength(1000, ErrorMessage = "Instagram can contains only 1000 character")]
        public string Instagram { get; set; }
        [MaxLength(1000, ErrorMessage = "Youtube can contains only 1000 character")]
        public string Youtube { get; set; }
        [MaxLength(1000, ErrorMessage = "Linkedin can contains only 1000 character")]
        public string Linkedin { get; set; }
        [MaxLength(1000, ErrorMessage = "AppStore can contains only 1000 character")]
        public string AppStore { get; set; }
        [MaxLength(1000, ErrorMessage = "GooglePlay can contains only 1000 character")]
        public string GooglePlay { get; set; }
        [MaxLength(500, ErrorMessage = "Address can contains only 1000 character")]
        public string Address { get; set; }
        [MaxLength(50, ErrorMessage = "Email can contains only 1000 character")]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "Phone can contains only 1000 character")]
        public string Phone { get; set; }
        [MaxLength(50, ErrorMessage = "Fax can contains only 1000 character")]
        public string Fax { get; set; }
        public int DefaultCountryId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int PageSize { get; set; }
        public int PageSizeMob { get; set; }
        public bool AutoActiveUser { get; set; }
        public bool AutoActiveArticle { get; set; }
    }
}
