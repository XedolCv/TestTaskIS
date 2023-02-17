using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using TestTaskIS.Models;

namespace TestTaskIS.Services
{
    public class AppContext :DbContext
    {
        public DbSet<Device> Devices { get; set; }
        public DbSet<Event> Events { get; set; }
        public AppContext(DbContextOptions<AppContext> options) : base(options) { Database.EnsureCreated(); }
    }
}
