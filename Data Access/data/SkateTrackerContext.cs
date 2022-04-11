using Microsoft.EntityFrameworkCore;
using Data_Access.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.data
{
    public class SkateTrackerContext : DbContext
    {
        public SkateTrackerContext(DbContextOptions options) : base(options) { }
        public DbSet<Journey> Journey { get; set; }
        public DbSet<Position> Position { get; set; }
    }
}
