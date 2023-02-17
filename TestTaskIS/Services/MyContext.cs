using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using TestTaskIS.Models;

namespace TestTaskIS.Services
{
    public class MyContext :DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<User> Users { get; set; }
        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
    }
}
