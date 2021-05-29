using PFSoftware.TimeClockApi.Constants;
using System.ComponentModel.DataAnnotations;

namespace PFSoftware.TimeClockApi.Models.ViewModels
{
    public class RoleViewModel
    {
        /// <summary>ID of the <see cref="RoleViewModel"/>.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Name of the <see cref="RoleViewModel"/>.</summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Rate of pay for the <see cref="RoleViewModel"/>.</summary>
        [Required]
        public decimal PayRate { get; set; }

        /// <summary>The type of pay the <see cref="RoleViewModel"/> has, hourly or salary.</summary>
        [Required]
        public PayType PayType { get; set; }

        /// <summary>The frequency at which the <see cref="RoleViewModel"/> is paid.</summary>
        [Required]
        public PayPeriod PayPeriod { get; set; }

        /// <summary>ID of the user associated with this <see cref="RoleViewModel"/>.</summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>User associated with this <see cref="RoleViewModel"/>.</summary>
        public UserViewModel User { get; set; }

        /// <summary>Rate of pay for the <see cref="Role"/>, formatted.</summary>
        public string PayRateToString => PayRate.ToString("C2");
    }
}