using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        public DbSet<Gateway> Gateways { get; set; }
        public DbSet<Device> Devices { get; set; }
        protected override void OnModelCreating(ModelBuilder bilder)
        {
            bilder.ApplyConfiguration(new GatewayConfiguration());
            bilder.ApplyConfiguration(new DeviceConfiguration());
        }

    }
}
