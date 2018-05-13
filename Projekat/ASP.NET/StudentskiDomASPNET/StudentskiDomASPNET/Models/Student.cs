using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StudentskiDomASPNET.Models
{
    public class Student : Osoba
    {
        [ScaffoldColumn(false)]
        private string studentId;
        [Required]
        [Range(100,999,ErrorMessage ="Sobe imaju vrijednost 100-999")]
        private int brojSobe;
        private bool teretana;
        [Required]
        private string kanton;

        public string StudentId { get; set; }

        public Student() : base()
        {

        }

        public Student(string ime, string prezime, string datumRodjenja, string username, string password, char pol, int brojSobe, bool teretana, string kanton) : base(ime, prezime, datumRodjenja, username, password, pol)
        {
            this.brojSobe = brojSobe;
            this.teretana = teretana;
            this.kanton = kanton;
        }

        public int BrojSobe { get; set; }

        public string Kanton { get; set; }

        public bool Teretana { get; set; }

        public override string ToString()
        {
            return base.ToString() + ", soba: " + brojSobe.ToString() + ", kanton: " + kanton;
        }
    }
}