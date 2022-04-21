﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data_Access.models;

namespace TrackingAPI.JsonTransferObjects
{
    public class PositionDataObject
    {
        public int JourneyID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Speed { get; set; }
        public DateTime TimeStamp { get; set; }

        public static explicit operator Position(PositionDataObject obj)
        {
            return new Position() { JourneyID = obj.JourneyID, Latitude = obj.Latitude, Longtitude = obj.Longitude, Speed = obj.Speed, TimeStamp = obj.TimeStamp };
        }
    }
}
