using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CatalogComp.Models;

namespace CatalogComp.Models
{
    public class CatalogCompContext : DbContext
    {
        public CatalogCompContext (DbContextOptions<CatalogCompContext> options)
            : base(options)
        {
        }

        public DbSet<CatalogComp.Models.Company> Company { get; set; }

        public DbSet<CatalogComp.Models.Director> Director { get; set; }

        public DbSet<CatalogComp.Models.Sponser> Sponser { get; set; }
    }
}
