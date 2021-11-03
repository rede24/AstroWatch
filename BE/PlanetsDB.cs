using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Planet

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string Description { get; set; }

    }


    public class PlanetDB : DbContext
    {
        public PlanetDB() : base("solarSystem")
        {


        }
        public DbSet<Planet> SolarSystem { get; set; }
    }
}