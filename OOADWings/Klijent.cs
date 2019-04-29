using System;

namespace OOADWings
{
    class Klijent
    {
        private string imeIPrezime;
        private DateTime datumRodenja;
        private string id;

        public string ImeIPrezime { get { return imeIPrezime; } set { imeIPrezime = value; } }
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

        public string Id
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
                    Console.WriteLine("Neispravan ID");
                }
            }
        }
    }
}

