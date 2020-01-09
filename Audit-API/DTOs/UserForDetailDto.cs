using System;

namespace Audit_API.DTOs
{
    public class UserForDetailDto
    {
        public int id { get; set; }
        public string account { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string created_by { get; set; }
        public DateTime created_time { get; set; }
        public string updated_by { get; set; }
        public DateTime updated_time { get; set; }
        public bool active { get; set; }
    }
}