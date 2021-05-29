using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace PFSoftware.TimeClockApi.Models.ViewModels
{
    /// <summary>Represents a <see cref="ShiftViewModel"/> that was started or worked.</summary>
    public class ShiftViewModel
    {
        private readonly string fullDateFormat = @"yyyy-MM-dd hh\:mm\:ss tt zzz";
        private readonly string shiftWeekFormat = "dd':'hh':'mm':'ss";
        private readonly string shiftDayFormat = "hh':'mm':'ss";
        private readonly CultureInfo culture = new CultureInfo("en-US");

        [Key]
        public int Id { get; set; }

        [Required]
        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        [Required]
        public string UserId { get; set; }

        public UserViewModel User { get; set; }

        [Required]
        public int RoleId { get; set; }

        public RoleViewModel Role { get; set; }

        /// <summary>Time <see cref="Shift"/> started, formatted to string.</summary>
        public string StartTimeToString => StartTime.ToString(fullDateFormat, culture);

        /// <summary>Time <see cref="Shift"/> ended, formatted to string.</summary>
        public string EndTimeToString => EndTime != DateTime.MinValue ? EndTime.ToString(fullDateFormat, culture) : "";

        /// <summary>Length of <see cref="Shift"/>.</summary>
        public TimeSpan Length => EndTime != DateTimeOffset.MinValue ? EndTime - StartTime : DateTime.Now - StartTime.UtcDateTime;

        /// <summary>Length of <see cref="Shift"/>, formatted to string.</summary>
        public string LengthToString => EndTime != DateTime.MinValue
            ? Length.Days > 0
            ? Length.ToString(shiftWeekFormat, culture)
            : Length.ToString(shiftDayFormat, culture)
            : "";
    }
}