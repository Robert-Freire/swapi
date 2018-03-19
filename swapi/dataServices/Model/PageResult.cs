using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Swapi.DataServices.Model
{
    /// <summary>
    /// Class PageResult.
    /// This is one page result of the SWAPI
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract]
    public class PageResult<T> 
    {
        /// <summary>
        /// Total number of elements
        /// </summary>
        [DataMember]
        public string Count;
        /// <summary>
        /// The next page with results
        /// </summary>
        [DataMember]
        public string Next;

        /// <summary>
        /// The previous page with results
        /// </summary>
        [DataMember]
        public string Previous;
        /// <summary>
        /// The results
        /// </summary>
        [DataMember]
        public IEnumerable<T> Results;
    }
}
