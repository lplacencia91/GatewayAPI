using System;
using System.Collections.Generic;
using System.Text;

namespace GatwQueryServices.DTOs
{
    public class GatewayDTO
    {
        
        public Guid SerialNumber { get; set; }
        public string Name { get; set; }
        public string IPv4Address { get; set; }
        public ICollection<DeviceDTO> Devices { get; set; }
    }
}
