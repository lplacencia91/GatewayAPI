using System;
using System.Collections.Generic;
using System.Text;

namespace GatwQueryServices.DTOs
{
    public class DeviceForCreationDTO
    {
        public int UID { get; set; }
        public string Vendor { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
     
    }
}
