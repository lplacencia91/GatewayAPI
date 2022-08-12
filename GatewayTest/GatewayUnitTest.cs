using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repository;
using GatewTest.Config;
using GatwQueryServices;
using Entities.Models;
using Entities.RequestFeatures;
using Entities;
using GatewayTest.Config;

namespace GatewTest
{
    //Update and Delete methods are  fail because AppDbContextInMemory doesn't save changes. In the original context they do work
    [TestClass]
    public class GatewayUnitTest
    {
        AppDbCoMeConfiguration appDbCoMeConfiguration = new AppDbCoMeConfiguration();

        [TestMethod]
        public void TestCreateGateway()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext= AppDbContextInMemory.Get();
            GatewayQueryServices _services = new GatewayQueryServices(repositoryContext,repositoryManaguer);

            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991809"),
                Name = "Gateway20",
                IPv4Address = "10.192.8.45"
            };

            _services.CreateGateway(gateway);
            bool result = false;
            if (_services.GetBySerialNumber(gateway.SerialNumber) != null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetBySerialNumber()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            GatewayQueryServices _services = new GatewayQueryServices(repositoryContext, repositoryManaguer);

            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway20",
                IPv4Address = "10.192.8.45"
            };

            var gateway2 = _services.GetBySerialNumber(gateway.SerialNumber);
            bool result = false;
            if (gateway2 != null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestGetAll()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            GatewayQueryServices _services = new GatewayQueryServices(repositoryContext, repositoryManaguer);
            GatewayParameter gatewayparameter = new GatewayParameter
            {
                pageNumber = 1,
                PageSize = 10,
            };

            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway20",
                IPv4Address = "10.192.8.45"
            };

            var gateway2 = _services.GetAll(gatewayparameter);
            bool result = false;
            if (gateway2 != null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteGateway()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            GatewayQueryServices _services = new GatewayQueryServices(repositoryContext, repositoryManaguer);
            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "Gateway20",
                IPv4Address = "10.192.8.45"
            };
            _services.DeleteGateway(gateway);
            bool result = false;
            var gatw = _services.GetBySerialNumber(gateway.SerialNumber);
            if (gatw== null)
            {
                result = true;
            }

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestUpdateDevice()
        {
            RepositoryManaguer repositoryManaguer = appDbCoMeConfiguration.CreateRepositoryManaguer();
            RepositoryContext repositoryContext = AppDbContextInMemory.Get();
            GatewayQueryServices _services = new GatewayQueryServices(repositoryContext, repositoryManaguer);
            Gateway gateway = new Gateway
            {
                SerialNumber = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
                Name = "GatewayRX",
                IPv4Address = "10.192.8.10"
            };
            _services.UpdateGateway(gateway);
            var device2 = _services.GetBySerialNumber(gateway.SerialNumber);
            string name = device2.Result.Name;
            string IPv4 = device2.Result.IPv4Address;
            bool result = false;
            if ((name == "GatewayRX") && (IPv4 == "10.192.8.10")) { 
                result = true;
            }
                Assert.IsTrue(result);
        }
    }
}
