using AutoMapper;
using Contracts;
using Entities.Models;
using Entities.RequestFeatures;
using GatwQueryServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Gatw.Controllers
{

    [Route("api/gateways")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly ILoggerManaguer _logger;
        private readonly IGatewayServices _services;
        private readonly IMapper _mapper;

        public GatewayController(ILoggerManaguer logger,IGatewayServices services, IMapper mapper)
        {
            _logger = logger;
            _services = services;
            _mapper = mapper;
        }

        //CreateGateway
        [HttpPost]
        public  IActionResult CreateGateway([FromBody] GatewayForCreationDTO gateway)
        {
            var gatw = gateway;
            if (gatw != null)
            {
                IPAddress ipaddress;
               
                
                    var gatewayentity = _mapper.Map<Gateway>(gateway);

                    if (IPAddress.TryParse(gatw.IPv4Address, out ipaddress))
                    {
                         _services.CreateGateway(gatewayentity);
                        var gatewayToReturn = _mapper.Map<GatewayDTO>(gatewayentity);
                        _logger.LogInfo($"Gateway with Serial Number: {gatewayToReturn.SerialNumber} was created.");
                        return CreatedAtRoute("GatewayBySerialNumber", new { id = gatewayToReturn.SerialNumber }, gatewayToReturn);

                    }   
                
                else  {
                    _logger.LogError("Invalid IPv4 address sent from client");
                    return BadRequest("Invalid IPv4 address");
                }
            }
            else {
                _logger.LogError("GatewayForCreationDTO object sent from client is null.");
                return BadRequest("Object is null"); 
            }
        }

        //GetAllGateways paging
        [Route("pag")]
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GatewayParameter gatewayparameter)

        {

            var gateways =await _services.GetAll(gatewayparameter);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(gateways.metaData));
            var gatewaysdto = _mapper.Map<IEnumerable<GatewayDTO>>(gateways);
            _logger.LogInfo("Get Gateways");
            return Ok(gatewaysdto);
        }

        //GetBySerialNumber
        [HttpGet]
        [Route("{id}", Name = "GatewayBySerialNumber")]
        public async Task<IActionResult> GetBySerialNumber(Guid id)
        {
            var gateway =await _services.GetBySerialNumber(id);
            if (gateway == null)
            {
                _logger.LogError("Invalid IPv4 address sent from client");
                return BadRequest("This Gateway doesn't exist");
            }
            var gatewaydto = _mapper.Map<GatewayDTO>(gateway);
            return Ok(gatewaydto);

        }

        //DeleteGateway
        [HttpDelete("{serialnumber}")]
        public async Task<ActionResult> DeleteGateway(Guid serialnumber)
        {
            var gateway = await _services.GetBySerialNumber(serialnumber);
            if (gateway == null)
            {
                _logger.LogInfo($"Gateway with Serial Number: {serialnumber} doesn't exist in the database.");
                return BadRequest("This Gateway doesn't exist");
            }
            _services.DeleteGateway(gateway);
            _logger.LogInfo($"Gateway with Serial Number: {serialnumber} was deleted in the database.");
            return NoContent();
        }

        //UpdateGateway
        [HttpPut("{serialnumber}")]
        public async Task<IActionResult> UpdateGateway(Guid serialnumber, [FromBody]GatewayForUpdateDTO gatewayForUpdateDTO)
        {     
            var gateway = await _services.GetBySerialNumber(serialnumber);
            if (gateway == null)
            {
                _logger.LogInfo($"Gateway with Serial Number: {serialnumber} doesn't exist in the database.");
                return BadRequest("This Gateway doesn't exist");
            }
            
            _mapper.Map(gatewayForUpdateDTO, gateway);
            _services.UpdateGateway(gateway);
            _logger.LogInfo($"Gateway with Serial Number: {serialnumber} was updated in the database.");
            return NoContent();
        }

    }
}
