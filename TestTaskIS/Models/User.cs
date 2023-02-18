using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using TestTaskIS.Services;
using System.Runtime.CompilerServices;

namespace TestTaskIS.Models
{
    public enum Permission
    {
        create = 0,
        read = 1,
        delete =2,
        update= 3
    }
    public enum Modules
    {
        User,
        Device,
        Event
    }
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        //public string acessToken { get; set; }
        public bool isValid { get; set; }
        public string permissionsString { get; set; }
        [NotMapped]
        private List<Permissions> perms
        {
            get
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Permissions>>(permissionsString);
            }
            set
            {
                permissionsString = JsonConvert.SerializeObject(value);
            }
        }
        public User() { }
        public User(string username,List<Permissions> permissions)
        {
            name = username;
            perms = permissions;
            id = Guid.NewGuid();
            isValid= true;
        }
        [NotMapped]
        public class Permissions 
        {
            public Modules module { get; set; }
            public List<Permission> permissions { get; set; }
        }
        public bool CheckPermissions(string controllerName, string methodType)
        {

            bool res = this.perms.FindIndex(t => t.module.ToString().ToLower() == controllerName.ToLower()) != -1 ? true : false;
            if ((methodType == "GET" && this.perms.FindIndex(item => item.module.ToString().ToLower() == controllerName.ToLower() && item.permissions.Contains(Permission.read))!= -1) 
             || (methodType == "POST" && this.perms.FindIndex(item => item.module.ToString().ToLower() == controllerName.ToLower() && item.permissions.Contains(Permission.create)) != -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
