using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TestTaskIS.Models;
using TestTaskIS.Services;
using static TestTaskIS.Models.User;

namespace TestTaskIS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private MyContext _con;
        public UserController(MyContext con) { _con = con; }
        /// <summary>
        /// Создание нового пользователя.
        /// </summary>
        [HttpPost]
        public JsonResult Create(string userName, List<Permissions> permissions) //create new user
        {
            User user = new User(userName, permissions);
            _con.Users.Add(user);
            _con.SaveChanges();
            return new JsonResult(user.id);
        }
        /// <summary>
        /// Список всех пользователей.
        /// </summary>
        [HttpGet]
        public JsonResult GetUsers() //ger user list from db
        {
            try
            {
                List<User> user = _con.Users.ToList();
                return new JsonResult(user);
            }
            catch (Exception ex) {return new JsonResult(ex.Message); }
  
        }
    }
}
