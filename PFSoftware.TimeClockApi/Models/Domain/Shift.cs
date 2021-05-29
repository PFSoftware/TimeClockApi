using System;
using System.ComponentModel.DataAnnotations;

namespace PFSoftware.TimeClockApi.Models.Domain
{
    /// <summary>Represents a <see cref="Shift"/> that was started or worked.</summary>
    public class Shift
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset StartTime { get; set; }

        [Required]
        public DateTimeOffset EndTime { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int RoleId { get; set; }

        public Role Role { get; set; }

        private static bool Equals(Shift left, Shift right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return left.Id == right.Id
                && left.UserId == right.UserId
                && left.RoleId == right.RoleId
                && left.StartTime == right.StartTime
                && left.EndTime == right.EndTime;
        }

        public override bool Equals(object obj) => Equals(this, obj as Shift);

        public bool Equals(Shift otherShift) => Equals(this, otherShift);

        public static bool operator ==(Shift left, Shift right) => Equals(left, right);

        public static bool operator !=(Shift left, Shift right) => !Equals(left, right);

        public override int GetHashCode() => base.GetHashCode() ^ 17;

        public override string ToString() => $"{Id}: {StartTime}, {EndTime}";
    }
}