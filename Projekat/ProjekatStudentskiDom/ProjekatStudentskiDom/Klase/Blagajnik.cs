using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Klase
{
    public class Blagajnik : Uposlenik
    {
        public Blagajnik(string ime, string prezime, string datumRodjenja, string username, string password, double plata, string bankovniRacun) : base(ime, prezime, datumRodjenja, username, password, plata, bankovniRacun)
        {

        }
    }
}
