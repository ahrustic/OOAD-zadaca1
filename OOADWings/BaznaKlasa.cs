using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class BaznaKlasa
    {
        private List<Klijent> klijenti = new List<Klijent>();
        private List<Avion> avioni = new List<Avion>();

        public List<Avion> Avioni
        {
            get { return avioni; }
            set { avioni = value; }
        }

        public List<Klijent> Klijenti
        {
            get { return klijenti; }
            set { klijenti = value; }
        }

        public BaznaKlasa()
        {
            Klijent k = new Klijent("Mujo Mujic", new DateTime(), "123451");
            klijenti.Add(k);
            Avion avion = new Avion("masina", 123, "aaaaaaaaa");
            avioni.Add(avion);
        }

        
    }
}
