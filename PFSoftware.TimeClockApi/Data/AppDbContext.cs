using Microsoft.EntityFrameworkCore;
using PFSoftware.TimeClockApi.Models.Domain;

namespace PFSoftware.TimeClockApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Shift> Shifts { get; set; }

        public DbSet<User> Users { get; set; }
    }
}