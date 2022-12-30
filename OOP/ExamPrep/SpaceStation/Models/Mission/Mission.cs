using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission.Contracts;
using SpaceStation.Models.Planets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            while (planet.Items.Count >0)
            {
                IAstronaut currentAstronaut = astronauts.Where(x => x.CanBreath).FirstOrDefault();

                if (currentAstronaut != null)
                {
                    currentAstronaut.Breath();
                    string item = planet.Items.FirstOrDefault();
                    planet.Items.Remove(item);
                    currentAstronaut.Bag.Items.Add(item);
                }
                else
                {
                    break;
                }
            }
        }
    }
}
