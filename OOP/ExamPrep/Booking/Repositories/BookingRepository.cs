using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> models;

        public BookingRepository()
        {
            models = new List<IBooking>();
        }

        private IReadOnlyCollection<IBooking> Models
        { get { return this.models.AsReadOnly(); } }

        public void AddNew(IBooking model)
        {
            models.Add(model);
        }

        public IBooking Select(string criteria)
        {
            return models.FirstOrDefault(b => b.BookingNumber == int.Parse(criteria));
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return Models;
        }
    }
}
