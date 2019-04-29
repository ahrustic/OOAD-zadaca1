using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class Avion
    {
        private String vrsta;
        private int brojSjedista;
        private String id;
        public Avion()
        {
            this.vrsta = "";
            this.brojSjedista = 0;
            this.id = "";
        }

        public Avion(string vrsta, int brojSjedista, string id)
        {
            this.vrsta = vrsta;
            this.brojSjedista = brojSjedista;
            if (id.Length == 9)
            {
                bool ispravno = true;
                for (int i = 0; i < id.Length; i++)
                {
                    if ((id[i] < '1' || (id[i] > '5' && id[i] < 'a') || id[i] > 'z'))
                    {
                        ispravno = false;
                        Console.WriteLine("Neispravan ID");
                        break;
                        
                    }
                }
                if (ispravno)
                {
                    this.id = id;
                }
            }
 
        }

        public String Id
        {
            get { return id; }
            set
            {
                if (value.Length == 9)
                {
                    bool ispravno = true;
                    for (int i = 0; i < value.Length; i++)
                    {
                        if ((value[i] < '1' || (value[i] > '5' && value[i] < 'a') || value[i] > 'z'))
                        {
                            ispravno = false;
                            Console.WriteLine("Neispravan ID");
                            break;
                        }
                    }
                    if (ispravno)
                    {
                        id = value;
                    }
                }
            }
        }

        public int BrojSjedista { get { return brojSjedista; } set { brojSjedista = value; } }

        public String Vrsta { get { return vrsta; } set { vrsta = value; } }

    }
}
