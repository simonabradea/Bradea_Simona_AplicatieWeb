using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bradea_Simona_AplicatieWeb.Models;

namespace Bradea_Simona_AplicatieWeb.Data
{
    public class Bradea_Simona_AplicatieWebContext : DbContext
    {
        public Bradea_Simona_AplicatieWebContext (DbContextOptions<Bradea_Simona_AplicatieWebContext> options)
            : base(options)
        {
        }

        public DbSet<Bradea_Simona_AplicatieWeb.Models.Bijuterie> Bijuterie { get; set; }

        public DbSet<Bradea_Simona_AplicatieWeb.Models.Client> Client { get; set; }

        public DbSet<Bradea_Simona_AplicatieWeb.Models.Categorie> Categorie { get; set; }
    }
}
