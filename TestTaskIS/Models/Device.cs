using System.ComponentModel.DataAnnotations;
using TestTaskIS.Services;

namespace TestTaskIS.Models
{
    public class Device
    {
        public  Guid id { get; set; } 
        public  string name { get; set; }

        public Device() { }
        public Device(string deviceName)
        {
            name = deviceName;
            id = Guid.NewGuid();
        }
        public Device(string deviceName, Guid deviceId)
        {
            name = deviceName;
            id = deviceId;
        }
        public bool IsExist(MyContext con ,Guid deviceId) 
        {
            return con.Devices.Any(d => d.id == deviceId);
        }
    }
}
