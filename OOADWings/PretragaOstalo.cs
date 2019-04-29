using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class PretragaOstalo
    {
        /*private List<Avion> avioni;

        public List<Avion> Avioni
        {
            get { return avioni; }
            set { this.avioni = value; }
        }
        */
        BaznaKlasa baznaKlasa = new BaznaKlasa();

        public PretragaOstalo()
        {
            BaznaKlasa baznaKlasa = new BaznaKlasa();
        }

        /*public PretragaOstalo(List<Avion> avioni)
        {
            Avioni = avioni;
        }*/

        public bool nadi(Avion avion)
        {
            for (int i = 0; i < baznaKlasa.Avioni.Count; i++)
            {
                if (avion.Vrsta.Equals(baznaKlasa.Avioni[i].Vrsta) && avion.BrojSjedista == baznaKlasa.Avioni[i].BrojSjedista)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
