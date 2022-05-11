using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access.data;
using Data_Access.models;
using Microsoft.EntityFrameworkCore;
using Interface_Layer;
using Interface_Layer.dto;
using Data_Access;

namespace Data_Access
{
    public class Queries: IPositionCollectionDAL, IJourneyCollectionDAL
    {
        SkateTrackerContext context = new SkateTrackerContext(new DbContextOptionsBuilder<SkateTrackerContext>().UseSqlServer(Configuration.ConnectionString).Options);
        public void AddPosition(DTOPosition dto)
        {
            Position position = new Position()
            {
                JourneyID = dto.JourneyID,
                Latitude = dto.Latitude,
                Longtitude = dto.Longitude,
                Speed = dto.Speed,
                TimeStamp = dto.TimeStamp,
            };
            context.Add(position);
            context.SaveChanges();
        }

        public int AddJourney(DTOJourney dto)
        {
            Journey journey = new Journey()
            {
                Id = dto.Id,
                Name = dto.Name,
                StartTime = dto.StartTime,
                MaxSpeed = dto.MaxSpeed,
                TotalTime = dto.TotalTime,
                RideTime = dto.RideTime,
                PauseTime = dto.PauseTime
            };
            context.Add(journey);
            context.SaveChanges();

            return journey.Id;
        }
    }
}
