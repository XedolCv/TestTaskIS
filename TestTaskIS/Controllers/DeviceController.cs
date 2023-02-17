using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskIS.Models;
using TestTaskIS.Services;

namespace TestTaskIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private MyContext _con;
        public DeviceController(MyContext con) { _con = con; }
        [HttpGet("allDevices")]
        public JsonResult GetDevices([FromHeader] Guid userId) //ger device list from db
        {
            return new JsonResult(_con.Devices.ToList());
        }
        [HttpPost("createDevice")]
        public JsonResult CreateDevice([FromHeader] Guid userId, string deviceName) //create new device
        {
            Device device = new Device(deviceName);
            _con.Devices.Add(device);
            _con.SaveChanges();
            return new JsonResult(device);
        }
    }
}
