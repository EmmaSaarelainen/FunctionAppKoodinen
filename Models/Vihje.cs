using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Vihje
    {
        public int VihjeId { get; set; }
        public string Vihje1 { get; set; }
        public string Vihje2 { get; set; }
        public string Vihje3 { get; set; }
        public int? TehtavaId { get; set; }

        public virtual Tehtava Tehtava { get; set; }
    }
}
