using System;

namespace OOADWings
{
    class Klijent
    {
        private String imeIPrezime;
        private DateTime datumRodenja;
        private String id;

        public String ImeIPrezime { get { return imeIPrezime; } set { imeIPrezime = value; } }
        public DateTime DatumRodenja { get { return datumRodenja; } set { datumRodenja = value; } }

        public Klijent()
        {
            this.imeIPrezime = "";
            this.datumRodenja = new DateTime();
            this.id = "";
        }

        public Klijent(string imeIPrezime, DateTime datumRodenja, String id)
        {
            this.imeIPrezime = imeIPrezime;
            this.datumRodenja = datumRodenja;
            if (id.Length == 6)
            {
                this.id = id;
            }
        }

        public String Id
        {
            get { return id; }
            set
            {
                if (value.Length == 6)
                {
                    id = value;
                }
                else
                {
                    id = "";
                }
            }
        }
    }
}

