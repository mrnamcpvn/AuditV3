using System;

namespace Audit_API.DTOs
{
    public class CategoryDto
    {
        public CategoryDto()
        {
            this.active = true;
            this.updated_time = DateTime.Now;
        }
        public int id { get; set; }
        public int KindId { get; set; }
        public string KindName { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_time { get; set; }
        
    }
}