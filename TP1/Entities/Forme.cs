using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1.Entities
{
    public abstract class Forme
    {
        private double aire;
        private double perimetre;



        public double Aire
        {
            get { return CalculAire(); }
            set { aire = CalculAire(); }
        }

        public double Perimetre
        {
            get { return CalculPerimetre(); }
            set { perimetre = CalculPerimetre(); }
        }

       
        public abstract double CalculAire();
        public abstract double CalculPerimetre();


        public override string ToString()
        {
            return String.Format("aire : {0} \nperimetre : {1}\n", this.Aire, this.Perimetre);
        }
    }
}
