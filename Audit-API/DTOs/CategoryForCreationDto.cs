using System;
using System.ComponentModel.DataAnnotations;

namespace Audit_API.DTOs
{
    public class CategoryForCreationDto
    {
        [Required]
        public string name { get; set; }

        public int KindId { get; set; }

        public bool active { get; set; }
        public string updated_by { get; set; }
        public DateTime updated_time { get; set; }

        public CategoryForCreationDto()
        {
            this.active = true;
            this.updated_time = DateTime.Now;
        }
    }
}