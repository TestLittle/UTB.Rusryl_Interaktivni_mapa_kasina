using System;
using System.Collections.Generic;
using System.Text;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Domain.Entities
{
    public class MarkerModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latititude { get; set; }
    }
}
