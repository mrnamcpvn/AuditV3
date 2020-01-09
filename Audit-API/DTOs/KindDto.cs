using System;
using System.ComponentModel.DataAnnotations;

namespace Audit_API.DTOs
{
    public class KindDto
    {
        public int id { get; set; }
        
        [Required]
        public string name { get; set; }

        public string definition { get; set; }

        public bool active { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_time { get; set; }

        public KindDto()
        {
            this.active = true;
            this.updated_time = DateTime.Now;
        }
    }
}