using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom {
    public class Osoba {

        protected string ime;
        protected string prezime;
        protected string datumRodjenja;
        protected string username;
        protected string password;
        protected string jmbg;



        protected Osoba(string ime, string prezime, string datumRodjenja, string username, string password)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.username = username;
            this.password = password;
        }

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string DatumRodjenja { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Jmbg { get; set; }
    }
}
