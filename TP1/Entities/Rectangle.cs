using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Rectangle : Forme
    {
        private double largeur;
        private double longueur;

        public double Largeur { get => largeur; set => largeur = value; }
        public double Longueur { get => longueur; set => longueur = value; }

        public override double CalculAire()
        {
            return this.Largeur * this.Longueur;
        }

        public override double CalculPerimetre()
        {
            return (this.Longueur + this.Largeur) * 2;
        }

        public override string ToString()
        {
            Console.WriteLine(String.Format("Rectangle de longueur= {0} et de largeur= {1}",this.Longueur,this.Largeur));
            return base.ToString();
        }

        public string ToStringForme()
        {
            return base.ToString();
        }
    }
}
