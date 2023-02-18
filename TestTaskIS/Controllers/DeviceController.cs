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
        /// <summary>
        /// Список всех устройств.
        /// </summary>
        /// <response code="401">Ошибка авторизации , пользователь с таким ID не найден или у пользователя нет прав доступа к данному методу.</response>
        [HttpGet("allDevices")]
        public JsonResult GetDevices([FromHeader] Guid userId) //ger device list from db
        {
            return new JsonResult(_con.Devices.ToList());
        }
        /// <summary>
        /// Создание нового устройства.
        /// </summary>
        /// <response code="401">Ошибка авторизации , пользователь с таким ID не найден или у пользователя нет прав доступа к данному методу.</response>
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
