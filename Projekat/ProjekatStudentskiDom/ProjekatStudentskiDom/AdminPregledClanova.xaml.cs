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
using Windows.UI.Popups;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ProjekatStudentskiDom
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AdminPregledClanova : Page
    {
        StudentskiDom sd;
        public AdminPregledClanova(StudentskiDom sd)
        {
            this.InitializeComponent();
            this.sd = sd;

            upisiUListe();
        }

        private void upisiUListe()
        {
            List<Student> s=sd.dajStudente();
            foreach(Student student in s)
            {
                studenti.Items.Add(student.ToString());
            }

            List<Uposlenik> u = sd.dajUposlenike();
            foreach(Uposlenik uposlenik in u)
            {
                uposlenici.Items.Add(uposlenik.ToString());
            }
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            Page adminPage = new AdminPage(sd);
            this.Content = adminPage;
        }

        private async void uposlenici_ItemClick(object sender, ItemClickEventArgs e)
        {
            var dialog = new MessageDialog(e.ToString());
            await dialog.ShowAsync();
        }
    }
}
