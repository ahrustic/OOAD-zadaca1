using System;

namespace OOADWings
{
    class Drzava
    {
        private String naziv;
        private int brojStanovnika;
        private String id;

        public String Naziv { get { return naziv; } set { naziv = value; } }
        public int BrojStanovnika { get; set; }
        public String Id { get; set; }

        public Drzava()
        {
            this.naziv = "";
            this.brojStanovnika = 1;
            this.id = "";
        }

        public Drzava(string naziv, int brojStanovnika, string id)
        {
            this.naziv = naziv;
            this.brojStanovnika = brojStanovnika;
            this.id = id;
        }
    }
}
