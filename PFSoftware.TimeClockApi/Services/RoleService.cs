using Microsoft.EntityFrameworkCore;
using PFSoftware.TimeClockApi.Constants;
using PFSoftware.TimeClockApi.Data;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFSoftware.TimeClockApi.Services
{
    public class RoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));

            _context.Roles.Remove(role);
            _context.SaveChanges();
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context
                .Roles
                .Include(x => x.User)
                .ToList();
        }

        public Role GetRoleById(int id)
        {
            return _context
                .Roles
                .Include(x => x.User)
                .FirstOrDefault(v => v.Id == id);
        }

        public void UpdateRole(CreateEditRoleRequest request, Role role)
        {
            if (!string.IsNullOrWhiteSpace(request.Name))
                role.Name = request.Name;
            if (request.PayRate != 0m)
                role.PayRate = request.PayRate;
            if (request.PayPeriod != PayPeriod.None)
                role.PayPeriod = request.PayPeriod;
            if (request.PayType != PayType.None)
                role.PayType = request.PayType;
            if (request.UserId != 0)
                role.UserId = request.UserId;
            _context.SaveChanges();
        }
    }
}