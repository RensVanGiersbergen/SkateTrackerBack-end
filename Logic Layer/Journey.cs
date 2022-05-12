using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer.dto;

namespace Logic_Layer
{
    public class Journey
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public float MaxSpeed { get; set; }
        public int TotalTime { get; set; }
        public int RideTime { get; set; }
        public int PauseTime { get; set; }
        public int SkaterID { get; set; }

        public static explicit operator DTOJourney(Journey journey)
        {
            if(journey == null)
            {
                throw new ArgumentNullException(nameof(journey));
            }
            return new DTOJourney()
            {
                Id = journey.Id,
                Name = journey.Name,
                StartTime = journey.StartTime,
                MaxSpeed = journey.MaxSpeed,
                TotalTime = journey.TotalTime,
                RideTime = journey.RideTime,
                PauseTime = journey.PauseTime,
                SkaterID = journey.SkaterID
            };
        }

        public static explicit operator Journey(DTOJourney dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            return new Journey()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTime = dto.StartTime,
                MaxSpeed = dto.MaxSpeed,
                TotalTime = dto.TotalTime,
                RideTime = dto.RideTime,
                PauseTime = dto.PauseTime,
                SkaterID = dto.SkaterID
            };
        }
    }
}
