using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Heroes.Models.Contracts;
using Heroes.Repositories.Contracts;

namespace Heroes.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> models;

        public WeaponRepository()
        {
            models = new List<IWeapon>();
        }

        public IReadOnlyCollection<IWeapon> Models
        { get { return this.models.AsReadOnly(); } }

        public void Add(IWeapon model)
        {
            models.Add(model);
        }

        public bool Remove(IWeapon model)
        {
            return models.Remove(model);
        }

        public IWeapon FindByName(string name)
        {
            return models.FirstOrDefault(h => h.Name == name);
        }
    }
}
