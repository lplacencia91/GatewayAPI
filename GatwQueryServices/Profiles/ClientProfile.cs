using Entities.Models;
using GatwQueryServices.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.RequestFeatures;

namespace GatwQueryServices.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Gateway, GatewayDTO>();
            CreateMap<Device, DeviceDTO>();
            CreateMap<DeviceForUpdateDTO, Device>();
            CreateMap<GatewayForUpdateDTO, Gateway>();
            CreateMap<GatewayForCreationDTO, Gateway>();
            CreateMap<DeviceForCreationDTO, Device>();
        }

    }
}
