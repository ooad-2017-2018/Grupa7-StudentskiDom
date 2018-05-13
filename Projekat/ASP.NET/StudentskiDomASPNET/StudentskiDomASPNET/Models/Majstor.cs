using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentskiDomASPNET.Models
{
    public class Majstor : Uposlenik
    {

        public string MajstorId { get; set; }
        public Majstor() : base()
        {

        }

        private string tipMajstora;
        public Majstor(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun, string tipMajstora) : base(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun)
        {
            this.tipMajstora = tipMajstora;
        }

        public string Tip { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", tip: " + tipMajstora;
        }
    }
}