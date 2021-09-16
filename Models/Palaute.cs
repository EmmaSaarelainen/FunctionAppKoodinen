using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Palaute
    {
        public int PalauteId { get; set; }
        public string Teksti { get; set; }
        public string Lahettaja { get; set; }
        public DateTime Pvm { get; set; }
    }
}
