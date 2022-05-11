using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interface_Layer.dto;

namespace Logic_Layer
{
    public class Position
    {
        public int JourneyID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Speed { get; set; }
        public DateTime TimeStamp { get; set; }

        public static explicit operator Position(DTOPosition dto)
        {
            if(dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }
            return new Position()
            {
                JourneyID = dto.JourneyID,
                Latitude = dto.Latitude,
                Longitude = dto.Longitude,
                Speed = dto.Speed,
                TimeStamp = dto.TimeStamp,
            };
        }

        public static explicit operator DTOPosition(Position obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
            return new DTOPosition()
            {
                JourneyID = obj.JourneyID,
                Longitude = obj.Longitude,
                Latitude = obj.Latitude,
                Speed = obj.Speed,
                TimeStamp = obj.TimeStamp,
            };
        }
    }
}
