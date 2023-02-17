using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskIS.Models;
using TestTaskIS.Services;

namespace TestTaskIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private MyContext _con;
        public EventController(MyContext con) { _con = con; }
        [HttpGet("allEvents")]
        public JsonResult GetAllEvents([FromHeader] Guid userId) //ger device list from db
        {
            return new JsonResult(_con.Events.ToList());
        }
        [HttpGet("eventsForDevice")]
        public JsonResult GetEvents([FromHeader] Guid userId,Guid deviceId) //ger device list from db
        {
            return new JsonResult(_con.Events.Where(e => e.deviceId == deviceId));
        }
        [HttpPost("createEvent")]
        public JsonResult CreateEvent([FromHeader] Guid userId, Guid deviceId,Content eventContent) //create new device
        {
            if (_con.Devices.Any(d => d.id == deviceId))
            {
                Event eventt = new Event(deviceId,eventContent);
                _con.Events.Add(eventt);
                _con.SaveChanges();
                return new JsonResult(eventt);
            }
            else
            {
                Response.StatusCode = 400;
                return new JsonResult("Отсутсвует Device для создания ему Event'a.");
            }
        }
    }
}
