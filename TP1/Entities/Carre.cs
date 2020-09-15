using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Carre : Rectangle
    {
        public override double CalculAire()
        {
            return base.Longueur * base.Longueur;
        }

        public override double CalculPerimetre()
        {
            return base.Longueur * 4;
        }

        public override string ToString()
        {
            Console.WriteLine("Carré de coté " + this.Longueur);
           return base.ToStringForme();
        }
    }


}
