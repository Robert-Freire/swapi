using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.Model
{
    
    public class Starship
    {
        public Starship(string name )
        {
            Name = name;
        }
        /// <summary>
        /// The name of this starship
        /// </summary>
        /// <value>The Name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// The Maximum number of Megalights this starship can travel in a standard hour
        /// </summary>
        /// <value>The MGLT.</value>
        public int? MGLT { get; set; }
        /// <summary>
        /// The maximum number of hours that this starship can provide consumables for its entire crew without having to resupply.
        /// </summary>
        /// <value>The hours consumables.</value>
        public int? ConsumablesHours { get; set; }

        /// <summary>
        /// Gets the distance that this starship can travel without stop.
        /// </summary>
        /// <value>The distance without stop.</value>
        public int? DistanceWithoutStop
        {
            get {
                return MGLT * ConsumablesHours;
            }
        }
    }
}
