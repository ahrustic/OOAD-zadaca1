using System;
namespace OOADWings
{
    class TeretniAvion : Avion
    {
        private double kapacitet;

        public double Kapacitet
        {
            get { return kapacitet; }
            set { this.kapacitet = value; }
        }

        public TeretniAvion()
        {
            kapacitet = 0;
        }

        public TeretniAvion(double kapacitet)
        {
            Kapacitet = kapacitet;
        }
    }
}


