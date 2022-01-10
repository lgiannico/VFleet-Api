using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.DTOs
{
  public class VehicleMaintenanceDTO
  {
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Patent { get; set; }
    public string ChasisNumber { get; set; }
    public int Wheels { get; set; }
    public string UrlImage { get; set; }
    public bool Disabled { get; set; }
    public int KmsTraveled { get; set; }
    public int NextMaintenanceKms { get; set; }
  }
}
