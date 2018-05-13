using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDomASPNET.Models
{
    public class Konobar : Uposlenik
    {
        public Konobar() : base()
        {

        }
        public Konobar(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun) : base(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun)
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}