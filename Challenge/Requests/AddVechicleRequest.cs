using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Requests
{
   
  public class AddVechicleRequest
  {
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Patent { get; set; }
    public string ChasisNumber { get; set; }
    public int Wheels { get; set; }
    public string UrlImage { get; set; }

    
  }
}
