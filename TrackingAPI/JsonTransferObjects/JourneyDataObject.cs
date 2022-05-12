using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic_Layer;

namespace TrackingAPI.JsonTransferObjects
{
    public class JourneyDataObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public float MaxSpeed { get; set; }
        public int TotalTime { get; set; }
        public int RideTime { get; set; }
        public int PauseTime { get; set; }
        public int SkaterID { get; set; }

        public static explicit operator Journey(JourneyDataObject obj)
        {
            return new Journey() { Name = obj.Name, StartTime = obj.StartTime, MaxSpeed = obj.MaxSpeed, TotalTime = obj.TotalTime, RideTime = obj.RideTime, PauseTime = obj.PauseTime, SkaterID = obj.SkaterID };
        }

        public static explicit operator JourneyDataObject(Journey obj)
        {
            return new JourneyDataObject() { Id = obj.Id, Name = obj.Name, StartTime = obj.StartTime, MaxSpeed = obj.MaxSpeed, TotalTime = obj.TotalTime, RideTime = obj.RideTime, PauseTime = obj.PauseTime, SkaterID = obj.SkaterID };
        }
    }
}
