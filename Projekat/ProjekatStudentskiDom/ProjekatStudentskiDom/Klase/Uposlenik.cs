using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom
{
    public class Uposlenik : Osoba {

        private static int id = 1;
        private string bankovniRacun;
        private double plata;
        private int uposleniID;

        public Uposlenik(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun) : base(ime,prezime,datumRodjenja,username,password,pol)
        {
            uposleniID = id;
            id++;
            this.bankovniRacun = bankovniRacun;
            this.plata = plata;
        }
        
        public double dajPlatu()
        {
            return plata;
        }

        public string dajBankovniRacun()
        {
            return bankovniRacun;
        }
    }
}
