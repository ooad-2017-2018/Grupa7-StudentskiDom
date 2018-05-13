using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDomASPNET.Models
{
    public class Blagajnik : Uposlenik
    {
        public Blagajnik() : base()
        {

        }

        public Blagajnik(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun) : base(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}