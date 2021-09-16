using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Func2.Models
{
    public partial class KurssiSuoritus
    {
        public int KurssiSuoritusId { get; set; }
        public DateTime? SuoritusPvm { get; set; }
        public int? KayttajaId { get; set; }
        public int? KurssiId { get; set; }
        public bool? Kesken { get; set; }

        public virtual Kayttaja Kayttaja { get; set; }
        public virtual Kurssi Kurssi { get; set; }
    }
}
