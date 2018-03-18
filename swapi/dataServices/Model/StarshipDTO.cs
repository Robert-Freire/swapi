using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Swapi.DataServices.Model
{
    [DataContract]
    public class StarshipDTO
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Megalight for standard hour.
        /// </summary>
        /// <value>The MGLT.</value>
        [DataMember]
        public string MGLT { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of time that van provide consumables without resupply
        /// </summary>
        /// <value>The consumables.</value>
        [DataMember]
        public string Consumables { get; set; }
    }
}
