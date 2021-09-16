using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Kurssi
    {
        public Kurssi()
        {
            KurssiSuoritus = new HashSet<KurssiSuoritus>();
            Oppitunti = new HashSet<Oppitunti>();
        }

        public int KurssiId { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public int? KayttajaId { get; set; }

        public virtual Kayttaja Kayttaja { get; set; }
        public virtual ICollection<KurssiSuoritus> KurssiSuoritus { get; set; }
        public virtual ICollection<Oppitunti> Oppitunti { get; set; }
    }
}
