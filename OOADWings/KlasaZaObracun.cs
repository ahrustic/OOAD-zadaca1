using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class KlasaZaObracun: Iobracun
    {
        private DateTime pocetniDatum;
        private DateTime krajnjiDatum;

        public DateTime PocetniDatum
        {
            get { return pocetniDatum; }
            set { pocetniDatum = value; }
        }

        public DateTime KrajnjiDatum
        {
            get { return krajnjiDatum; }
            set {
                bool ispravno = true;
                if (krajnjiDatum.Year < pocetniDatum.Year) ispravno = false;
                if (krajnjiDatum.Year == pocetniDatum.Year && krajnjiDatum.Month < pocetniDatum.Month) ispravno = false;
                if (krajnjiDatum.Year == pocetniDatum.Year && krajnjiDatum.Month == pocetniDatum.Month && krajnjiDatum.Day < pocetniDatum.Day) ispravno = false;
                if (ispravno)
                { krajnjiDatum = value; }
                
            }
        }

        public KlasaZaObracun(DateTime pocetniDatum, DateTime krajnjiDatum)
        {
            this.pocetniDatum = pocetniDatum;
            this.KrajnjiDatum = krajnjiDatum;
        }

        public KlasaZaObracun()
        {
            pocetniDatum = new DateTime();
            krajnjiDatum = new DateTime();
        }

        public double metoda(BaznaKlasa baznaKlasa, String id) {
            double iznosZaPlacanje = 0.0;
            int daniIzmedu = (krajnjiDatum - pocetniDatum).Days;
            int pozicija = 0;
            for (int i = 0; i < baznaKlasa.Klijenti.Count; i++)
            {
                if (baznaKlasa.Klijenti[i].Id.Equals(id))
                {

                    pozicija = i;
                    break;
                }
            }
            if (baznaKlasa.Klijenti[pozicija].Avion is LetUnutarZemlje)
            {
                iznosZaPlacanje = daniIzmedu * 120;
                if (baznaKlasa.Klijenti[pozicija].DatumIznamljivanja.DayOfWeek.Equals("Saturday") || baznaKlasa.Klijenti[pozicija].DatumIznamljivanja.DayOfWeek.Equals("Sunday")) iznosZaPlacanje += 500;
                if (baznaKlasa.Klijenti[pozicija] is DomaciDrzavljanin) iznosZaPlacanje = iznosZaPlacanje - 50;
                else if (baznaKlasa.Klijenti[pozicija] is StraniDrzavljanin) iznosZaPlacanje = iznosZaPlacanje - 100;
            }
            else if (baznaKlasa.Klijenti[pozicija].Avion is LetUInostranstvo)
            {
                iznosZaPlacanje = daniIzmedu * 200;
                if (baznaKlasa.Klijenti[pozicija].DatumIznamljivanja.DayOfWeek.Equals("Saturday") || baznaKlasa.Klijenti[pozicija].DatumIznamljivanja.DayOfWeek.Equals("Sunday")) iznosZaPlacanje += 1000;
                if (baznaKlasa.Klijenti[pozicija] is DomaciDrzavljanin) iznosZaPlacanje = iznosZaPlacanje - 50;
                else if (baznaKlasa.Klijenti[pozicija] is StraniDrzavljanin) iznosZaPlacanje = iznosZaPlacanje - 100;
            }
            else if (baznaKlasa.Klijenti[pozicija].Avion is TeretniAvion)
            {
                TeretniAvion tAvion = (TeretniAvion) baznaKlasa.Klijenti[pozicija].Avion;
                iznosZaPlacanje = daniIzmedu * 200 + (tAvion.Kapacitet * 1000) * 0.02;
                if (baznaKlasa.Klijenti[pozicija] is DomaciDrzavljanin) iznosZaPlacanje = iznosZaPlacanje - 50;
                else if (baznaKlasa.Klijenti[pozicija] is StraniDrzavljanin) iznosZaPlacanje = iznosZaPlacanje - 100;
            }
            return iznosZaPlacanje;
        }
    }
}
