using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CItyInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CItyInfoRepository(CityInfoContext context)
        {
            _context = context;
        }
        public bool CItyExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }
        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
                return _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();

            return _context.Cities.Where(c => c.Id == cityId).FirstOrDefault();
        }

        public PointsOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterests.Where(p => p.CityId == cityId && p.Id == pointOfInterestId).FirstOrDefault();
        }

        public IEnumerable<PointsOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterests.Where(p => p.CityId == cityId).ToList();
        }

        public void AddPointOfInterestForCity(int cityId, PointsOfInterest pointsOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointsOfInterest);
        }

        public bool Save()
        {
            //return(_context.SaveChanges() =>0);

            return (_context.SaveChanges() >= 0);
        }

        public void DeletePointOfInterest(PointsOfInterest pointsOfInterest)
        {
            _context.PointsOfInterests.Remove(pointsOfInterest);
        }
    }
}
