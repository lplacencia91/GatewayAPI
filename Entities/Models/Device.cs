using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Models
{
    public class Device
    {
        [Column("DeviceId")]
        [Required(ErrorMessage = "UID is a required field.")]
        [Key]
        public int UID { get; set; }
        [Required(ErrorMessage = "Vendor is a required field.")]
        public string Vendor { get; set; }
        [Required(ErrorMessage = "DateCreated address is a required field.")]
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        [Required(ErrorMessage = "This is a required field.")]
        [ForeignKey(nameof(Gateway))]
        public Guid AssociatedGatewaySerialNumber { get; set; }
        public Gateway Gateway { get; set; }
    }
}
