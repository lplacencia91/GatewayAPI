using Entities.Models;
using GatewayTest.Config;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace GatewTest.Config
{
    public class AppDbCoMeConfiguration
    {
        public RepositoryManaguer CreateRepositoryManaguer()
        {
            var context = AppDbContextInMemory.Get();
            context.Devices.Add(new Device
            {
                UID = 15,
                Vendor = "Router WiFi",
                DateCreated = DateTime.Now,
                Status = false,
                AssociatedGatewaySerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")

            });
            context.SaveChanges();
            context.Gateways.Add(new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway10",
                IPv4Address = "10.192.8.20"
            });
            context.SaveChanges();
            RepositoryManaguer repositoryManaguer = new RepositoryManaguer(context);
            return repositoryManaguer;
        }
    }
}
