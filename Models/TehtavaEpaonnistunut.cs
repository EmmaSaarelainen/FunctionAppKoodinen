using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class TehtavaEpaonnistunut
    {
        public int EpaonnistunutId { get; set; }
        public string TehtavanNimi { get; set; }
        public int? EpaonnistunutMaara { get; set; }
        public int? TehtavaId { get; set; }

        public virtual Tehtava Tehtava { get; set; }
    }
}
