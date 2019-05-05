using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class BaznaKlasa
    {
        private List<Klijent> klijenti = new List<Klijent>();
        private List<Avion> avioni = new List<Avion>();
        private List<Obavijest> obavijesti = new List<Obavijest>();

        public List<Obavijest> Obavijesti
        {
            get { return obavijesti; }
            set { obavijesti = value; }
        }

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
        }

        public void dodajNoviAvion(Avion a)
        {
            avioni.Add(a);
        }

        public void dodajNovogKlijenta(Klijent k)
        {
            klijenti.Add(k);
        }

    }
}
