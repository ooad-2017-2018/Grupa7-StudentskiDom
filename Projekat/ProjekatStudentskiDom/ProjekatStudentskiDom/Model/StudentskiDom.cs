using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace ProjekatStudentskiDom.Klase
{
    public class StudentskiDom
    {
        IMobileServiceTable<Admin> adminTableObj = App.mobileService.GetTable<Admin>();

        private Admin admin = new Admin("Rijad", "Pedljak", "19.07.1996", "rpedljak", "FLStudio11", 'M');
        private List<Student> studenti=new List<Student>();
        private List<Uposlenik> uposlenici = new List<Uposlenik>();
        private List<string> novosti = new List<string>();

        public StudentskiDom()
        {
            //admin = adminTableObj.LookupAsync("8e8df667-3a99-4b1a-a256-0a07c8841338");
        }

        public void dodajNovost(string novost)
        {
            novosti.Add(novost);
        }

        public List<string> dajNovosti()
        {
            return novosti;
        }

        public void dodajStudenta(string ime, string prezime, string datumRodjenja, string username, string password, char pol, int brojSobe, bool teretana, string kanton) {
            studenti.Add(new Student(ime, prezime, datumRodjenja, username, password, pol, brojSobe, teretana, kanton));
        }

        public void dodajBlagajnika(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun)
        {
            uposlenici.Add(new Blagajnik(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun));
        }

        public void dodajKuhara(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun)
        {
            uposlenici.Add(new Kuhar(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun));
        }

        public void dodajKonobara(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun)
        {
            uposlenici.Add(new Konobar(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun));
        }

        public void dodajSefaRestorana(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun)
        {
            uposlenici.Add(new SefRestorana(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun));
        }

        public void dodajMajstora(string ime, string prezime, string datumRodjenja, string username, string password, char pol, double plata, string bankovniRacun, string tipMajstora)
        {
            uposlenici.Add(new Majstor(ime, prezime, datumRodjenja, username, password, pol, plata, bankovniRacun, tipMajstora));
        }

        public List<Student> dajStudente()
        {
            return studenti;
        }

        public List<Uposlenik> dajUposlenike()
        {
            return uposlenici;
        }

        public Admin dajAdmina()
        {
            return admin;
        }

        public List<Osoba> dajSveClanove()
        {
            List<Osoba> svi = new List<Osoba>();
            svi.Add(admin);
            foreach(Student s in studenti)
            {
                svi.Add(s);
            }
            foreach(Uposlenik u in uposlenici)
            {
                svi.Add(u);
            }

            return svi;
        }
    }
}
