using AutoMapper;
using Contracts;
using Entities.Models;
using GatwQueryServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gatw.Controllers
{
    [Route("api/gateways/{gatewayId}/devices")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly ILoggerManaguer _logger;
        private readonly IDeviceServices _deviceservices;
        private readonly IGatewayServices _gatewayservices;
        private readonly IMapper _mapper;
        public DevicesController(ILoggerManaguer logger, IDeviceServices deviceservices, IGatewayServices gatewayservices,IMapper mapper)
        {
            _logger = logger;
            _deviceservices = deviceservices;
            _gatewayservices = gatewayservices;
            _mapper = mapper;
        }

        //CreateDeviceForGateway
        [HttpPost]
        public  async Task<IActionResult> CreateDeviceForGateway(Guid gatewayId, [FromBody] DeviceForCreationDTO device)
        {
            var dev= device;
            if (dev == null)
            {
                _logger.LogInfo($"Gateway  {gatewayId} doesn't exist");
                return  BadRequest("This Gateway doesn't exist");
            }
            var devices =await _deviceservices.GetDevices(gatewayId);
            int count=devices.Count()+1;
            if (count == 10)
            {
                _logger.LogError($"Gateway {gatewayId} has the maximum(10) associated devices");
                return BadRequest("This Gateway has the maximum(10) associated devices");

            }
            var deviceentity = _mapper.Map<Device>(device);
            _deviceservices.CreateDevice(gatewayId, deviceentity);
            var deviceToReturn = _mapper.Map<DeviceDTO>(deviceentity);
            _logger.LogInfo($"Device with UID: {deviceToReturn.UID} was created.");
            return CreatedAtRoute("DeviceByUID", new { gatewayId, UID = deviceToReturn.UID }, deviceToReturn);
        }

        //DeleteDeviceForGateway
        [HttpDelete("{UID}", Name = "DeviceByUID")]
        public async Task<ActionResult> DeleteDeviceForGateway(Guid gatewayId, int UID)
        {
            var gateway = await _gatewayservices.GetBySerialNumber(gatewayId);
            if (gateway == null)
            {

                _logger.LogInfo($"Gateway  {gatewayId} doesn't exist");
                return BadRequest("This Gateway doesn't exist");
            }
            var deviceForGateway = await _deviceservices.GetByUID(UID);
            if (deviceForGateway == null)
            {
                _logger.LogInfo($"Device {UID} doesn't exist");
                return BadRequest("This Device doesn't exist");
            }
            _deviceservices.DeleteDevice(deviceForGateway);
            return NoContent();
        }

        //GetDevicesForGateway
        [HttpGet]
        public async Task<IActionResult> GetDevicesForGateway(Guid gatewayId)
        {
            var gateway =await _gatewayservices.GetBySerialNumber(gatewayId);
            if (gateway == null)
            {
                _logger.LogInfo($"Gateway {gatewayId} doesn't exist");
                return BadRequest("This Gateway doesn't exist");
            }
            var devicesFromDb =await _deviceservices.GetDevices(gatewayId);
            if (devicesFromDb == null)
            {
                _logger.LogInfo($"Gateway  {gatewayId} has  no associated devices");
                return BadRequest("This Gateway has  no associated devices");
            }
            var devicesDto = _mapper.Map<IEnumerable<DeviceDTO>>(devicesFromDb);
            _logger.LogInfo($"Devices by {gatewayId} returnees");
            return Ok(devicesDto);
        }

        //GetDeviceByUID
        [Route("{UID}", Name= "DeviceByUID")]
        [HttpGet]
        public async Task<IActionResult> GetDeviceByUID(Guid gatewayId, int UID)
        {
            var gateway = await _gatewayservices.GetBySerialNumber(gatewayId);
            if (gateway == null)
            {
                _logger.LogInfo($"Gateway {gatewayId} doesn't exist");
                return BadRequest("This Gateway doesn't exist");
            }
            var deviceFromDb =await _deviceservices.GetByUID(UID);
            if (deviceFromDb == null)
            {
                _logger.LogInfo($"Devices {UID} doesn't exist");
                return BadRequest("This Devices doesn't exist");
            }
            _logger.LogInfo($"Deviced {UID} returned");
            return Ok(deviceFromDb);
        }

        //UpdateDeviceForGateway
        [HttpPut("{UID}")]
        public async Task<IActionResult> UpdateDeviceForGateway(Guid gatewayId, int UID, [FromBody]
DeviceForUpdateDTO device)
        {
            if (device == null)
            {  
                return BadRequest("This Devices object is null");
            }
            var gateway = await _gatewayservices.GetBySerialNumber(gatewayId);
            if (gateway == null)
            {
            _logger.LogInfo($"Gateway: {gatewayId} doesn't exist in the database.");
            return BadRequest("This Gateway doesn't exist");
            }
            var deviceEntity =await _deviceservices.GetByUID( UID);
            if (deviceEntity == null)
            {
                _logger.LogInfo($"Device: {UID} doesn't exist in the database.");
                return BadRequest("This Device doesn't exist");
            }
            _mapper.Map(device, deviceEntity);
            _deviceservices.UpdateDevice(deviceEntity);
            _logger.LogInfo($"Device {UID} updated");
            return NoContent();
        }
    }
}
