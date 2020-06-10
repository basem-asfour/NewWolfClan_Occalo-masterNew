using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WolfClan.SoliHub.Models.ViewModels;

namespace WolfClan.SoliHub.API.Auth
{
    public class User
    { 
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Address { get; set; }
        public DateTime Birthday { get; set; }
        public int Gender { get; set; }
        public int Language { get; set; }
        public string Phone { get; set; }
        public byte[] ProfilePic { get; set; }
        public DateTime RegDate { get; set; }
        public string Share_Code { get; set; }

    }
}
