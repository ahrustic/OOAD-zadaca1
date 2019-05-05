using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class PretragaID:Ipretraga<Avion>
    {
        
        BaznaKlasa baznaKlasa;
        
        public PretragaID()
        {
            BaznaKlasa baznaKlasa = new BaznaKlasa();
        }
        
        public PretragaID(BaznaKlasa baznaKlasa)
        {
            this.baznaKlasa = baznaKlasa;
        }

        List<Avion> Ipretraga<Avion>.nadi(Avion avion)
        {
            List<Avion> slobodniAvioni = new List<Avion>();
            
            for (int i = 0; i < baznaKlasa.Avioni.Count; i++)
            {
                if (avion.Id.Equals(baznaKlasa.Avioni[i].Id))
                {
                    slobodniAvioni.Add(baznaKlasa.Avioni[i]);
                }
            }
            return slobodniAvioni;
        }
    }
}

