using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> models;

        public HotelRepository()
        {
            models = new List<IHotel>();
        }

        private IReadOnlyCollection<IHotel> Models
        { get { return this.models.AsReadOnly(); } }

        public void AddNew(IHotel model)
        {
            models.Add(model);
        }

        public IHotel Select(string criteria)
        {
            return models.FirstOrDefault(h => h.FullName == criteria);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return Models;
        }
    }
}
