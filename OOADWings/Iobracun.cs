using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    interface Iobracun
    {
        
        /*public double Metoda(Avion avion, Klijent klijent, DateTime datumIznamljivanja)
        {
            double iznosZaPlacanje;

            return iznosZaPlacanje;
        }*/

        double metoda(BaznaKlasa bazna, String id);
    }
}
