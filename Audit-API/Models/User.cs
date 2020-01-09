using System;

namespace Audit_API.Models
{
    public class User
    {
        public int id { get; set; }
        public string account { get; set; }
        public string password { get; set; }
        public byte[] password_hash { get; set; }
        public byte[] password_salt { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string created_by { get; set; }
        public DateTime created_time { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_time { get; set; }
        public bool? active { get; set; }
    }
}