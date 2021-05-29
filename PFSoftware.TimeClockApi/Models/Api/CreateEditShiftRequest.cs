using System;

namespace PFSoftware.TimeClockApi.Models.Api
{
    public class CreateEditShiftRequest
    {
        public int? Id { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}