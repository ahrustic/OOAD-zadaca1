using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class PretragaID:Ipretraga
    {
        //private List<Avion> avioni;
        BaznaKlasa baznaKlasa = new BaznaKlasa();
        /*public List<Avion> Avioni
        {
            get { return avioni; }
            set { avioni = value; }
        }*/

        public PretragaID()
        {
            BaznaKlasa baznaKlasa = new BaznaKlasa();
        }
        /*
        public PretragaID(List<Avion> avioni)
        {
            this.avioni = avioni;
        }*/

        public bool nadi(Avion avion)
        {
            for (int i = 0; i < baznaKlasa.Avioni.Count; i++) {
                if (avion.Id.Equals(baznaKlasa.Avioni[i].Id))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
