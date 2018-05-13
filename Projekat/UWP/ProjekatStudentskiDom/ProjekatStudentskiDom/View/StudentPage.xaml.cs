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
    public sealed partial class StudentPage : Page
    {
        Student s;
        StudentskiDom sd;
        public StudentPage(Student s, StudentskiDom sd)
        {
            this.InitializeComponent();
            this.s = s;
            this.sd = sd;
            if (s.Pol == 'M') dobrodosaoText.Text = "Dobrodošao, " + s.Ime + "e!";
            else dobrodosaoText.Text = "Dobrodošla, " + s.Ime + "!";
            List<string> novosti = sd.dajNovosti();
            foreach(string novost in novosti)
            {
                listaNovostiStudent.Items.Add(novost);
            }
        }
    }
}
