using PFSoftware.TimeClockApi.Models.Domain;

namespace PFSoftware.TimeClockApi.Constants
{
    /// <summary>Represents how frequently a <see cref="Role"/> is paid.</summary>
    public enum PayPeriod
    {
        None,
        Weekly,
        BiWeekly,
        SemiMonthly,
        Monthly
    }
}