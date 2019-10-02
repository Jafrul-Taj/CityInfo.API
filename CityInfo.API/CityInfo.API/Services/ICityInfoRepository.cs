using CityInfo.API.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        bool CItyExists(int cityId);
        IEnumerable<City> GetCities();

        City GetCity(int cityId, bool includePointsOfInterest);

        IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId);

        PointsOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);

        void AddPointOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest);

        void DeletePointOfInterest(PointsOfInterest pointsOfInterest);
        bool Save();
    }
}
