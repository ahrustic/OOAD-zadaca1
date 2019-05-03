using System;
using System.Collections.Generic;
using System.Text;

namespace OOADWings
{
    class LetUInostranstvo:PutnickiAvion
    {
        private List<Drzava> drzave;

        public List<Drzava> Drzave
        {
            get { return drzave; }
            set { drzave = value; }
        }

        public LetUInostranstvo(string vrsta, int brojSjedista, string id) : base(vrsta, brojSjedista, id)
        {
        }
    }
}
