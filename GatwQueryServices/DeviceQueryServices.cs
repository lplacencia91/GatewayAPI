using Contracts;
using Entities;
using Entities.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GatwQueryServices
{
    public class DeviceQueryServices : RepositoryBase<Device>,IDeviceServices
    {
        private readonly IRepositoryManaguer _repositoryManaguer;
        
        public DeviceQueryServices(RepositoryContext repositoryContext, IRepositoryManaguer repository)
        : base(repositoryContext)
        {
            _repositoryManaguer = repository;
            
        }

        //CreateDevice
        public void CreateDevice(Guid SerialNumber, Device device)
        {

            device.AssociatedGatewaySerialNumber = SerialNumber;
            Create(device);
            _repositoryManaguer.Save();
            
  
        }

        //DeleteDevice
        public void DeleteDevice(Device device)
        {
            Delete(device);
            _repositoryManaguer.Save();
        }

        //GetDevices
        public async Task<IEnumerable<Device>> GetDevices(Guid serialnumber)
        {
            bool trackChanges = false;
            //Task task = new Task(() => _repositoryManaguer.Device.FindByCondition(x => x.AssociatedGatewaySerialNumber == serialnumber, trackChanges));
            var devices =await FindByCondition(x => x.AssociatedGatewaySerialNumber == serialnumber, trackChanges);
           return  devices;
        }

        //GetByUID
        public async Task<Device> GetByUID(int UID)
        {
            bool trackChanges = false;
            var device = await FindByCondition(x => x.UID == UID, trackChanges);
            return device.FirstOrDefault();
        }

        //UpdateDevice
        public void  UpdateDevice(Device device)
        {
            Update(device);
            _repositoryManaguer.Save();
        }

    }
}
