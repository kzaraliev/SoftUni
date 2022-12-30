using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room
        {
            get { return room; }
            private set { room = value; }
        }

        public int ResidenceDuration
        {
            get { return residenceDuration; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }
                residenceDuration = value;
            }
        }
        public int AdultsCount
        {
            get { return adultsCount; }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }
                adultsCount = value;
            }
        }
        public int ChildrenCount
        {
            get { return childrenCount; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }
                childrenCount = value;
            }
        }


        public int BookingNumber
        {
            get { return bookingNumber; }
            private set { bookingNumber = value; }
        }
        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            double totalPaid = Math.Round(ResidenceDuration * Room.PricePerNight, 2);
            sb.AppendLine($"Booking number: {BookingNumber}");
            sb.AppendLine($"Room type: {Room.GetType().Name}");
            sb.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            sb.AppendLine($"Total amount paid: { totalPaid:F2}$");

            return sb.ToString().TrimEnd();
        }
    }
}
