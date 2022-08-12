using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IDeviceServices
    {
        void CreateDevice(Guid IdGateway, Device device);
        void DeleteDevice(Device device);
       Task<IEnumerable<Device>> GetDevices(Guid serialnumber);
       Task<Device> GetByUID(int UID);
        void UpdateDevice(Device device); 
    }
}
