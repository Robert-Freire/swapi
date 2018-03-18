using swapi.BusinessLogic;
using Swapi.DataServices;
using Swapi.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swapi
{
    class Program
    {
        static  void Main(string[] args)
        {
            Console.WriteLine("Which is the distance to jump?");
            var distance = Console.ReadLine();
            int travelDistance;

            if (int.TryParse(distance, out travelDistance)){


                var starshipBL = new StarshipBusinessLogic(new StarshipMapper(), new StarshipDataService(new HttpClientHandler(), new AppConfigurationManager()));
                var starships = starshipBL.GetAll();
  
                foreach (var starship in starships)
                {
                    var numberOfJumps = starshipBL.GetNumberOfJumps(starship, travelDistance);
                    Console.WriteLine("Name:{0}.\tNumber of jumps:{1}", starship.Name, numberOfJumps);
                }
            } else
            {
                Console.WriteLine("The distance entered {0} is not a number", distance);
            }
            Console.WriteLine("Press any key to finish");
            Console.ReadKey();
        }
    }
}
