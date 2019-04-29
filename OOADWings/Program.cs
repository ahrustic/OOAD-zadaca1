using System;
using System.Collections.Generic;

namespace OOADWings
{
    class Program
    {
        static void Main(string[] args)
        {
            BaznaKlasa baznaKlasa = new BaznaKlasa();
            Avion avionZaPretragu = new Avion();
            PretragaID pretragaPoID = new PretragaID();
            PretragaOstalo pretragaOstalo = new PretragaOstalo();
            Klijent: Console.WriteLine("Unesite identifikacijski broj: ");
            String id = Convert.ToString(Console.ReadLine());
            if (id.Length != 6)
            {
                Console.WriteLine("Neispravan ID");
                goto Klijent;
            }
            else
            {
                bool postojiKlijent = false;
                for (int i = 0; i < baznaKlasa.Klijenti.Count; i++)
                {
                    if (baznaKlasa.Klijenti[i].Id.Equals(id))
                    {
                        postojiKlijent = true;
                    }
                }
                if (!postojiKlijent)
                {
                    Console.WriteLine("Klijent sa sljedećim identifikacijski broj ne postoji {0}.", id);
                    goto Klijent;
                }
                else
                {

                    Console.WriteLine("Izaberite vrstu pretrage (1 - pretraga po ID, 2 - pretraga po vrsti i broju sjedista)");
                    String vrstaPretrage = Convert.ToString(Console.ReadLine());
                    //Pocetak pretrage preko ID
                    if (vrstaPretrage.Equals("1"))
                    {
                    IDAviona: bool ispravanIdAviona = true;
                        Console.WriteLine("Unesite ID aviona (potrebno je da duzina bude 9 karaktera koja se sastoji od malih slova i brojeva od 1 do 5): ");
                        String idAviona = Convert.ToString(Console.ReadLine());
                        if (idAviona.Length == 9)
                        {
                            for (int i = 0; i < idAviona.Length; i++)
                            {
                                if ((idAviona[i] < '1' || (idAviona[i] > '5' && idAviona[i] < 'a') || idAviona[i] > 'z'))
                                {
                                    ispravanIdAviona = false;
                                    break;
                                }
                            }
                        }
                        if (idAviona.Length != 9) ispravanIdAviona = false;
                        if (!ispravanIdAviona)
                        {
                            Console.WriteLine("Neispravan ID!");
                            goto IDAviona;
                        }
                        else
                        {
                            avionZaPretragu.Id = idAviona;
                            // Console.WriteLine("ID {0}", avionZaPretragu.Id);
                            bool postojiAvion = pretragaPoID.nadi(avionZaPretragu);
                            if (postojiAvion) Console.WriteLine("Avion postoji!");
                            else Console.WriteLine("Avion ne postoji!");
                        }
                    }
                    //Pocetak pretrage preko ostalog
                    if (vrstaPretrage.Equals("2"))
                    {

                        Console.WriteLine("Unesite vrtu aviona: ");
                        String vrstaAviona = Convert.ToString(Console.ReadLine());
                    BrojSjedistaUAvionu: bool brojSjedista = true;
                        Console.WriteLine("Unesite broj sjedista: ");
                        int brojSjedistaAviona;
                        try
                        {
                            brojSjedistaAviona = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Neispravan broj sjedista!");
                            goto BrojSjedistaUAvionu;
                        }

                        avionZaPretragu.BrojSjedista = brojSjedistaAviona;
                        avionZaPretragu.Vrsta = vrstaAviona;
                        bool postojiAvion = pretragaOstalo
                            .nadi(avionZaPretragu);
                        if (postojiAvion) Console.WriteLine("Avion postoji!");
                        else Console.WriteLine("Avion ne postoji!");

                    }
                }
            }
            Console.ReadKey();
        }
    }
}
