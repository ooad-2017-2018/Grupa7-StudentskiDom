using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Klase
{
    public class Student : Osoba {
        
        private int brojSobe;
        private bool teretana;
        private string kanton;

        public Student() : base() 
        {

        }

        public Student(string ime, string prezime, string datumRodjenja, string username, string password, char pol, int brojSobe, bool teretana, string kanton) : base(ime,prezime,datumRodjenja,username,password,pol)
        {
            this.brojSobe = brojSobe;
            this.teretana = teretana;
            this.kanton = kanton;
        }

        public int dajBrojSobe()
        {
            return brojSobe;
        }

        public int BrojSobe { get; set; }

        public string Kanton { get; set; }

        public bool Teretana { get; set; }

        public string dajKanton()
        {
            return kanton;
        }

        public override string ToString()
        {
            return base.ToString()+", soba: "+brojSobe.ToString()+", kanton: "+kanton;
        }

    }
}
