using Entities;
using Entities.Models;
using GatewayTest.Config;
using GatewTest.Config;
using GatwQueryServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using System;

namespace GatewTest
{
    //Update and Delete methods are  fail because AppDbContextInMemory doesn't save changes. In the original context they do work
    [TestClass]
    public class DeviceUnitTest
    {
        AppDbCoMeConfiguration appDbCoMeConfiguration = new AppDbCoMeConfiguration();
     
        [TestMethod]
        public void TestCreateDevice()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            DeviceQueryServices _services = new DeviceQueryServices(repositoryContext, repositoryManaguer);
            Device device = new Device()
            {
                Vendor = "Microsoft",
                DateCreated = DateTime.Now,
                Status = true
            };

            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway20",
                IPv4Address = "10.192.8.33"
            };

            _services.CreateDevice(gateway.SerialNumber, device);
            bool result = false;
            if (_services.GetByUID(device.UID) != null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestDeleteDevice()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            DeviceQueryServices _services = new DeviceQueryServices(repositoryContext, repositoryManaguer);
            Device device = new Device()
            {
                UID = 15,
                Vendor = "Router WiFi",
                DateCreated = DateTime.Now,
                Status = false,
                AssociatedGatewaySerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            };
            _services.DeleteDevice(device);
            bool result = false;
            if (_services.GetByUID(device.UID) == null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetDevices()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            DeviceQueryServices _services = new DeviceQueryServices(repositoryContext, repositoryManaguer);
            Device device = new Device()
            {
               
                Vendor = "Microsoft",
                DateCreated = DateTime.Now,
                Status = true
               
            };

            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway20",
                IPv4Address = "10.192.8.33"
            };
            var devices = _services.GetDevices(gateway.SerialNumber);
            Assert.IsNotNull(devices);  
        }

        [TestMethod]
        public void TestGetByUID()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            DeviceQueryServices _services = new DeviceQueryServices(repositoryContext, repositoryManaguer);
            Device device = new Device()
            {
                UID = 15,
                Vendor = "Microsoft",
                DateCreated = DateTime.Now,
                Status = true,
                AssociatedGatewaySerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            };
            var devices = _services.GetByUID(device.UID);
            Assert.IsNotNull(devices);
        }

        [TestMethod]
        
        public void TestUpdateDevice()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            DeviceQueryServices _services = new DeviceQueryServices(repositoryContext, repositoryManaguer);
            Device device = new Device()
            {
                UID = 15,
                Vendor = "Microsoft",
                DateCreated = DateTime.Now,
                Status = true,
                AssociatedGatewaySerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            };
            _services.UpdateDevice(device);
            var device2 = _services.GetByUID(device.UID);
            string vendor = device2.Result.Vendor;
            bool result = false;
            if (vendor == "Microsoft") { 
                result = true; }
                Assert.IsTrue(result);
        }
    }
}
