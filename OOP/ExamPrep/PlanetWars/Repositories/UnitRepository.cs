using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> militaryUnits;

        public UnitRepository()
        {
            militaryUnits = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.militaryUnits;

        public void AddItem(IMilitaryUnit model)
        {
            militaryUnits.Add(model);
        }

        public IMilitaryUnit FindByName(string name) => this.militaryUnits.FirstOrDefault(x => x.GetType().Name == name);

        public bool RemoveItem(string unitName) => this.militaryUnits.Remove(this.militaryUnits.FirstOrDefault(x => x.GetType().Name == unitName));
    }
}
