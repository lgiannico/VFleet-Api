using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Challenge.Models
{
    public partial class Maintenance
    {
        public string Patent { get; set; }
        public long KmsTraveled { get; set; }
        public long? NextMaintenanceKms { get; set; }

        public virtual Vehicle PatentNavigation { get; set; }
    }
}
