using System;

namespace Audit_API.Models
{
    public class Category
    {
        public Category()
        {

        }

        public Category(int id, string name, bool active, string updated_by, DateTime? updated_time, int KindId, Kind kind)
        {
            this.id = id;
            this.name = name;
            this.active = active;
            this.updated_by = updated_by;
            this.updated_time = updated_time;
            this.KindId = KindId;
            this.Kind = kind;
        }
        public int id { get; set; }
        public string name { get; set; }
        public bool active { get; set; }
        public string updated_by { get; set; }
        public DateTime? updated_time { get; set; }
        public Kind Kind { get; set; }
        public int KindId { get; set; }


        
    }
}