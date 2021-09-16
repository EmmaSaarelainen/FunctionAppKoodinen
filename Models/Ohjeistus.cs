using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Ohjeistus
    {
        public int OhjeistusId { get; set; }
        public string TekstiKentta { get; set; }
        public int? OppituntiId { get; set; }

        public virtual Oppitunti Oppitunti { get; set; }
    }
}
