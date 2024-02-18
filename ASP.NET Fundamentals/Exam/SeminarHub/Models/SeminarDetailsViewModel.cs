using SeminarHub.Data;
using System.Globalization;

namespace SeminarHub.Models
{
    public class SeminarDetailsViewModel
    {
        public SeminarDetailsViewModel(int id, string topic, string lecturer, string category, DateTime dateAndTime, string organizerId, string details, int duration)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Category = category;
            DateAndTime = dateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture);
            Organizer = organizerId;
            Details = details;
            Duration = duration.ToString();
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Category { get; set; }

        public string Organizer { get; set; }

        public string DateAndTime { get; set; }

        public string Details { get; set; }

        public string Duration { get; set; }
    }
}
