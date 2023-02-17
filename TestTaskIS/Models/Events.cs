using System.ComponentModel.DataAnnotations.Schema;

namespace TestTaskIS.Models
{
    public class Event
    {
        public Guid id { get; set; } //pk
        public Guid deviceId { get; set; } //fk
        public Device device { get; set; }
        public string value { get; set; } 
    }
}
