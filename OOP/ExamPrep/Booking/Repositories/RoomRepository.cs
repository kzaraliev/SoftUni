using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> models;

        public RoomRepository()
        {
            models = new List<IRoom>();
        }

        private IReadOnlyCollection<IRoom> Models
        { get { return this.models.AsReadOnly(); } }

        public void AddNew(IRoom model)
        {
            models.Add(model);
        }

        public IRoom Select(string criteria)
        {
            return models.FirstOrDefault(r => r.GetType().Name == criteria);
        }

        public IReadOnlyCollection<IRoom> All()
        {
            return Models;
        }
        
    }
}
