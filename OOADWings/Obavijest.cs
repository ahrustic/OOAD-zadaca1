using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class Obavijest
    {
        String poruka;
        String sifraKlijenta;
        DateTime datumIVrijemeObavijesti;

        public string Poruka { get { return poruka; } set { poruka = value; } }
        public string SifraKLijenta { get { return sifraKlijenta; } set { sifraKlijenta = value; } }
        public  DateTime DatumIVrijemeObavijesti { get { return datumIVrijemeObavijesti; } set { datumIVrijemeObavijesti = value; } }

        public Obavijest()
        {
            poruka = "";
            sifraKlijenta = "";
            datumIVrijemeObavijesti = new DateTime();
        }

        public Obavijest(string poruka, string sifraKlijenta, DateTime datumIVrijemeObavijesti)
        {
            this.poruka = poruka;
            this.sifraKlijenta = sifraKlijenta;
            this.datumIVrijemeObavijesti = datumIVrijemeObavijesti;
        }
    }
}
