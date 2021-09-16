using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Oppitunti
    {
        public Oppitunti()
        {
            Ohjeistus = new HashSet<Ohjeistus>();
            OppituntiSuoritus = new HashSet<OppituntiSuoritus>();
            Tehtava = new HashSet<Tehtava>();
        }

        public int OppituntiId { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public int? KurssiId { get; set; }

        public virtual Kurssi Kurssi { get; set; }
        public virtual ICollection<Ohjeistus> Ohjeistus { get; set; }
        public virtual ICollection<OppituntiSuoritus> OppituntiSuoritus { get; set; }
        public virtual ICollection<Tehtava> Tehtava { get; set; }
    }
}
