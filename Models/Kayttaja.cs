using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Kayttaja
    {
        public Kayttaja()
        {
            Kurssi = new HashSet<Kurssi>();
            KurssiSuoritus = new HashSet<KurssiSuoritus>();
            OppituntiSuoritus = new HashSet<OppituntiSuoritus>();
            TehtavaSuoritus = new HashSet<TehtavaSuoritus>();
        }

        public int KayttajaId { get; set; }
        public string Nimi { get; set; }
        public string Email { get; set; }
        public string Salasana { get; set; }
        public bool OnAdmin { get; set; }

        public virtual ICollection<Kurssi> Kurssi { get; set; }
        public virtual ICollection<KurssiSuoritus> KurssiSuoritus { get; set; }
        public virtual ICollection<OppituntiSuoritus> OppituntiSuoritus { get; set; }
        public virtual ICollection<TehtavaSuoritus> TehtavaSuoritus { get; set; }
    }
}
