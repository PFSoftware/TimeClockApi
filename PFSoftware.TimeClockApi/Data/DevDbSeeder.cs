using PFSoftware.TimeClockApi.Constants;
using PFSoftware.TimeClockApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PFSoftware.TimeClockApi.Data
{
    public class DevDbSeeder
    {
        private AppDbContext _context;

        public DevDbSeeder()
        {
        }

        public async Task SeedDatabase(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            await SeedUsers();
        }

        private async Task SeedUsers()
        {
            _context.Users.AddRange(new List<User>
            {
                new User
                {
                    Id = 1,
                    Username = "Charlie",
                    FirstName = "Charlie",
                    LastName = "Brown",
                    Roles = new List<Role>
                    {
                        new Role
                        {
                            Id = 1,
                            Name = "Payroll Manager",
                            PayRate = 1250m,
                            PayPeriod = PayPeriod.Weekly,
                            PayType = PayType.Salary,
                            UserId = 1
                        }
                    },
                    Shifts = new List<Shift>
                    {
                        new Shift
                        {
                            StartTime = DateTimeOffset.Now.Subtract(new TimeSpan(32,0,0)),
                            EndTime = DateTimeOffset.Now.Subtract(new TimeSpan(24,0,0)),
                            UserId=1,
                            RoleId=1,
                        },
                        new Shift
                        {
                            StartTime = DateTimeOffset.Now.Subtract(new TimeSpan(8,0,0)),
                            EndTime = DateTimeOffset.Now,
                            UserId=1,
                            RoleId=1,
                        }
                    }
                },
                new User
                {
                    Id = 2,
                    Username = "Doug",
                    FirstName = "Douglas",
                    LastName = "Gaskell",
                    Roles = new List<Role>
                    {
                        new Role
                        {
                            Id = 2,
                            Name = "Software Develoer",
                            PayRate = 1250m,
                            PayPeriod = PayPeriod.Weekly,
                            PayType = PayType.Salary,
                            UserId = 2
                        }
                    },
                    Shifts = new List<Shift>
                    {
                        new Shift
                        {
                            StartTime = DateTimeOffset.Now.Subtract(new TimeSpan(32,0,0)),
                            EndTime = DateTimeOffset.Now.Subtract(new TimeSpan(24,0,0)),
                            UserId=2,
                            RoleId=2,
                        },
                        new Shift
                        {
                            StartTime = DateTimeOffset.Now.Subtract(new TimeSpan(8,0,0)),
                            EndTime = DateTimeOffset.Now,
                            UserId=2,
                            RoleId=2,
                        }
                    }
                }
            });
            await _context.SaveChangesAsync();
        }
    }
}