using TestTaskIS.Services;

namespace TestTaskIS.Models
{
    public enum Permissions
    {
        create = 0,
        read = 1,
        delete =2,
        update= 3
    }
    public class User
    {
        public Guid id { get; set; }
        public string name { get; set; }
        //public string acessToken { get; set; }
        public bool isValid { get; set; }
        public List<Permissions> perms { get; set; }
        public User() { }
        public User(string username,List<Permissions> permissions)
        {
            name = username;
            perms = permissions;
            id = Guid.NewGuid();
            isValid= true;
        }
    }
    
}
