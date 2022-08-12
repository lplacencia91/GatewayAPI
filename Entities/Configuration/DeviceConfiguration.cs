
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class DeviceConfiguration:IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasData
            (
            new Device
            {
                UID = 1,
                Vendor = "Modem HP",
                DateCreated = new  DateTime(2022,08,02),
                Status = true,
                AssociatedGatewaySerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            },
            new Device
            {
                UID = 2,
                Vendor = "Printer HP",
                DateCreated = new DateTime(2022, 08, 03),
                Status = false,
                AssociatedGatewaySerialNumber = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811")
            }
            );
        }


    }
}
