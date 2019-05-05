using System;
using System.Collections.Generic;
using System.Linq;
using MojDLL;

namespace OOADWings
{
  
    class Program
    {
        public delegate void MojDelegat(string arg1, string arg2, BaznaKlasa bazna);
        
        public static void printajNaKonzoluIDodajUListu(string poruka, string id, BaznaKlasa baznaKlasa)
        {
            Obavijest obavijest = new Obavijest();
            obavijest.Poruka = poruka;
            obavijest.SifraKLijenta = id;
            obavijest.DatumIVrijemeObavijesti = DateTime.Now;
            baznaKlasa.Obavijesti.Add(obavijest);

            Console.WriteLine("Poruka glasi: {0}", poruka);

        }


        static void Main(string[] args)
        {
            BaznaKlasa baznaKlasa = new BaznaKlasa();
            MojDelegat delegat = printajNaKonzoluIDodajUListu;

            Console.WriteLine("MENI");
            for (; ; )
            {

            Meni: Console.WriteLine("Unesite: \n 1 - unos vozila \n 2 - unos klijenta \n 3 - iznajmljivanje \n 4 - povrat aviona i placanje \n 5 - ispis liste obavijesti \n 6 - prekid programa");
                String meni = Convert.ToString(Console.ReadLine());

                if (meni.Equals("1"))
                {
                    String vrsta;
                    int brojSjedista;
                    String idAvionaDodanog;
                    bool ispravanId = true;

                    Console.WriteLine("Unesite podatke o avionu!");
                    Console.WriteLine("Unesite vrstu aviona (pu - putnički unutar zemlje, pi - putnički u inostranstvo, t - teretni: ");
                    vrsta = Convert.ToString(Console.ReadLine());

                brSjedista: Console.WriteLine("Unesite broj sjedista: ");
                    try
                    {
                        brojSjedista = Convert.ToInt32(Console.ReadLine());
                        if (brojSjedista <= 0)
                        {
                            Console.WriteLine("Neispravan broj sjedista! Pokusajte ponovo!");
                            goto brSjedista;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Neispravan broj sjedista! Pokusajte ponovo!");
                        goto brSjedista;
                    }


                IDAvionaDodanog: Console.WriteLine("Unesite ID aviona (potrebno je da duzina bude 9 karaktera koja se sastoji od malih slova i brojeva od 1 do 5):");
                    idAvionaDodanog = Convert.ToString(Console.ReadLine());
                    if (idAvionaDodanog.Length == 9)
                    {
                        for (int i = 0; i < idAvionaDodanog.Length; i++)
                        {
                            if ((idAvionaDodanog[i] < '1' || (idAvionaDodanog[i] > '5' && idAvionaDodanog[i] < 'a') || idAvionaDodanog[i] > 'z'))
                            {
                                ispravanId = false;
                                break;
                            }
                        }
                    }
                    if (idAvionaDodanog.Length != 9) ispravanId = false;
                    if (!ispravanId)
                    {
                        Console.WriteLine("Neispravan identifikacioni broj aviona! Pokusajte ponovo!");
                        ispravanId = true;
                        goto IDAvionaDodanog;
                    }

                    if (vrsta.Equals("pu"))
                    {
                        baznaKlasa.dodajNoviAvion(new LetUnutarZemlje(vrsta, brojSjedista, idAvionaDodanog));
                        Console.WriteLine("Dodan putnicki (unutar zemlje) avion!");
                    }
                    else if (vrsta.Equals("pi"))
                    {
                        LetUInostranstvo noviAvion = new LetUInostranstvo(vrsta, brojSjedista, idAvionaDodanog);
                        Console.WriteLine("Unesite drzave u koje avion moze ici: ");
                        List<Drzava> drzave = new List<Drzava>();
                        for (; ; )
                        {
                            Console.WriteLine("Unesite naziv drzave (0 za prekid): ");
                            String naziv = Convert.ToString(Console.ReadLine());
                            if (naziv.Equals("0")) break;
                            else
                            {
                              broj:  Console.WriteLine("Unesite broj stanovnika drzave: ");
                                int brojStanovnika = Convert.ToInt32(Console.ReadLine());
                                if (brojStanovnika <= 0) {
                                    Console.WriteLine("Neispravan broj stanovnika! Pokusajte ponovo!");
                                    goto broj;
                                }
                                drzave.Add(new Drzava(naziv, brojStanovnika));
                            }

                        }
                        noviAvion.Drzave = drzave;
                        baznaKlasa.dodajNoviAvion(noviAvion);
                        Console.WriteLine("Dodan putnicki (u inostranstvo) avion!");
                    }

                    else if (vrsta.Equals("t"))
                    {
                        TeretniAvion teretniAvion = new TeretniAvion(vrsta, brojSjedista, idAvionaDodanog);
                        kapacitet: Console.WriteLine("Unesite kapacitet teretnog aviona: ");
                        Double kapacitet = Convert.ToDouble(Console.ReadLine());
                        if (kapacitet <= 0) { Console.WriteLine("Pogresan podatak! "); goto kapacitet; }
                        else { teretniAvion.Kapacitet = kapacitet; }

                        baznaKlasa.dodajNoviAvion(teretniAvion);
                        Console.WriteLine("Dodan teretni avion!");
                    }
                       

                }

                else if (meni.Equals("2"))
                {
                    String naziv;
                    DateTime datum;
                    String idKlijenta;
                    String vrstaKlijenta;


                    Console.WriteLine("Unesite podatke o klijentu ");
                    Console.WriteLine("Unesite 1 za domaceg klijenta, a 2 za stranog klijenta: ");
                    vrstaKlijenta = Convert.ToString(Console.ReadLine());
                imeKlijenta: Console.WriteLine("Unesite ime i prezime klijenta: ");

                    naziv = Convert.ToString(Console.ReadLine());
                    bool ispravanNaziv = true;
                    for (int i = 0; i < naziv.Length; i++)
                    {
                        if (naziv[i] < 'A' || (naziv[i] > 'Z' && naziv[i] < 'a') || naziv[i] > 'z') ispravanNaziv = false;
                    }
                    if (!ispravanNaziv) goto imeKlijenta;

                    danRodenja: Console.WriteLine("Unesite dan rodenja: ");
                    int danRodenja = 0;
                    try
                    {
                        danRodenja = Convert.ToInt32(Console.ReadLine());
                        if (danRodenja <= 0 || danRodenja > 31) {
                            Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                            goto danRodenja;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                        goto danRodenja;
                    }
                mjesecRodenja: Console.WriteLine("Unesite mjesec rodenja: ");
                    int mjesecRodenja = 0;
                    try
                    {
                        mjesecRodenja = Convert.ToInt32(Console.ReadLine());
                        if (mjesecRodenja <= 0 || mjesecRodenja > 12)
                        {
                            Console.WriteLine("Neispravan mjesec! Unesite ponovo: ");
                            goto mjesecRodenja;
                        }  
                        if ((mjesecRodenja == 2 || mjesecRodenja == 4 || mjesecRodenja == 6 || mjesecRodenja == 9 || mjesecRodenja == 11) && danRodenja == 31)
                        {
                            Console.WriteLine("Ovaj mjesec nema 31 dan! Unesite ponovo dan i mjesec: ");
                            goto danRodenja;
                        }
                        if (mjesecRodenja == 2 && danRodenja > 29)
                        {
                            Console.WriteLine("Provjerite unos! Unesite ponovo dan i mjesec: ");
                            goto danRodenja;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Neispravna forma mjeseca! Unesite ponovo: ");
                        goto mjesecRodenja;
                    }
                godinaRodenja: Console.WriteLine("Unesite godinu rodenja: ");
                    int godinaRodenja = 0;
                    bool prestupna = false;
                    try
                    {
                        godinaRodenja = Convert.ToInt32(Console.ReadLine());
                        if (godinaRodenja <= 999) {
                            Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                            goto godinaRodenja;
                        }
                        if (!((godinaRodenja % 4 == 0) && (godinaRodenja % 100 != 0)) || (godinaRodenja % 400 == 0)) prestupna = true;
                        if (!prestupna && mjesecRodenja == 2 && danRodenja < 28)
                        {
                            Console.WriteLine("Provjerite unos! Unesite ponovo dan,mjesec i godinu: ");
                            goto danRodenja;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                        goto godinaRodenja;
                    }

                    datum = new DateTime(godinaRodenja, mjesecRodenja, danRodenja);
                ID: Console.WriteLine("Unesite identifikacioni broj (6 karaktera): ");
                    idKlijenta = Convert.ToString(Console.ReadLine());

                    if (idKlijenta.Length != 6)
                    {
                        Console.WriteLine("Neispravan ID klijenta! Unesite ponovo: ");
                        goto ID;
                    }

                    if (vrstaKlijenta.Equals("1"))
                    {
                        baznaKlasa.Klijenti.Add(new DomaciDrzavljanin(naziv, datum, idKlijenta));
                        Console.WriteLine("Klijent dodan!");
                    }
                    else if (vrstaKlijenta.Equals("2"))
                    {
                        StraniDrzavljanin straniDrzavljanin = new StraniDrzavljanin(naziv, datum, idKlijenta);
                        Console.WriteLine("Unesite naziv drzave: ");
                        String drzava = Convert.ToString(Console.ReadLine());
                        br: Console.WriteLine("Unesite broj stanovnika drzave: ");
                        int brojStanovnika = Convert.ToInt32(Console.ReadLine());
                        if (brojStanovnika <= 0) { Console.WriteLine("Pogresan broj stanovnika!"); goto br; }
                        Console.WriteLine("Unesite naziv grada: ");
                        String grad = Convert.ToString(Console.ReadLine());
                        straniDrzavljanin.SetDrzava(new Drzava(drzava, brojStanovnika));
                        straniDrzavljanin.Grad = grad;
                        baznaKlasa.Klijenti.Add(straniDrzavljanin);
                        Console.WriteLine("Klijent dodan!");
                    }

                }

                else if (meni.Equals("3"))
                {
                    Avion avionZaPretragu = new Avion();
                    Ipretraga<Avion> pretragaPoID = new PretragaID(baznaKlasa);
                    Ipretraga<Avion> pretragaOstalo = new PretragaOstalo(baznaKlasa);
                    bool ispravanIdAviona = true;
                    DateTime pocetniDatumIznajmljivanja;
                    DateTime krajnjiDatumIznajmljivanja;
                    Klijent klijent = new Klijent();
                    int pozicijaKlijenta = 0;

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
                                klijent = baznaKlasa.Klijenti[i];
                                pozicijaKlijenta = i;
                                break;
                            }
                        }
                        if (!postojiKlijent)
                        {
                            Console.WriteLine("Klijent sa sljedećim identifikacijski broj ne postoji {0}. Unesite 1 za ponovni unos, 2 za povratak na meni! ", id);
                            String izbor = Convert.ToString(Console.ReadLine());
                            if (izbor.Equals("1")) { goto Klijent; }
                            else if (izbor.Equals("2")) goto Meni;
                        }
                        else
                        {
                            Console.WriteLine("Izaberite vrstu pretrage (1 - pretraga po ID, 2 - pretraga po vrsti i broju sjedista)");
                            String vrstaPretrage = Convert.ToString(Console.ReadLine());
                            //Pocetak pretrage preko ID
                            if (vrstaPretrage.Equals("1"))
                            {
                            IDAviona:
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
                                    ispravanIdAviona = true;
                                    goto IDAviona;
                                }
                                else
                                {

                                    avionZaPretragu = new Avion("", 0, idAviona);
                                    List <Avion> slobodniAvioni = pretragaPoID.nadi(avionZaPretragu);
                                    if (pretragaPoID.nadi(avionZaPretragu).Count() == 0)
                                    {
                                        Console.WriteLine("Avion ne postoji! Unesite tekst poruke za obavijest: ");
                                        String poruka = Convert.ToString(Console.ReadLine());
                                        printajNaKonzoluIDodajUListu(poruka, id, baznaKlasa);
                                        Console.WriteLine("Unesite 1 za ponovni unos ID aviona ili 2 za povratak na meni: ");
                                        String izbor = Convert.ToString(Console.ReadLine());
                                        if (izbor.Equals("1")) { goto IDAviona; }
                                        else if (izbor.Equals("2")) goto Meni;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Avioni koji su dostupni su:");
                                        for (int i = 0; i < pretragaPoID.nadi(avionZaPretragu).Count; i++)
                                        {
                                            Console.WriteLine("{0}: vrsta: {1}, broj sjedista: {2}, id: {3} \n", i + 1, pretragaPoID.nadi(avionZaPretragu)[i].Vrsta, pretragaPoID.nadi(avionZaPretragu)[i].BrojSjedista, pretragaPoID.nadi(avionZaPretragu)[i].Id);
                                        }

                                    Najam: Console.WriteLine("Unesite vrstu aviona koji zelite iznajmiti: ");
                                        String zeljenaVrstaAviona = Convert.ToString(Console.ReadLine());
                                        int pozicija = -1;
                                        for (int i = 0; i < pretragaPoID.nadi(avionZaPretragu).Count; i++)
                                        {
                                            if (pretragaPoID.nadi(avionZaPretragu)[i].Vrsta == zeljenaVrstaAviona)
                                            {
                                                pozicija = i;
                                                baznaKlasa.Klijenti[pozicijaKlijenta].Avion = pretragaPoID.nadi(avionZaPretragu)[i];
                                            }
                                        }

                                        if (pozicija == -1)
                                        {
                                            Console.WriteLine("Avion je zauzet! Unesite ponovo!");
                                            goto Najam;
                                        }

                                        else
                                        {
                                            
                                            Console.WriteLine("Unesite pocetni datum iznajmljivanja: ");
                                        pocetniDanIznajmljivanja: Console.WriteLine("Unesite dan iznajmljivanja: ");
                                            int danIznajmljivanja = 0;
                                            try
                                            {
                                                danIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                                                goto pocetniDanIznajmljivanja;
                                            }
                                        pocetniMjesecIznajmljivanja: Console.WriteLine("Unesite mjesec iznajmljivanja: ");
                                            int mjesecIznajmljivanja = 0;
                                            try
                                            {
                                                mjesecIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                                if ((mjesecIznajmljivanja == 2 || mjesecIznajmljivanja == 4 || mjesecIznajmljivanja == 6 || mjesecIznajmljivanja == 9 || mjesecIznajmljivanja == 11) && danIznajmljivanja == 31)
                                                {
                                                    Console.WriteLine("Ovaj mjesec nema 31 dan! Unesite ponovo dan i mjesec: ");
                                                    goto pocetniMjesecIznajmljivanja;
                                                }
                                                if (mjesecIznajmljivanja == 2 && danIznajmljivanja > 29)
                                                {
                                                    Console.WriteLine("Provjerite unos! Unesite ponovo dan i mjesec: ");
                                                    goto pocetniDanIznajmljivanja;
                                                }

                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Neispravna forma mjeseca! Unesite ponovo: ");
                                                goto pocetniMjesecIznajmljivanja;
                                            }
                                        pocetnaGodinaIznajmljivanja: Console.WriteLine("Unesite godinu iznajmljivanja: ");
                                            int godinaIznajmljivanja = 0;
                                            bool prestupna = false;
                                            try
                                            {
                                                godinaIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                                if (!((godinaIznajmljivanja % 4 == 0) && (godinaIznajmljivanja % 100 != 0)) || (godinaIznajmljivanja % 400 == 0)) prestupna = true;
                                                if (!prestupna && mjesecIznajmljivanja == 2 && danIznajmljivanja < 28)
                                                {
                                                    Console.WriteLine("Provjerite unos! Unesite ponovo dan,mjesec i godinu: ");
                                                    goto pocetniDanIznajmljivanja;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                                                goto pocetnaGodinaIznajmljivanja;
                                            }

                                            pocetniDatumIznajmljivanja = new DateTime(godinaIznajmljivanja, mjesecIznajmljivanja, danIznajmljivanja);
                                            klijent.DatumIznamljivanja = pocetniDatumIznajmljivanja;

                                            Console.WriteLine("Unesite krajnji datum iznajmljivanja: ");
                                        krajnjiDanIznajmljivanja: Console.WriteLine("Unesite dan iznajmljivanja: ");
                                            danIznajmljivanja = 0;
                                            try
                                            {
                                                danIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                                                goto krajnjiDanIznajmljivanja;
                                            }
                                        krajnjiMjesecIznajmljivanja: Console.WriteLine("Unesite mjesec iznajmljivanja: ");
                                            mjesecIznajmljivanja = 0;
                                            try
                                            {
                                                mjesecIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                                if ((mjesecIznajmljivanja == 2 || mjesecIznajmljivanja == 4 || mjesecIznajmljivanja == 6 || mjesecIznajmljivanja == 9 || mjesecIznajmljivanja == 11) && danIznajmljivanja == 31)
                                                {
                                                    Console.WriteLine("Ovaj mjesec nema 31 dan! Unesite ponovo dan i mjesec: ");
                                                    goto krajnjiMjesecIznajmljivanja;
                                                }
                                                if (mjesecIznajmljivanja == 2 && danIznajmljivanja > 29)
                                                {
                                                    Console.WriteLine("Provjerite unos! Unesite ponovo dan i mjesec: ");
                                                    goto krajnjiDanIznajmljivanja;
                                                }

                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Neispravna forma mjeseca! Unesite ponovo: ");
                                                goto krajnjiMjesecIznajmljivanja;
                                            }
                                        krajnjaGodinaIznajmljivanja: Console.WriteLine("Unesite godinu iznajmljivanja: ");
                                            godinaIznajmljivanja = 0;
                                            bool prestupnaGodina = false;
                                            try
                                            {
                                                godinaIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                                if (!((godinaIznajmljivanja % 4 == 0) && (godinaIznajmljivanja % 100 != 0)) || (godinaIznajmljivanja % 400 == 0)) prestupnaGodina = true;
                                                if (!prestupnaGodina && mjesecIznajmljivanja == 2 && danIznajmljivanja < 28)
                                                {
                                                    Console.WriteLine("Provjerite unos! Unesite ponovo dan,mjesec i godinu: ");
                                                    goto krajnjiDanIznajmljivanja;
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                                                goto krajnjaGodinaIznajmljivanja;
                                            }

                                            krajnjiDatumIznajmljivanja = new DateTime(godinaIznajmljivanja, mjesecIznajmljivanja, danIznajmljivanja);
                                            baznaKlasa.Klijenti[pozicijaKlijenta].DatumVracanja = krajnjiDatumIznajmljivanja;
                                            baznaKlasa.Klijenti[pozicijaKlijenta].DatumIznamljivanja = pocetniDatumIznajmljivanja;
                                            baznaKlasa.Klijenti[pozicijaKlijenta].Avion = pretragaPoID.nadi(avionZaPretragu)[pozicija];
                                            
                                        }
                                    }
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
                                List<Avion> slobodniAvioni = pretragaOstalo.nadi(avionZaPretragu);
                                if (pretragaOstalo.nadi(avionZaPretragu).Count() == 0)
                                {
                                    Console.WriteLine("Avion ne postoji! Unesite tekst poruke za obavijest: ");
                                    String poruka = Convert.ToString(Console.ReadLine());
                                    printajNaKonzoluIDodajUListu(poruka, id, baznaKlasa);
                                    Console.WriteLine("Unesite 1 za ponovni unos ID aviona ili 2 za povratak na meni: ");
                                    String izbor = Convert.ToString(Console.ReadLine());
                                    if (izbor.Equals("1")) { goto BrojSjedistaUAvionu; }
                                    else if (izbor.Equals("2")) goto Meni;
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Avioni koji su dostupni su:");
                                    for (int i = 0; i < pretragaOstalo.nadi(avionZaPretragu).Count; i++)
                                    {
                                        Console.WriteLine("{0}: vrsta: {1}, broj sjedista: {2}, id: {3} \n", i + 1, pretragaOstalo.nadi(avionZaPretragu)[i].Vrsta, pretragaOstalo.nadi(avionZaPretragu)[i].BrojSjedista, pretragaOstalo.nadi(avionZaPretragu)[i].Id);
                                    }

                                Najam: Console.WriteLine("Unesite vrstu aviona koji zelite iznajmiti: ");
                                    String zeljenaVrstaAviona = Convert.ToString(Console.ReadLine());
                                    int pozicija = -1;
                                    for (int i = 0; i < pretragaOstalo.nadi(avionZaPretragu).Count; i++)
                                    {
                                        if (pretragaOstalo.nadi(avionZaPretragu)[i].Vrsta == zeljenaVrstaAviona)
                                        {
                                            pozicija = i;
                                        }
                                    }

                                    if (pozicija == -1)
                                    {
                                        Console.WriteLine("Avion je zauzet! Unesite ponovo!");
                                        goto Najam;
                                    }

                                    else
                                    {

                                        Console.WriteLine("Unesite pocetni datum iznajmljivanja: ");
                                    pocetniDanIznajmljivanja: Console.WriteLine("Unesite dan iznajmljivanja: ");
                                        int danIznajmljivanja = 0;
                                        try
                                        {
                                            danIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                                            goto pocetniDanIznajmljivanja;
                                        }
                                    pocetniMjesecIznajmljivanja: Console.WriteLine("Unesite mjesec iznajmljivanja: ");
                                        int mjesecIznajmljivanja = 0;
                                        try
                                        {
                                            mjesecIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                            if ((mjesecIznajmljivanja == 2 || mjesecIznajmljivanja == 4 || mjesecIznajmljivanja == 6 || mjesecIznajmljivanja == 9 || mjesecIznajmljivanja == 11) && danIznajmljivanja == 31)
                                            {
                                                Console.WriteLine("Ovaj mjesec nema 31 dan! Unesite ponovo dan i mjesec: ");
                                                goto pocetniMjesecIznajmljivanja;
                                            }
                                            if (mjesecIznajmljivanja == 2 && danIznajmljivanja > 29)
                                            {
                                                Console.WriteLine("Provjerite unos! Unesite ponovo dan i mjesec: ");
                                                goto pocetniDanIznajmljivanja;
                                            }

                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Neispravna forma mjeseca! Unesite ponovo: ");
                                            goto pocetniMjesecIznajmljivanja;
                                        }
                                    pocetnaGodinaIznajmljivanja: Console.WriteLine("Unesite godinu iznajmljivanja: ");
                                        int godinaIznajmljivanja = 0;
                                        bool prestupna = false;
                                        try
                                        {
                                            godinaIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                            if (!((godinaIznajmljivanja % 4 == 0) && (godinaIznajmljivanja % 100 != 0)) || (godinaIznajmljivanja % 400 == 0)) prestupna = true;
                                            if (!prestupna && mjesecIznajmljivanja == 2 && danIznajmljivanja < 28)
                                            {
                                                Console.WriteLine("Provjerite unos! Unesite ponovo dan,mjesec i godinu: ");
                                                goto pocetniDanIznajmljivanja;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                                            goto pocetnaGodinaIznajmljivanja;
                                        }

                                        pocetniDatumIznajmljivanja = new DateTime(godinaIznajmljivanja, mjesecIznajmljivanja, danIznajmljivanja);


                                        Console.WriteLine("Unesite krajnji datum iznajmljivanja: ");
                                    krajnjiDanIznajmljivanja: Console.WriteLine("Unesite dan iznajmljivanja: ");
                                        danIznajmljivanja = 0;
                                        try
                                        {
                                            danIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                                            goto krajnjiDanIznajmljivanja;
                                        }
                                    krajnjiMjesecIznajmljivanja: Console.WriteLine("Unesite mjesec iznajmljivanja: ");
                                        mjesecIznajmljivanja = 0;
                                        try
                                        {
                                            mjesecIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                            if ((mjesecIznajmljivanja == 2 || mjesecIznajmljivanja == 4 || mjesecIznajmljivanja == 6 || mjesecIznajmljivanja == 9 || mjesecIznajmljivanja == 11) && danIznajmljivanja == 31)
                                            {
                                                Console.WriteLine("Ovaj mjesec nema 31 dan! Unesite ponovo dan i mjesec: ");
                                                goto krajnjiMjesecIznajmljivanja;
                                            }
                                            if (mjesecIznajmljivanja == 2 && danIznajmljivanja > 29)
                                            {
                                                Console.WriteLine("Provjerite unos! Unesite ponovo dan i mjesec: ");
                                                goto krajnjiDanIznajmljivanja;
                                            }

                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Neispravna forma mjeseca! Unesite ponovo: ");
                                            goto krajnjiMjesecIznajmljivanja;
                                        }
                                    krajnjaGodinaIznajmljivanja: Console.WriteLine("Unesite godinu rodenja: ");
                                        godinaIznajmljivanja = 0;
                                        bool prestupnaGodina = false;
                                        try
                                        {
                                            godinaIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                            if (!((godinaIznajmljivanja % 4 == 0) && (godinaIznajmljivanja % 100 != 0)) || (godinaIznajmljivanja % 400 == 0)) prestupnaGodina = true;
                                            if (!prestupnaGodina && mjesecIznajmljivanja == 2 && danIznajmljivanja < 28)
                                            {
                                                Console.WriteLine("Provjerite unos! Unesite ponovo dan,mjesec i godinu: ");
                                                goto krajnjiDanIznajmljivanja;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                                            goto krajnjaGodinaIznajmljivanja;
                                        }

                                        krajnjiDatumIznajmljivanja = new DateTime(godinaIznajmljivanja, mjesecIznajmljivanja, danIznajmljivanja);
                                        baznaKlasa.Klijenti[pozicijaKlijenta].DatumVracanja = krajnjiDatumIznajmljivanja;
                                        baznaKlasa.Klijenti[pozicijaKlijenta].DatumIznamljivanja = pocetniDatumIznajmljivanja;
                                        baznaKlasa.Klijenti[pozicijaKlijenta].Avion = pretragaOstalo.nadi(avionZaPretragu)[pozicija];
                                    }
                                }
                            }

                        }

                    }

                }
                else if (meni.Equals("4"))
                {
                    double iznosZaPlacanje = 0;
                    DateTime krajnjiDatumIznajmljivanja;
                    int danIznajmljivanja;
                    int mjesecIznajmljivanja;
                    int godinaIznajmljivanja;
                    Klijent klijent = new Klijent();
                    DateTime nultoVrijeme = new DateTime();
                    int pozicijaKlijenta = 0;

                klijent: Console.WriteLine("Unesite identifikacijski broj: ");
                    String id = Convert.ToString(Console.ReadLine());
                    if (id.Length != 6)
                    {
                        Console.WriteLine("Neispravan ID");
                        goto klijent;
                    }
                    else
                    {
                        bool postojiKlijent = false;
                        for (int i = 0; i < baznaKlasa.Klijenti.Count; i++)
                        {
                            if (baznaKlasa.Klijenti[i].Id.Equals(id))
                            {
                                postojiKlijent = true;
                                klijent = baznaKlasa.Klijenti[i];
                                pozicijaKlijenta = i;
                                break;
                            }
                        }
                        if (!postojiKlijent)
                        {
                            Console.WriteLine("Klijent sa sljedećim identifikacijski broj ne postoji {0}. Unesite 1 za ponovni unos, 2 za povratak na meni! ", id);
                            String izbor = Convert.ToString(Console.ReadLine());
                            if (izbor.Equals("1")) { goto klijent; }
                            else if (izbor.Equals("2")) goto Meni;
                        }


                        if (klijent.DatumIznamljivanja == nultoVrijeme) { Console.WriteLine("Klijent nije nista rezervisao!"); }
                        else
                        {
                            Console.WriteLine("Da li je promjenjen dan vracanja (odgovorite sa DA ili NE): ");
                            String promjena = Convert.ToString(Console.ReadLine());
                            if (promjena.Equals("DA"))
                            {
                                Console.WriteLine("Unesite krajnji datum iznajmljivanja: ");
                            krajnjiDanIznajmljivanja: Console.WriteLine("Unesite dan iznajmljivanja: ");
                                danIznajmljivanja = 0;
                                try
                                {
                                    danIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Neispravna forma dana! Unesite ponovo: ");
                                    goto krajnjiDanIznajmljivanja;
                                }
                            krajnjiMjesecIznajmljivanja: Console.WriteLine("Unesite mjesec iznajmljivanja: ");
                                mjesecIznajmljivanja = 0;
                                try
                                {
                                    mjesecIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                    if ((mjesecIznajmljivanja == 2 || mjesecIznajmljivanja == 4 || mjesecIznajmljivanja == 6 || mjesecIznajmljivanja == 9 || mjesecIznajmljivanja == 11) && danIznajmljivanja == 31)
                                    {
                                        Console.WriteLine("Ovaj mjesec nema 31 dan! Unesite ponovo dan i mjesec: ");
                                        goto krajnjiMjesecIznajmljivanja;
                                    }
                                    if (mjesecIznajmljivanja == 2 && danIznajmljivanja > 29)
                                    {
                                        Console.WriteLine("Provjerite unos! Unesite ponovo dan i mjesec: ");
                                        goto krajnjiDanIznajmljivanja;
                                    }

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Neispravna forma mjeseca! Unesite ponovo: ");
                                    goto krajnjiMjesecIznajmljivanja;
                                }
                            krajnjaGodinaIznajmljivanja: Console.WriteLine("Unesite godinu iznajmljivanja: ");
                                godinaIznajmljivanja = 0;
                                bool prestupnaGodina = false;
                                try
                                {
                                    godinaIznajmljivanja = Convert.ToInt32(Console.ReadLine());
                                    if (!((godinaIznajmljivanja % 4 == 0) && (godinaIznajmljivanja % 100 != 0)) || (godinaIznajmljivanja % 400 == 0)) prestupnaGodina = true;
                                    if (!prestupnaGodina && mjesecIznajmljivanja == 2 && danIznajmljivanja < 28)
                                    {
                                        Console.WriteLine("Provjerite unos! Unesite ponovo dan,mjesec i godinu: ");
                                        goto krajnjiDanIznajmljivanja;
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Neispravna forma godine! Unesite ponovo: ");
                                    goto krajnjaGodinaIznajmljivanja;
                                }

                                krajnjiDatumIznajmljivanja = new DateTime(godinaIznajmljivanja, mjesecIznajmljivanja, danIznajmljivanja);
                                baznaKlasa.Klijenti[pozicijaKlijenta].DatumVracanja = krajnjiDatumIznajmljivanja;
                            }
                            Iobracun obracun = new KlasaZaObracun(baznaKlasa.Klijenti[pozicijaKlijenta].DatumIznamljivanja, baznaKlasa.Klijenti[pozicijaKlijenta].DatumVracanja);
                            iznosZaPlacanje = obracun.metoda(baznaKlasa, id);
      
                            Console.WriteLine("Potrebno je platiti {0}KM! ", iznosZaPlacanje);
                        }

                    }
                }
                else if (meni.Equals("5"))
                {
                    if (baznaKlasa.Obavijesti.Count == 0) Console.WriteLine("Lista obavijesti je prazna!");
                    else
                    {
                        Console.WriteLine("Ispis liste obavijesti: ");
                        for (int i = 0; i < baznaKlasa.Obavijesti.Count; i++)
                        {
                            Console.WriteLine("{0}. Poruka: {1} \n ID klijenta: {2} \n Datum i vrijeme obavijesti: {3} \n", i+1, baznaKlasa.Obavijesti[i].Poruka, baznaKlasa.Obavijesti[i].SifraKLijenta, baznaKlasa.Obavijesti[i].DatumIVrijemeObavijesti);
                        }
                    }
                }
                else if (meni.Equals("6"))
                {
                    Console.WriteLine("Program završen!");
                    break;
                    Console.ReadKey();
                }
            }
        }
    }
}



//todo dodati da kada se iznajmi avion da se izbrise iz bazne liste i da se doda kod klijenta
//todo kada se avion vrati da se doda u listu u baznoj klasi, a izbrise kod klijenta
//todo provjeriti validaciju
//todo ispraviti dijagram klasa
//todo vratiti kauciju

