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
        protected char pol;


        protected Osoba(string ime, string prezime, string datumRodjenja, string username, string password, char pol)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.username = username;
            this.password = password;
            this.pol = pol;
        }

        public string Ime { get { return ime; } set { this.ime = value; } }
        public string Prezime { get { return prezime; } set { this.prezime = value; } }
        public string DatumRodjenja { get { return datumRodjenja; } set { this.datumRodjenja = value; } }
        public string Username { get { return username; } set { this.username = value; } }
        public string Password { get { return password; } set { this.password = value; } }
        public string Jmbg { get { return jmbg; } set { this.jmbg = value; } }
        public char Pol { get { return pol; } set { this.pol = value; } }

        public override string ToString()
        {
            return ime+" "+prezime+", datum rođenja: "+datumRodjenja+", username: "+username+", password: "+password;
        }
    }
}
