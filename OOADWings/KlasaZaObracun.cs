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

        public void metoda() {
        }
    }
}
