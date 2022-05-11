using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Layer.dto
{
    public class DTOPosition
    {
        public int JourneyID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public float Speed { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
