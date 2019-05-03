using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class StraniDrzavljanin : Klijent
    {
        private String grad;
        private Drzava drzava;

        public String Grad
        {
            get { return grad; }
            set { grad = value; }
        }

        public Drzava Drzava
        {
            get { return drzava; }
            set { drzava = value; }
        }

        public StraniDrzavljanin()
        {
            this.grad = "";
            this.drzava = new Drzava();
        }

        public StraniDrzavljanin(String grad, Drzava drzava)
        { 
            this.grad = grad;
            this.drzava = drzava;
        }

        public StraniDrzavljanin(string imeIPrezime, DateTime datumRodenja, string id) : base(imeIPrezime, datumRodenja, id)
        {
        }
    }
}

