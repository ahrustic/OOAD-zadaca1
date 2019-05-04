using System;
using System.Collections.Generic;
using System.Text;
using MojDLL;

namespace OOADWings
{
    class StraniDrzavljanin : Klijent
    {
        private String grad;
        private Drzava drzava;
        public int kaucija = 100;

    

        public String Grad
        {
            get { return grad; }
            set { grad = value; }
        }


        public Drzava GetDrzava()
        {
            return drzava;
        }

        public void SetDrzava(Drzava value)
        {
            drzava = value;
        }

        public StraniDrzavljanin()
        {
            this.grad = "";
            this.SetDrzava(new Drzava());
        }

        public StraniDrzavljanin(String grad, Drzava drzava)
        { 
            this.grad = grad;
            this.SetDrzava(drzava);
        }

        public StraniDrzavljanin(string imeIPrezime, DateTime datumRodenja, string id) : base(imeIPrezime, datumRodenja, id)
        {
        }
    }
}

