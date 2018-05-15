using System;
using System.Collections.Generic;
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
       

        private Admin admin = new Admin("Rijad","Pedljak","19.07.1996","rpedljak","FLStudio11",'M');
        private List<Student> studenti=new List<Student>();
        private List<Uposlenik> uposlenici = new List<Uposlenik>();
        private List<string> novosti = new List<string>();


        public async Task<Admin> dajAdmina(string id)
        {
            return await adminTable.LookupAsync(id);
        }
        

        public async void povuciIzBaze()
        {
            var task = dajAdmina("421b9db4-bb7e-4853-80c5-d93b770475dc");
            admin = (Admin)task.GetType().GetProperty("id").GetValue(task);
        }

        public void dodajAdmina()
        {
            try
            {
                Admin obj = new Admin();
                obj.Ime = "Rijad";
                obj.Prezime = "Pedljak";
                obj.DatumRodjenja ="19.07.1996";
                obj.Username = "rpedljak";
                obj.Password = "FLStudio11";
                obj.Pol = 'M';
                obj.Jmbg = "1907996190004";
                obj.AdminId = "rijadpedljak";
                adminTable.InsertAsync(obj);
                MessageDialog dialog = new MessageDialog("Uspješno ste unijeli admina!");
                dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Error: " + ex.ToString());
                dialog.ShowAsync();
            }
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
