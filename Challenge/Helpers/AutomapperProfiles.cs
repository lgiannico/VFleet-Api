using AutoMapper;
using Challenge.DTOs;
using Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Helpers
{
  public class AutomapperProfiles: Profile
  {
    public AutomapperProfiles()
    {
      CreateMap<Vehicle, VehicleDTO>().ReverseMap();
      CreateMap<Vehicle, VehicleDTO>().ReverseMap();
    }
  }
}
