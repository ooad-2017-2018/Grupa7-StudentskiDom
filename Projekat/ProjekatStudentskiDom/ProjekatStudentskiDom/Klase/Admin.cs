using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Klase
{
    public class Admin : Osoba
    {

        public Admin(string ime, string prezime, string datumRodjenja, string username, string password) : base(ime,prezime,datumRodjenja,username,password)
        {

        }
    }
}
