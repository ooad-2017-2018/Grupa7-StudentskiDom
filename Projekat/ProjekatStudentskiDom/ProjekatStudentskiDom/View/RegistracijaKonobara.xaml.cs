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
    public sealed partial class RegistracijaKonobara : Page
    {
        StudentskiDom sd;
        public RegistracijaKonobara(StudentskiDom sd)
        {
            this.InitializeComponent();
            this.sd = sd;
            pol.Items.Add("Muški");
            pol.Items.Add("Ženski");
            pol.SelectedIndex = 0;
        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            String dan = jmbg.Text.Substring(0, 2);
            String mjesec = jmbg.Text.Substring(2, 2);
            String godina = "1" + jmbg.Text.Substring(4, 3);
            char p;
            if ((string)pol.SelectedItem == "Muški") p = 'M';
            else p = 'Z';
            sd.dodajKonobara(ime.Text, prezime.Text, dan + "." + mjesec + "." + godina, username.Text, password.Password, p, Int32.Parse(plata.Text), racun.Text);
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }

        private void otkazi_Click(object sender, RoutedEventArgs e)
        {
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }
    }
}
