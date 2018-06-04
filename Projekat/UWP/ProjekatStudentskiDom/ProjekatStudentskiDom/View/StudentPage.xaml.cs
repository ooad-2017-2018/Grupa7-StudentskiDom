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
        DispatcherTimer timer1,timer2,timer3,timer4;
        DateTime vrijeme;
        int brojac;
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
            brojSobe.Text += s.dajBrojSobe();

            vrijeme = DateTime.Now;           

            if (DateTime.Now.Hour>=12 && DateTime.Now.Hour<15)
            {
                raiseTimer2();
            }
            else if(DateTime.Now.Hour<12 || DateTime.Now.Hour>=20)
            {
                raiseTimer1();
            }
            else if (DateTime.Now.Hour >= 17 && DateTime.Now.Hour < 20)
            {
                raiseTimer3();
            }
            else
            {
                raiseTimer4();
            }
        }

        private void raiseTimer1()
        {
            int sati;
            if (vrijeme.Hour >= 20)
            {
                sati = 24 - vrijeme.Hour + 11;
            }
            else
            {
                sati = 12 - vrijeme.Hour - 1;
            }

            brojac = 60 - vrijeme.Second + (60 - vrijeme.Minute - 1) * 60 + sati * 3600;

            timer1 = new DispatcherTimer();
            timer1.Tick += timer1_Tick;
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Start();

            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Ručak počinje za " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');
        }

        private void raiseTimer2()
        {
            brojac = 60 - vrijeme.Second + (60 - vrijeme.Minute - 1) * 60 + (15 - vrijeme.Hour - 1) * 3600;

            timer2 = new DispatcherTimer();
            timer2.Tick += timer2_Tick;
            timer2.Interval = TimeSpan.FromMilliseconds(1000);
            timer2.Start();

            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Ručak traje još " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');

        }

        private void raiseTimer3()
        {
            brojac = 60 - vrijeme.Second + (60 - vrijeme.Minute - 1) * 60 + (17 - vrijeme.Hour - 1) * 3600;

            timer3 = new DispatcherTimer();
            timer3.Tick += timer3_Tick;
            timer3.Interval = TimeSpan.FromMilliseconds(1000);
            timer3.Start();

            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Večera počinje za " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');

        }

        private void raiseTimer4()
        {
            brojac = 60 - vrijeme.Second + (60 - vrijeme.Minute - 1) * 60 + (20 - vrijeme.Hour - 1) * 3600;

            timer4 = new DispatcherTimer();
            timer4.Tick += timer4_Tick;
            timer4.Interval = TimeSpan.FromMilliseconds(1000);
            timer4.Start();

            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Večera traje još " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');

        }

        private void timer1_Tick(object sender, object e)
        {
            brojac--;
            if(brojac==0)
            {
                counter.Text = "";
                raiseTimer2();
            }
            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Ručak počinje za " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');
        }

        private void timer2_Tick(object sender, object e)
        {
            brojac--;
            if (brojac == 0)
            {
                counter.Text = "";
                raiseTimer3();
            }
            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Ručak traje još " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');
        }

        private void timer3_Tick(object sender, object e)
        {
            brojac--;
            if (brojac == 0)
            {
                counter.Text = "";
                raiseTimer4();
            }
            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Večera počinje za " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');
        }

        private void timer4_Tick(object sender, object e)
        {
            brojac--;
            if (brojac == 0)
            {
                counter.Text = "";
                raiseTimer1();
            }
            int satiZaPrikazat, minuteZaPrikazat, sekundeZaPrikazat;
            double satiDouble, minuteDouble;

            satiDouble = (double)brojac / 3600;
            satiZaPrikazat = (int)satiDouble;

            minuteDouble = (satiDouble - satiZaPrikazat) * 60;
            minuteZaPrikazat = (int)minuteDouble;

            sekundeZaPrikazat = (int)((minuteDouble - minuteZaPrikazat) * 60);

            counter.Text = "Večera traje još " + satiZaPrikazat.ToString().PadLeft(2, '0') + ":" + minuteZaPrikazat.ToString().PadLeft(2, '0') + ":" + sekundeZaPrikazat.ToString().PadLeft(2, '0');
        }

        private void povratak_Click(object sender, RoutedEventArgs e)
        {           
            Page main = new MainPage(sd);
            this.Content = main;           
        }
    }
}
