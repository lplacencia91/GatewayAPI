using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class GatewayConfiguration: IEntityTypeConfiguration<Gateway>
    {

        public void Configure(EntityTypeBuilder<Gateway> builder)
        {
            builder.HasData
            (
            new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway1",
                IPv4Address = "10.8.77.120"

            },
            new Gateway
            {
                SerialNumber = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                Name = "Gateway2",
                IPv4Address = "10.8.77.130"

            }
            );
        }
            
        }
}
