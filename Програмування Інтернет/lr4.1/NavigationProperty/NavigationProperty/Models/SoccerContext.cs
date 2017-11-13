using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NavigationProperty.Models
{
    public class SoccerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }

}