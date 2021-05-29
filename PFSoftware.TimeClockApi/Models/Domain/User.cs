using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PFSoftware.TimeClockApi.Models.Domain
{
    /// <summary>Represents someone who uses the Time Clock.</summary>
    public class User
    {
        /// <summary><see cref="User"/>'s ID.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary><see cref="User"/>'s username.</summary>
        [Required]
        public string Username { get; set; }

        /// <summary><see cref="User"/>'s first name.</summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary><see cref="User"/>'s last name.</summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>List of roles a <see cref="User"/> has available.</summary>
        public List<Role> Roles { get; set; } = new List<Role>();

        /// <summary><see cref="Shift"/>s worked by <see cref="User"/>.</summary>
        public List<Shift> Shifts { get; set; } = new List<Shift>();

        private static bool Equals(User left, User right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return left.Id == right.Id
                && string.Equals(left.Username, right.Username, StringComparison.OrdinalIgnoreCase)
                && string.Equals(left.FirstName, right.FirstName, StringComparison.OrdinalIgnoreCase)
                && string.Equals(left.LastName, right.LastName, StringComparison.OrdinalIgnoreCase)
                && !left.Roles.Except(right.Roles).Any()
                && !right.Roles.Except(left.Roles).Any()
                && !left.Shifts.Except(right.Shifts).Any()
                && !right.Shifts.Except(left.Shifts).Any();
        }

        public override bool Equals(object obj) => Equals(this, obj as User);

        public bool Equals(User otherUser) => Equals(this, otherUser);

        public static bool operator ==(User left, User right) => Equals(left, right);

        public static bool operator !=(User left, User right) => !Equals(left, right);

        public override int GetHashCode() => base.GetHashCode() ^ 17;

        public override string ToString() => $"{Id} - {LastName}, {FirstName}";
    }
}