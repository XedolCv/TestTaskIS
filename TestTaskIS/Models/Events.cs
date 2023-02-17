namespace TestTaskIS.Models
{
    public class Event
    {
        public Guid id { get; set; } //pk
        public Guid deviceid { get; set; } //fk
        public object value { get; set; } 

    }
}
