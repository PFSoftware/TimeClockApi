using PFSoftware.TimeClockApi.Constants;

namespace PFSoftware.TimeClockApi.Models.Api
{
    public class CreateEditRoleRequest
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal PayRate { get; set; }
        public PayType PayType { get; set; }
        public PayPeriod PayPeriod { get; set; }
        public int UserId { get; set; }
    }
}