using System;
using BookingApp.Models.Bookings;
using BookingApp.Models.Rooms;

namespace BookingApp
{
    using BookingApp.Core;
    using BookingApp.Core.Contracts;
    public class StartUp
    {
        public static void Main()
        {
            // Don't forget to comment out the commented code lines in the Engine class!
           IEngine engine = new Engine();
           engine.Run();

           Booking booking = new Booking(new Apartment(), 4, 1, 1, 32);
           Console.WriteLine(booking.BookingSummary());


        }
    }
}
