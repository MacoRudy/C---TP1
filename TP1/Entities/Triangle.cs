using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public class Triangle : Forme
    {
        private double a;
        private double b;
        private double c;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }

        public override double CalculAire()
        {
            double p = CalculPerimetre() / 2;
            double aire = Math.Sqrt(p*(p - A) * (p - B) * (p - C));
            return aire;
        }

        public override double CalculPerimetre()
        {
            return A + B + C;       
        }

        public override string ToString()
        {
            Console.WriteLine(String.Format("Triangle de coté A= {0}, B={1} et C= {2}",this.a,this.b,this.c));
            return base.ToString();
        }
    }
}
