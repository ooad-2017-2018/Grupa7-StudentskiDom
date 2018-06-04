using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

namespace ProjekatStudentskiDom.Klase
{
    public class StudentskiDom
    {
        IMobileServiceTable<Admin> adminTable = App.mobileService.GetTable<Admin>();


        private Admin admin;
        private List<Student> studenti=new List<Student>();
        private List<Uposlenik> uposlenici = new List<Uposlenik>();
        private List<string> novosti = new List<string>();

        string apiURL = "http://studentskidomwebapi.azurewebsites.net/";

        public List<Student> Student()
        {
            return studenti;
        }

        public Admin Admin()
        {
            return admin;
        }

        public List<Uposlenik> Uposlenik()
        {
            return uposlenici;
        }

        public void povuciIzBaze()
        {
            dajStudente();
            dajUposlenike();
            getAdmin();
        }

        public async void dajStudente()
        {
            var k = await getStudent();
            studenti = new List<Student>(k);
        }

        public async void dajUposlenike()
        {
            var k = await getUposlenik();
            uposlenici = new List<Uposlenik>(k);
        }

        public async void getAdmin()
        {
            var k = await dajAdmina();
            admin = k;
        }
        
        public static async Task<Admin> dajAdmina()
        {
            var admini = App.mobileService.GetTable<Admin>();
            var admin = from x in admini
                        select x;
            var listaAdmina = await admin.ToListAsync();
            return new Admin(listaAdmina[0].Ime, listaAdmina[0].Prezime, listaAdmina[0].DatumRodjenja, listaAdmina[0].Username, listaAdmina[0].Password, listaAdmina[0].Pol);
        }

        public static async Task<ObservableCollection<Student>> getStudent()
        {
            ObservableCollection<Student> studenti = new ObservableCollection<Student>();
            var lista = App.mobileService.GetTable<Student>();
            var kor = from x in lista
                      select x;
            var listatmp = await kor.ToListAsync();
            foreach (var x in listatmp)
            {
                studenti.Add(new Student(x.Ime, x.Prezime, x.DatumRodjenja, x.Username, x.Password, x.Pol, x.BrojSobe, x.Teretana, x.Kanton));
            }
            return studenti;

        }

        public static async Task<ObservableCollection<Uposlenik>> getUposlenik()
        {
            ObservableCollection<Uposlenik> uposlenici = new ObservableCollection<Uposlenik>();

            //Blagajnici
            var blagajnici = App.mobileService.GetTable<Blagajnik>();
            var k1 = from x in blagajnici
                      select x;
            var tempBlagajnik = await k1.ToListAsync();
            foreach (var x in tempBlagajnik)
            {
                uposlenici.Add(new Blagajnik(x.Ime, x.Prezime, x.DatumRodjenja, x.Username, x.Password, x.Pol, x.Plata, x.BankovniRacun));
            }

            //Konobari
            var konobari = App.mobileService.GetTable<Konobar>();
            var k2 = from x in konobari
                     select x;
            var tempKonobar = await k2.ToListAsync();
            foreach (var x in tempKonobar)
            {
                uposlenici.Add(new Konobar(x.Ime, x.Prezime, x.DatumRodjenja, x.Username, x.Password, x.Pol, x.Plata, x.BankovniRacun));
            }

            //Kuhari
            var kuhari = App.mobileService.GetTable<Kuhar>();
            var k3 = from x in kuhari
                     select x;
            var tempKuhar = await k3.ToListAsync();
            foreach (var x in tempKuhar)
            {
                uposlenici.Add(new Kuhar(x.Ime, x.Prezime, x.DatumRodjenja, x.Username, x.Password, x.Pol, x.Plata, x.BankovniRacun));
            }

            //Sefovi restorana
            var sefoviRestorana = App.mobileService.GetTable<SefRestorana>();
            var k4 = from x in sefoviRestorana
                     select x;
            var tempSef = await k4.ToListAsync();
            foreach (var x in tempSef)
            {
                uposlenici.Add(new SefRestorana(x.Ime, x.Prezime, x.DatumRodjenja, x.Username, x.Password, x.Pol, x.Plata, x.BankovniRacun));
            }

            //Majstori
            var majstori = App.mobileService.GetTable<Majstor>();
            var k5 = from x in majstori
                     select x;
            var tempMajstori = await k5.ToListAsync();
            foreach (var x in tempMajstori)
            {
                uposlenici.Add(new Majstor(x.Ime, x.Prezime, x.DatumRodjenja, x.Username, x.Password, x.Pol, x.Plata, x.BankovniRacun, x.Tip));
            }

            return uposlenici;

        }
        
        public void dodajNovost(string novost)
        {
            novosti.Add(novost);
        }

        public void obrisiNovost(int i)
        {
            novosti.RemoveAt(i);
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
