using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestTaskIS.Models;
using TestTaskIS.Services;

namespace TestTaskIS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private MyContext _con;
        public UserController(MyContext con) { _con = con; } 
        // GET: UserController

        // POST: UserController/Create
        [HttpPost]
        public JsonResult Create(string userName,List<Permissions> permissions) //create new user
        {
            User user = new User(userName, permissions);
            _con.Users.Add(user);
            _con.SaveChanges();
            return new JsonResult(user.id);
        }
        [HttpGet]
        public JsonResult GetUsers([FromHeader] Guid userId)
        {
            return new JsonResult(_con.Users.ToList());
        }
    }
}
