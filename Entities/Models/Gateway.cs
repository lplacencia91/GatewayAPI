using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;
using System.Text;

namespace Entities.Models
{
    public class Gateway
    {
        [Column("GatewaeyId")]
        [Required(ErrorMessage = "Serial Number is a required field.")]
        [Key]
        public Guid SerialNumber { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "IPv4 Address is a required field.")]
        public string IPv4Address { get; set; }
        [MaxLength(10, ErrorMessage = "Maximum lenght for a Gatawey is 10 devices")]
        public ICollection<Device> Devices { get; set; }

    }
}
