using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Entity
{
    public class City
    {
        public City()
        {
            PointsOfInterest = new List<PointsOfInterest>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]

        public string Name { get; set; }
        [Required]
        [MaxLength(50)]
        public string Description { get; set; }

        public List<PointsOfInterest> PointsOfInterest { get; set; }
            
    }
}
