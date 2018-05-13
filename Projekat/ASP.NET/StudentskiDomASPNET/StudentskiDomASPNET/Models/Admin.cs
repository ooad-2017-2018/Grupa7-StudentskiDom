using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDomASPNET.Models
{
    public class Admin : Osoba
    {
        public Admin(string ime, string prezime, string datumRodjenja, string username, string password, char pol) : base(ime, prezime, datumRodjenja, username, password, pol)
        {

        }

        public Admin() : base()
        {

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}