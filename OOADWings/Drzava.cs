using System;

namespace OOADWings
{
    class Drzava
    {
        private String naziv;
        private int brojStanovnika;

        public String Naziv { get { return naziv; } set { naziv = value; } }
        public int BrojStanovnika { get; set; }

        public Drzava()
        {
            this.naziv = "";
            this.brojStanovnika = 1;
        }

        public Drzava(string naziv, int brojStanovnika)
        {
            this.naziv = naziv;
            this.brojStanovnika = brojStanovnika;
        }
    }
}
