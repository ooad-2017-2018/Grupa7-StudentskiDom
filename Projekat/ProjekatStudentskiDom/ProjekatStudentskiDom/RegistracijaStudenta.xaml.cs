﻿using System;
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
            dodajKantone();
        }

        private void dodajKantone()
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
        }

        private void registruj_Click(object sender, RoutedEventArgs e)
        {
            String dan = jmbg.Text.Substring(0, 2);
            String mjesec = jmbg.Text.Substring(2, 2);
            String godina = "1" + jmbg.Text.Substring(4, 3);
            char pol = 'M';
            if (radioButtonZ.IsEnabled) pol = 'Z';
            sd.dodajStudenta(ime.Text, prezime.Text, dan + "." + mjesec + "." + godina, username.Text, password.Password, pol, Int32.Parse(soba.Text), true, (string)kanton.SelectedItem);
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }
    }

    
}