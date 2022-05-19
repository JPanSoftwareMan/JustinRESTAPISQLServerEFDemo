using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace JustinRESTAPISQLServerEFDemo.Models
{
    public partial class Pipelines
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
        public string LineId { get; set; }
        public decimal? Length { get; set; }
        public string Operator { get; set; }
    }
}
