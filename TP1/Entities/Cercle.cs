using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Cercle : Forme
    {

        private double rayon;
       
        public double Rayon { get => rayon; set => rayon = value; }

        public override double CalculAire()
        {
            return Math.PI * this.Rayon * this.Rayon;
        }

        public override double CalculPerimetre()
        {
            return 2 * Math.PI * this.Rayon;       
        }

        public override string ToString()
        {
            Console.WriteLine("Cercle de Rayon " + this.Rayon);
            return base.ToString();
        }
    }
}
