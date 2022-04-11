using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.models
{
    public class Journey
    {
        [Key]
        public int Id { get; set; }
        public int SkaterId { get; set; }
        public int SkateboardId { get; set; }
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public float MaxSpeed { get; set; }
        public int TotalTime { get; set; }
        public int RideTime { get; set; }
        public int PauseTime { get; set; }
        public bool isPaused { get; set; }
        public List<Position> positions { get; set; }
    }
}
