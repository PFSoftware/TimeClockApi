using PFSoftware.TimeClockApi.Constants;
using System;
using System.ComponentModel.DataAnnotations;

namespace PFSoftware.TimeClockApi.Models.Domain
{
    public class Role
    {
        /// <summary>ID of the <see cref="Role"/>.</summary>
        [Key]
        public int Id { get; set; }

        /// <summary>Name of the <see cref="Role"/>.</summary>
        [Required]
        public string Name { get; set; }

        /// <summary>Rate of pay for the <see cref="Role"/>.</summary>
        [Required]
        public decimal PayRate { get; set; }

        /// <summary>The type of pay the <see cref="Role"/> has, hourly or salary.</summary>
        [Required]
        public PayType PayType { get; set; }

        /// <summary>The frequency at which the <see cref="Role"/> is paid.</summary>
        [Required]
        public PayPeriod PayPeriod { get; set; }

        /// <summary>ID of the user associated with this <see cref="Role"/>.</summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>User associated with this <see cref="Role"/>.</summary>
        public User User { get; set; }

        private static bool Equals(Role left, Role right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return left.Id == right.Id
                && string.Equals(left.Name, right.Name, StringComparison.OrdinalIgnoreCase)
                && left.PayRate == right.PayRate
                && left.PayType == right.PayType
                && left.PayPeriod == right.PayPeriod
                && left.UserId == right.UserId;
        }

        public override bool Equals(object obj) => Equals(this, obj as Role);

        public bool Equals(Role otherRole) => Equals(this, otherRole);

        public static bool operator ==(Role left, Role right) => Equals(left, right);

        public static bool operator !=(Role left, Role right) => !Equals(left, right);

        public override int GetHashCode() => base.GetHashCode() ^ 17;

        public override string ToString() => $"{Id}: {Name}";
    }
}