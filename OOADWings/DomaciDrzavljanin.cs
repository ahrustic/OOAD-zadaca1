using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class DomaciDrzavljanin : Klijent
    {
        public int kaucija = 50;
        public DomaciDrzavljanin()
        {
        }

        public DomaciDrzavljanin(string imeIPrezime, DateTime datumRodenja, string id) : base(imeIPrezime, datumRodenja, id)
        {
            ImeIPrezime = imeIPrezime;
            DatumRodenja = datumRodenja;
            Id = id;
        }
    }
}
