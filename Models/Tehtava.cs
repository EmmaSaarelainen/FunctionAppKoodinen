using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class Tehtava
    {
        public Tehtava()
        {
            TehtavaEpaonnistunut = new HashSet<TehtavaEpaonnistunut>();
            TehtavaSuoritus = new HashSet<TehtavaSuoritus>();
            Vihje = new HashSet<Vihje>();
        }

        public int TehtavaId { get; set; }
        public string Nimi { get; set; }
        public string Kuvaus { get; set; }
        public string TehtavaUrl { get; set; }
        public int? OppituntiId { get; set; }

        public virtual Oppitunti Oppitunti { get; set; }
        public virtual ICollection<TehtavaEpaonnistunut> TehtavaEpaonnistunut { get; set; }
        public virtual ICollection<TehtavaSuoritus> TehtavaSuoritus { get; set; }
        public virtual ICollection<Vihje> Vihje { get; set; }
    }
}
