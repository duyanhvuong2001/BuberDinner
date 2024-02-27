using BuberDinner.Domain.Host;
using BuberDinner.Domain.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Infrastructure.Persistence
{
    public class BuberDinnerDbContext : DbContext
    {
        public BuberDinnerDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(e => e.GetProperties())
            //    .Where(p => p.IsPrimaryKey())
            //    .ToList()
            //    .ForEach(p => p.ValueGenerated = ValueGenerated.Never);

            modelBuilder
                .ApplyConfigurationsFromAssembly(typeof(BuberDinnerDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

    }
}
