using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatStudentskiDom.Klase
{
    public class Student : Osoba {

        private static int id = 1;
        private int brojSobe;
        private bool teretana;
        private string kanton;
        private int studentID;

        public Student(string ime, string prezime, string datumRodjenja, string username, string password, char pol, int brojSobe, bool teretana, string kanton) : base(ime,prezime,datumRodjenja,username,password,pol)
        {
            studentID = id;
            id++;
            this.brojSobe = brojSobe;
            this.teretana = teretana;
            this.kanton = kanton;
        }

        public int dajBrojSobe()
        {
            return brojSobe;
        }

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
