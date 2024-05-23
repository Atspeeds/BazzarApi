using Bazzar.Core.Domain.Advertisements.Entitys;
using Bazzar.Infrastructures.Data.Sql.Advertisments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bazzar.Infrastructures.Data.Sql
{
    public class AdvertisementsDbContext : DbContext
    {
        public AdvertisementsDbContext(DbContextOptions<AdvertisementsDbContext> options) : base(options)
        {
        }

        #region Table Entitys
        public DbSet<Advertisment> Advertisments { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);

        }
    }

}
