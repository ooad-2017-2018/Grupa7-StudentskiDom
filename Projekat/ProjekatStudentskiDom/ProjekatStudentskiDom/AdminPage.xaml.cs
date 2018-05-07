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
    public sealed partial class AdminPage : Page
    {
        private StudentskiDom sd;
        public AdminPage(StudentskiDom sd)
        {
            this.InitializeComponent();
            this.sd = sd;
            if(sd.dajAdmina().Pol=='M')
            {
                dobrodosaoAdmin.Text = "Dobrodošao, " + sd.dajAdmina().Ime + "e!";
            }
            else
            {
                dobrodosaoAdmin.Text = "Dobrodošla, " + sd.dajAdmina().Ime + "!";
            }
            listaNovosti.Items.Add("Požar na sedmom spratu usmrtio troje ljudi. A.O. (1996), N.R. (1997) i A.K. (1997) su smrtno stradali");
            listaNovosti.Items.Add("Dajana Mojsilović izbačena iz doma zbog nepoštivanja pravila i kodeksa ponašanja.");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
