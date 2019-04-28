using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class PretragaID:Ipretraga
    {
        private List<Avion> avioni;

        public List<Avion> Avioni
        {
            get { return avioni; }
            set { this.avioni = value; }
        }

        public PretragaID()
        {
            this.avioni = new List<Avion>();
        }

        public PretragaID(List<Avion> avioni)
        {
            this.avioni = avioni;
        }

        public bool nadi(Avion avion)
        {
            for (int i = 0; i < this.avioni.Capacity; i++) {
                if (avion.Id.Equals(this.avioni[i].Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
