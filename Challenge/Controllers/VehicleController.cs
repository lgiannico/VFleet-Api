using Challenge.DTOs;
using Challenge.Models;
using Challenge.Requests;
using Challenge.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  
  public class VehicleController : ControllerBase
  {
    private readonly ILogger<VehicleController> _logger;
    private readonly VehiclesService _vehicleService;

    public VehicleController(ILogger<VehicleController> logger, VehiclesService vehicleService)
    {
      _logger = logger;
      _vehicleService = vehicleService;
    }
    [HttpPost]
    public async Task<ActionResult<VehicleDTO>> Post( [FromBody] VehicleDTO  vehicleDTO)
    {
      _logger.LogInformation("Insert new Vehicle has been called");
      try
      {
         
        _logger.LogWarning($"Request Parameters  :{ ""} ");
         await _vehicleService.InsertVehicle( vehicleDTO);
        return CreatedAtAction(nameof(Get),new { Patent = vehicleDTO.Patent },vehicleDTO);
         
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw e;
      }
    }

    [HttpGet]
    public async Task<List<VehicleDTO>> GetAll()
    {
      _logger.LogInformation("get Vehicles has been called");
      try
      {
        _logger.LogWarning($"Request Parameters  : none ");
        return await _vehicleService.GetVehicles();
      }
      catch (Exception e)
      {

        _logger.LogError(e.Message);
        throw e;
      }
    }

    [HttpGet("{patent}")]
    public async Task<VehicleDTO> Get(string patent)
    {
      _logger.LogInformation("get Vehicle has been called");
      try
      {
        _logger.LogWarning($"Request Parameters  : {patent} ");
        return await _vehicleService.GetVehicle(patent);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw e;
      }
    }

    [HttpPut("{patent}")]
    public async Task<ActionResult<int>> DisabledVehicle(string patent)
    {
      _logger.LogInformation("Update Vehicle has been called");
      try
      {
        _logger.LogWarning($"Request Parameters  : {patent} ");
        return await _vehicleService.UpdateVehicle(patent);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw e;
      }
    }

    [HttpDelete("{patent}")]
    public async Task<ActionResult<int>> DeleteVehicle(string patent)
    {
      _logger.LogInformation("Delete Vehicle has been called");
      try
      {
        _logger.LogWarning($"Request Parameters  : {patent} ");
        return await _vehicleService.DeleteVehicle(patent);
      }
      catch (Exception e)
      {
        _logger.LogError(e.Message);
        throw e;
      }
    }


  }
}
