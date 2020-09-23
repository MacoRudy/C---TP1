using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BOSamourai
{
    public class Samourai : GestionId
    {

        public int Force { get; set; }
        public string Nom { get; set; }
        public virtual Arme Arme { get; set; }
        [Display(Name = "Arts Martiaux maitrisés")]
        public virtual List<ArtMartial> ArtMartials { get; set; } = new List<ArtMartial>();
        public int Potentiel
        {
            get
            {
                int degat = 0;
                if (this.Arme != null)
                {
                    degat = this.Arme.Degats;

                }
                return (this.Force + degat) * (this.ArtMartials.Count + 1);
            }

        }

    }
}
