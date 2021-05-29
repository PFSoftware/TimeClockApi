using Microsoft.EntityFrameworkCore;
using PFSoftware.TimeClockApi.Data;
using PFSoftware.TimeClockApi.Models.Api;
using PFSoftware.TimeClockApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PFSoftware.TimeClockApi.Services
{
    public class ShiftService
    {
        private readonly AppDbContext _context;

        public ShiftService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateShift(Shift shift)
        {
            if (shift == null)
                throw new ArgumentNullException(nameof(shift));

            _context.Shifts.Add(shift);
            _context.SaveChanges();
        }

        public void DeleteShift(Shift shift)
        {
            if (shift == null)
                throw new ArgumentNullException(nameof(shift));

            _context.Shifts.Remove(shift);
            _context.SaveChanges();
        }

        public IEnumerable<Shift> GetAllShifts()
        {
            return _context
                .Shifts
                .Include(x => x.Role)
                .Include(x => x.User).ThenInclude(x => x.Roles)
                .Include(x => x.User).ThenInclude(x => x.Shifts)
                .ToList();
        }

        public Shift GetShiftById(int id)
        {
            return _context
                .Shifts
                .Include(x => x.Role)
                .Include(x => x.User).ThenInclude(x => x.Roles)
                .Include(x => x.User).ThenInclude(x => x.Shifts)
                .FirstOrDefault(v => v.Id == id);
        }

        public void UpdateShift(CreateEditShiftRequest request, Shift shift)
        {
            //TODO I hate time zones.
            if (request.StartTime != DateTime.MinValue)
                shift.StartTime = request.StartTime;
            if (request.EndTime != DateTime.MinValue)
                shift.EndTime = request.EndTime;
            if (request.RoleId != 0)
                shift.RoleId = request.RoleId;
            if (request.UserId != 0)
                shift.UserId = request.UserId;
            _context.SaveChanges();
        }
    }
}