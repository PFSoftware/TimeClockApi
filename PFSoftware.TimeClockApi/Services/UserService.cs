using Microsoft.EntityFrameworkCore;
using PFSoftware.TimeClockApi.Data;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFSoftware.TimeClockApi.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));

            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context
                .Users
                .Include(x => x.Roles)
                .Include(x => x.Shifts).ThenInclude(x => x.Role)
                .ToList();
        }

        public User GetUserById(int id)
        {
            return _context
                .Users
                .Include(x => x.Roles)
                .Include(x => x.Shifts).ThenInclude(x => x.Role)
                .FirstOrDefault(v => v.Id == id);
        }

        public void UpdateUser(CreateEditUserRequest request, User user)
        {
            if (!string.IsNullOrWhiteSpace(request.Username))
                user.Username = request.Username;
            if (!string.IsNullOrWhiteSpace(request.FirstName))
                user.FirstName = request.FirstName;
            if (!string.IsNullOrWhiteSpace(request.LastName))
                user.LastName = request.LastName;
            if (request.Roles != null && request.Roles.Count > 0)
                user.Roles = new List<Role>(request.Roles);
            if (request.Shifts != null && request.Shifts.Count > 0)
                user.Shifts = new List<Shift>(request.Shifts);
            _context.SaveChanges();
        }
    }
}