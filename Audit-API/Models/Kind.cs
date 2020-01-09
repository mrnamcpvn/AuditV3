using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Audit_API.Data;

namespace Audit_API.Models
{
    public class Kind
    {
        public Kind() 
        {

        }

        public Kind(int id, string name, string definition, bool active, string updated_by, DateTime? updated_time)
        {
            this.id = id;
            this.name = name;
            this.definition = definition;
            this.active = active;
            this.updated_by = updated_by;
            this.updated_time = updated_time;
        }
        
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public string definition { get; set; }
        public bool active { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_time { get; set; }

        
    }
}