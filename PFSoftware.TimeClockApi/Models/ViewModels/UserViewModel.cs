using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PFSoftware.TimeClockApi.Models.ViewModels
{
    /// <summary>Represents someone who uses the Time Clock.</summary>
    public class UserViewModel
    {
        /// <summary><see cref="UserViewModel"/>'s ID.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary><see cref="UserViewModel"/>'s UserViewModelname.</summary>
        [Required]
        public string Username { get; set; }

        /// <summary><see cref="UserViewModel"/>'s first name.</summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary><see cref="UserViewModel"/>'s last name.</summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>List of roles a <see cref="UserViewModel"/> has available.</summary>
        public List<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();

        /// <summary><see cref="Shift"/>s worked by <see cref="UserViewModel"/>.</summary>
        public List<ShiftViewModel> Shifts { get; set; } = new List<ShiftViewModel>();

        /// <summary>Last name, first name</summary>
        public string Names => $"{LastName}, {FirstName}";
    }
}