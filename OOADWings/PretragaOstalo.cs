using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class PretragaOstalo:Ipretraga<Avion>
    {
        /*private List<Avion> avioni;

        public List<Avion> Avioni
        {
            get { return avioni; }
            set { this.avioni = value; }
        }
        */
        BaznaKlasa baznaKlasa;

        public PretragaOstalo()
        {
            BaznaKlasa baznaKlasa = new BaznaKlasa();
        }
        
        public PretragaOstalo(BaznaKlasa baznaKlasa)
        {
            this.baznaKlasa = baznaKlasa;
        }

        List<Avion> Ipretraga<Avion>.nadi(Avion avion)
        {
            List<Avion> slobodniAvioni = new List<Avion>();
            for (int i = 0; i < baznaKlasa.Avioni.Count; i++)
            {
                if (avion.Vrsta.Equals(baznaKlasa.Avioni[i].Vrsta) && avion.BrojSjedista == baznaKlasa.Avioni[i].BrojSjedista)
                {
                    slobodniAvioni.Add(baznaKlasa.Avioni[i]);
                }
            }
            return slobodniAvioni;
        }

    }
}
