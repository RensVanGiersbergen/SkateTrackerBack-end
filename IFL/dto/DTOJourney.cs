using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Layer.dto
{
    public class DTOJourney
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public float MaxSpeed { get; set; }
        public int TotalTime { get; set; }
        public int RideTime { get; set; }
        public int PauseTime { get; set; }
        public int SkaterID { get; set; }
    }
}
