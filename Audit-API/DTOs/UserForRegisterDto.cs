using System;
using System.ComponentModel.DataAnnotations;

namespace Audit_API.DTOs
{
    public class UserForRegisterDto
    {
        [Required]
        public string account { get; set; }

        [Required]
        [StringLength(16, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 16 characters")]
        public string password { get; set; }
        
        public string email { get; set; }
        public string fullname { get; set; }
        public string created_by { get; set; }
        public DateTime created_time { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_time { get; set; }
        public bool? active { get; set; }

        public UserForRegisterDto()
        {
            created_time = DateTime.Now;
            active = true;
        }
    }
}