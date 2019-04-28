using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class PretragaOstalo
    {
        private List<Avion> avioni;

        public List<Avion> Avioni
        {
            get { return avioni; }
            set { this.avioni = value; }
        }

        public PretragaOstalo()
        {
            this.avioni = new List<Avion>();
        }

        public PretragaOstalo(List<Avion> avioni)
        {
            Avioni = avioni;
        }

        public bool nadi(Avion avion)
        {
            for (int i = 0; i < this.avioni.Capacity; i++)
            {
                if (avion.Vrsta.Equals(this.avioni[i].Vrsta) && avion.BrojSjedista == this.avioni[i].BrojSjedista)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
