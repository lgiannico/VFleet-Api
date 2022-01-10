using AutoMapper;
using Challenge.DTOs;
using Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Services
{
  public class VehiclesService
  {
    private readonly ChallengeContext _context;
    private readonly IMapper _mapper;

    public VehiclesService(ChallengeContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }


    public async Task<int> InsertVehicle(VehicleDTO vehicleDTO)
    {
      var entity = _mapper.Map<Vehicle>(vehicleDTO);
      _context.Add(entity);
      return await _context.SaveChangesAsync();
    }

    public async Task<List<VehicleDTO>> GetVehicles()
    {
      //var all= _context.Vehicle.Join(_context.Maintenance, vc => vc.Patent ,
      //          ma => ma.Patent, (vc, ma) => new { vc, ma })
      //          .Select(c => new { Patent = c.vc.Patent,
      //                            Brand = c.vc.Brand ,
      //                            Model =c.vc.Model,
      //                            ChasisNumber=c.vc.ChasisNumber,
      //                            Wheels=c.vc.Wheels,
      //                            UrlImage=c.vc.UrlImage,
      //                            Disabled=c.vc.Disabled,
      //                            KmsTravele=c.ma.KmsTraveled,
      //                            NextMaintenanceKms=c.ma.NextMaintenanceKms
      //          })
      //          .OrderByDescending(c => c.Patent).Take(1);
      var entities = await _context.Vehicle.ToListAsync();
      return  _mapper.Map<List<VehicleDTO>>(entities);

    }

    public async Task<VehicleDTO>GetVehicle(string patent)
    {
      var entity = await _context.Vehicle.FirstOrDefaultAsync(x=>x.Patent==patent);
      return _mapper.Map<VehicleDTO>(entity);

    }

    public async Task<ActionResult<int>> UpdateVehicle(  string patent)
    {

      var query = (from a in _context.Vehicle
                   where a.Patent == patent
                   select a).FirstOrDefault();

      query.Disabled = true;
      _context.Entry(query).State = EntityState.Modified;
      int res =await _context.SaveChangesAsync();
        return res;  

    }

    public async Task<ActionResult<int>> DeleteVehicle(string patent)
    {
      _context.Remove(new Vehicle() { Patent = patent });
      int res = await _context.SaveChangesAsync();
      return res;

    }
  }
    
}
