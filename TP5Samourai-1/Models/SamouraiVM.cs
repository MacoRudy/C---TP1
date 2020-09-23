using BOSamourai;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP5Samourai.Models
{
    public class SamouraiVM
    {
        public Samourai Samourai { get; set; }
        public List<Arme> ListeArmes { get; set; } = new List<Arme>();
        public int? IdArme { get; set; }
        public List<ArtMartial> ListeArtMartiaux { get; set; } = new List<ArtMartial>();
        public List<int> IdArtMartials { get; set; } = new List<int>();
    }
}