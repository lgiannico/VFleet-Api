using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Challenge.Models
{
  public partial class Vehicle
  {
    public string Brand { get; set; }
    public string Model { get; set; }
    [Required]
    public string Patent { get; set; }
    [Required]
    public string ChasisNumber { get; set; }
    public int Wheels { get; set; }
    public string UrlImage { get; set; }
    public bool Disabled { get; set; }
  }
}
