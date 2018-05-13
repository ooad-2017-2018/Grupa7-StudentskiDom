using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDomASPNET.Models
{
    public class Uposlenik : Osoba
    {
        protected string bankovniRacun;
        protected double plata;

        public Uposlenik()
        {

        }

        public Uposlenik(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun) : base(ime, prezime, datumRodjenja, username, password, pol)
        {
            this.bankovniRacun = bankovniRacun;
            this.plata = plata;
        }

        public double Plata { get; set; }

        public string BankovniRacun { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", plata: " + plata.ToString() + ", bankovni račun: " + bankovniRacun;
        }
    }
}