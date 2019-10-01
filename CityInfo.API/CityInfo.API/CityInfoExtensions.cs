using CityInfo.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public static class CityInfoExtensions
    {
        public static void EnsureSeedDataForContext(this CityInfoContext context)
        {
            if(context.Cities.Any())
            {
                return;
            }

            var cities = new List<City>()
            {
                 new City()
                {
                     Name = "New York City",
                     Description = "The one with that big park.",
                     PointsOfInterest = new List<PointsOfInterest>()
                     {

                         new PointsOfInterest() {
                             Name = "Central Park",
                             Description = "The most visited urban park in the United States."
                         }
                         //,
                         // new PointsOfInterest() {
                         //    Name = "Empire State Building",
                         //    Description = "A 102-story skyscraper located in Midtown Manhattan."
                         // },
                     }
                }
                // ,
                //new City()
                //{
                //    Id = 2,
                //    Name = "Antwerp",
                //    Description = "The one with the cathedral that was never really finished.",
                //    PointsOfInterest = new List<PointsOfInterest>()
                //     {

                //         new PointsOfInterest() {
                //             Name = "Cathedral",
                //             Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                //         }
                //         //,
                //         // new PointsOfInterest() {
                //         //    Name = "Antwerp Central Station",
                //         //    Description = "The the finest example of railway architecture in Belgium."
                //         // },
                //     }
                //},
                //new City()
                //{
                //    Name = "Paris",
                //    Description = "The one with that big tower.",
                //    PointsOfInterest = new List<PointsOfInterest>()
                //     {
                //         new PointsOfInterest() {
                //             Name = "Eiffel Tower",
                //             Description =  "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                //         }
                //         //,
                //         // new PointsOfInterest() {
                //         //    Name = "The Louvre",
                //         //    Description = "The world's largest museum."
                //         // },
                //     }
                //}
        };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
