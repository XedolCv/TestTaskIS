using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Nodes;

namespace TestTaskIS.Models
{
    public class Event
    {
        
        public Guid id { get; set; } //pk
        public Guid deviceId { get; set; } //fk
        [JsonIgnore]
        public Device device { get; set; } 
        public string valueSrting { get; set; }
        [NotMapped]
        private Content value
        {
            get
            {
              return value;
            }
            set
            {
                valueSrting = JsonConvert.SerializeObject(value);
            }
        }
        public Event() { }
        public Event(Guid devId,Content content)
        {
            deviceId = devId;
            value = content;
        }
    }
    [NotMapped]
    public class Content
    {
        public int intValue { get; set; }
        public float floatValue { get; set; }
        public string stringValue { get; set; }
    }
}
