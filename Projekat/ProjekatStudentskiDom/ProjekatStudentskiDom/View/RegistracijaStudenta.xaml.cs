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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatStudentskiDom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaStudenta : Page
    {
        StudentskiDom sd;
        public RegistracijaStudenta(StudentskiDom sd)
        {
            this.InitializeComponent();
            this.sd = sd;
            validacija.Opacity = 0;
            dodajUCombo();
        }

        private void dodajUCombo()
        {
            kanton.Items.Add("KS");
            kanton.Items.Add("SBK");
            kanton.Items.Add("USK");
            kanton.Items.Add("ZDK");
            kanton.Items.Add("ZHK");
            kanton.Items.Add("TK");
            kanton.Items.Add("PK");
            kanton.Items.Add("BPK");
            kanton.Items.Add("HNK");
            kanton.Items.Add("K10");
            kanton.Items.Add("RS");
            kanton.Items.Add("Brčko D");
            kanton.SelectedIndex = 0;

            pol.Items.Add("Muški");
            pol.Items.Add("Ženski");
            pol.SelectedIndex = 0;
        }

        private void otkazi_Click(object sender, RoutedEventArgs e)
        {
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
            
        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            if (!sobaValidate() || ime.Text.Length == 0 || prezime.Text.Length == 0 || username.Text.Length == 0 || password.Password.Length == 0 || !jmbgValidate(jmbg.Text))
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
            bool t;
            if (teretana.IsChecked == true) t = true;
            else t = false;
            sd.dodajStudenta(ime.Text, prezime.Text, dan + "." + mjesec + "." + godina, username.Text, password.Password, p, Int32.Parse(soba.Text), t, (string)kanton.SelectedItem);
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }

        public bool sobaValidate()
        {
            if (soba.Text.Length != 3) return false;
            for(int i=0;i<soba.Text.Length;i++)
            {
                if (soba.Text[i] < '0' || soba.Text[i] > '9') return false;
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
