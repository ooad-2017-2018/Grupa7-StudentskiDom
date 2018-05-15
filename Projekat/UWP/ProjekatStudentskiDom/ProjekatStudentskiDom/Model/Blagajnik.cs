using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Klase
{
    public class Blagajnik : Uposlenik
    {

        public string BlagajnikId { get; set; }

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
