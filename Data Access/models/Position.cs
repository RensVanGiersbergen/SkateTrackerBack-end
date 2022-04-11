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
    public class Position
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("JourneyID")]
        public int JourneyID { get; set; }
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
