using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.models
{
    [Keyless]
    public class Position
    {
        [Required]
        [ForeignKey("JourneyID")]
        public Journey journey { get; set; }
        [Required]
        public double Latitude { get; set; }
        [Required]
        public double Longtitude { get; set; }
        [Required]
        public float Speed { get; set; }
        [Required]
        public DateTime TimeStamp { get; set; }

    }
}
