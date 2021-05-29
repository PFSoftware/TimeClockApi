using PFSoftware.TimeClockApi.Models.Domain;
using System.Collections.Generic;

namespace PFSoftware.TimeClockApi.Models.Api
{
    public class CreateEditUserRequest
    {
        public int? Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Shift> Shifts { get; set; } = new List<Shift>();
    }
}