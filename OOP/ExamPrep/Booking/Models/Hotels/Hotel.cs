using System;
using System.Collections.Generic;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;
        private double turnover;
        private IRepository<IRoom> rooms;
        private IRepository<IBooking> bookings;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }
                fullName = value;
            }
        }
        public int Category
        {
            get { return category; }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }
                category = value;
            }
        }
        public double Turnover
        {
            get { return turnover; }
            private set
            {
                foreach (var booking in Bookings.All())
                {
                    turnover += booking.ResidenceDuration * booking.Room.PricePerNight;
                }

                turnover = Math.Round(turnover, 2);
            }
        }
        public IRepository<IRoom> Rooms
        {
            get { return rooms; }
            private set { rooms = value; }
        }
        public IRepository<IBooking> Bookings
        {
            get { return bookings; }
            private set { bookings =value; }
        }
    }
}
