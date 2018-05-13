using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProjekatStudentskiDom.Klase;
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatStudentskiDom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaKonobara : Page
    {
        StudentskiDom sd;
        public RegistracijaKonobara(StudentskiDom sd)
        {
            this.InitializeComponent();
            this.sd = sd;
            validacija.Opacity = 0;
            pol.Items.Add("Muški");
            pol.Items.Add("Ženski");
            pol.SelectedIndex = 0;
        }

        IMobileServiceTable<Konobar> konobarTableObj = App.mobileService.GetTable<Konobar>();

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            if (plata.Text.Length == 0 || racun.Text.Length == 0 || ime.Text.Length == 0 || prezime.Text.Length == 0 || username.Text.Length == 0 || password.Password.Length == 0 || !jmbgValidate(jmbg.Text) || !racunValidate())
            {
                validacija.Opacity = 100;
                return;
            }
            validacija.Opacity = 0;
            String dan = jmbg.Text.Substring(0, 2);
            String mjesec = jmbg.Text.Substring(2, 2);
            String godina = "1" + jmbg.Text.Substring(4, 3);
            char p;
            if ((string)pol.SelectedItem == "Muški") p = 'M';
            else p = 'Z';
            try
            {
                Konobar obj = new Konobar();
                obj.Ime = ime.Text;
                obj.Prezime = prezime.Text;
                obj.DatumRodjenja = dan + "." + mjesec + "." + godina;
                obj.Username = username.Text;
                obj.Password = password.Password;
                obj.Pol = p;
                obj.Plata = Double.Parse(plata.Text);
                obj.BankovniRacun = racun.Text;
                konobarTableObj.InsertAsync(obj);
                MessageDialog dialog = new MessageDialog("Uspješno ste unijeli konobara!");
                dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog dialog = new MessageDialog("Error: " + ex.ToString());
                dialog.ShowAsync();
            }
            //sd.dodajKonobara(ime.Text, prezime.Text, dan + "." + mjesec + "." + godina, username.Text, password.Password, p, Int32.Parse(plata.Text), racun.Text);
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }

        private void otkazi_Click(object sender, RoutedEventArgs e)
        {
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }

        public bool racunValidate()
        {
            if (racun.Text.Length != 16) return false;
            for (int i = 0; i < racun.Text.Length; i++)
            {
                if (racun.Text[i] < '0' || racun.Text[i] > '9') return false;
            }
            return true;
        }

        public bool jmbgValidate(string jmbg)
        {
            bool prestupna = false;
            if (jmbg.Length != 13) return false;
            for (int i = 0; i < jmbg.Length; i++)
            {
                if (jmbg[i] < '0' || jmbg[i] > '9') return false;
            }
            int dan = Int32.Parse(jmbg.Substring(0, 2));
            int mjesec = Int32.Parse(jmbg.Substring(2, 2));
            int godina = Int32.Parse("1" + jmbg.Substring(4, 3));

            if (dan == 0 || mjesec == 0 || godina == 0 || mjesec > 12 || dan > 31 || godina > System.DateTime.Now.Year) return false;

            if ((godina % 4 == 0 && godina % 100 != 0) || godina % 400 == 0) prestupna = true;

            if (mjesec == 2)
            {
                if (!prestupna && dan > 28) return false;
                if (dan > 29) return false;
            }
            if (mjesec == 4 || mjesec == 6 || mjesec == 9 || mjesec == 11)
            {
                if (dan > 30) return false;
            }
            return true;
        }
    }
}
