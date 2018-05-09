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
using System.Windows.Input;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProjekatStudentskiDom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        StudentskiDom sd;
        public MainPage()
        {
            this.InitializeComponent();
            sd = new StudentskiDom();
        }

        public MainPage(StudentskiDom sd)
        {
            this.InitializeComponent();
            this.sd = sd;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            String username = korisnickoIme.Text;
            String password = sifraPocetni.Password.ToString();

            List<Osoba> l = sd.dajSveClanove();

            foreach (Osoba o in l)
            {
                if (o.Username.Equals(username) && o.Password.Equals(password))
                {
                    if (o is Admin)
                    {
                        Page ap = new AdminPage(sd);
                        this.Content = ap;
                    }
                    if (o is Student)
                    {
                        Page sp = new StudentPage((Student)o, sd);
                        this.Content = sp;
                    }
                }
            }
        }

        private void sifraPocetni_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                loginButton_Click(this, new RoutedEventArgs());
            }
        }

        private void korisnickoIme_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                loginButton_Click(this, new RoutedEventArgs());
            }
        }

        private void loginButton_PreviewKeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                loginButton_Click(this, new RoutedEventArgs());
            }
        }
    }
}
