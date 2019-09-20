using CityInfo.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API
{
    public class CityDataStore
    {
        public static CityDataStore Current { get; } = new CityDataStore();
        public List<CityDto> Cities { get; set; }
        public CityDataStore()
        {
            Cities = new List<CityDto>()
            {
                new CityDto()
                {
                    Id=1,
                    Name="Dhaka",
                    Description="The City of Mosque.",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "Lal bag Kella",
                            Description = "It has historic value"
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name = "Carjon Hall",
                            Description = "It is in the Dhaka University"
                        },

                    }
                },
                new CityDto()
                {
                    Id=2,
                    Name="Dinajpur",
                    Description="The City of peace.",
                    PointOfInterests = new List<PointOfInterestDto>()
                    {
                        new PointOfInterestDto()
                        {
                            Id=1,
                            Name = "Ramshagor",
                            Description = "It has historic value"
                        },
                        new PointOfInterestDto()
                        {
                            Id=2,
                            Name = "Skukh Shagor",
                            Description = "Is in a lovely place"
                        },

                    }
                },
                new CityDto()
                {
                    Id=3,
                    Name="Chittagong",
                    Description="the city by the sea "
                }
            };
            
            
        }

       

       
    }
}
