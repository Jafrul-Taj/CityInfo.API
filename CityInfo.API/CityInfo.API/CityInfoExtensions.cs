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

                    Name ="New Youk City",
                    Description ="The one with that big park",
                    PointsOfInterest = new List<PointsOfInterest>()
                    {
                        new PointsOfInterest()
                        {
                            City=context.Cities.Where(a =>a.Id==0).FirstOrDefault(),
                            Name="Central Park",
                            Description = "The most visited urban park in the United States"
                        },
                        new PointsOfInterest()
                        {
                             City=context.Cities.Where(a =>a.Name=="New Youk City").FirstOrDefault(),
                            Name="Empire State Building",
                            Description = "A 102-story skyscaper located in Midtown Manhattan."
                        },
                    }
                },
                
                new City()
                {
                    Name ="Paris",
                    Description ="The one with that big tower.",
                    PointsOfInterest = new List<PointsOfInterest>()
                    {
                        new PointsOfInterest()
                        {
                            City=context.Cities.Where(a =>a.Name=="Paris").FirstOrDefault(),
                            Name="Eiffel Tower",
                            Description = "A wrought iron lattice tower on the Champ de Mars, named after the engineer Gustave Eiffel"
                        },
                        new PointsOfInterest()
                        {
                            City=context.Cities.Where(a =>a.Name=="Paris").FirstOrDefault(),
                            Name="The Louvre",
                            Description = "The world's largest museum"
                        },
                    }
                },
                 new City()
                {
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointsOfInterest>()
                     {
                         new PointsOfInterest() {
                             City=context.Cities.Where(a =>a.Name=="Antwerp").FirstOrDefault(),
                             Name = "Cathedral",
                             Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                         },
                          new PointsOfInterest() {
                             City=context.Cities.Where(a =>a.Name=="Antwerp").FirstOrDefault(),
                             Name = "Antwerp Central Station",
                             Description = "The the finest example of railway architecture in Belgium."
                          },
                     }
                }
            };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }
    }
}
