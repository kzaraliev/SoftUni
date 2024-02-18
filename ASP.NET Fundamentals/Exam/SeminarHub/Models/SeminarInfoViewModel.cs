using SeminarHub.Data;
using System.Globalization;

namespace SeminarHub.Models
{
    public class SeminarInfoViewModel
    {
        public SeminarInfoViewModel(int id, string topic, string lecturer, string category, DateTime dateAndTime, string organizerId)
        {
            Id = id;
            Topic = topic;
            Lecturer = lecturer;
            Category = category;
            DateAndTime = dateAndTime.ToString(DataConstants.DateFormat, CultureInfo.InvariantCulture);
            Organizer = organizerId;
        }

        public int Id { get; set; }

        public string Topic { get; set; }

        public string Lecturer { get; set; }

        public string Category { get; set; }

        public string Organizer { get; set; }

        public string DateAndTime { get; set; }
    }
}
