using Swapi.Model;
using Swapi.DataServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swapi.Configuration;

namespace Swapi.Mapper
{
    /// <summary>
    /// Class StarshipMapper.
    /// Class responsible to map the starshipDTO (swapi format) at the internal format of starships of the application
    /// </summary>
    public class StarshipMapper : IStarshipMapper
    {
        private static Dictionary<string, int> dictConversion;
        /// <summary>
        /// Maps to Starship from StarshipDTO.
        /// </summary>
        /// <param name="from">From.</param>
        /// <returns>Starship.</returns>
        public Starship mapTo(StarshipDTO from)
        {
            var starShip = new Starship(from.Name);
            starShip.MGLT = getMGLT(from.MGLT);
            starShip.ConsumablesHours = getConsumablesHours(from.Consumables);

            return starShip;
        }

        private int? getMGLT (string mglt)
        {
            int result;
            if (int.TryParse(mglt, out result))
            {
                return result;
            }
            return null;
        }

        private int? getConsumablesHours(string consumables)
        {
            if (consumables == null)
            {
                return null;
            }
            createDictionary();
            var consumablesAnalyzed = consumables.Split(' ');
            if (consumablesAnalyzed.Length == 2)
            {
                int hoursPeriod;
                if (dictConversion.TryGetValue(consumablesAnalyzed[1], out hoursPeriod))
                {
                    int lengthPeriod;
                    if (int.TryParse(consumablesAnalyzed[0], out lengthPeriod))
                    {
                        return hoursPeriod * lengthPeriod;
                    }
                }
            }

            return null;
        }
        private void createDictionary()
        {

            if (dictConversion == null)
            {
                const string hour = "hour";
                const string hours = "hours";
                const string day = "day";
                const string days = "days";
                const string week = "week";
                const string weeks = "weeks";
                const string month = "month";
                const string months = "months";
                const string year = "year";
                const string years = "years";

                dictConversion = new Dictionary<string, int>();
                dictConversion.Add(hour, HoursForPeriod.Hour);
                dictConversion.Add(hours, HoursForPeriod.Hour);
                dictConversion.Add(day, HoursForPeriod.Day);
                dictConversion.Add(days, HoursForPeriod.Day);
                dictConversion.Add(week, HoursForPeriod.Week);
                dictConversion.Add(weeks, HoursForPeriod.Week);
                dictConversion.Add(month, HoursForPeriod.Month);
                dictConversion.Add(months, HoursForPeriod.Month);
                dictConversion.Add(year, HoursForPeriod.Year);
                dictConversion.Add(years, HoursForPeriod.Year);
            }
        }
    }
}
