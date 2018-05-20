using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Kalender_Gold_Coorp
{
    public partial class Verwaltung_ : Form
    {
        private KontoSpeicher k1;
        private Konto k2;
        
        public Verwaltung_()
        {       
                InitializeComponent();
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            if (!File.Exists(GetPath()))
            {
               
                (new KontoSpeicher()).Leeren(GetPath());
                (new KontoSpeicher()).Speichern(GetPath());
            }
          
             k1 = (new KontoSpeicher()).Laden(GetPath());
                Anmeldung m = new Anmeldung(this);
                m.Show(); }
        
 

        public Konto GetKonto(int index)
        {
            return k1.GetKonto(index);
        }

        public static string GetPath()
        {
            string path = @"C:\Users\Public\KontenTN.txt";
            return path;
        }
        private void Verwaltung__FormClosing(object sender, FormClosingEventArgs e)
        {
            k1.Speichern(GetPath());
        }


        public KontoSpeicher GetKontoSpeicher() => k1;
        public int GetAnzahlKonten() => k1.GetListenLänge();

        public void Krankentageswitch(Konto k2)
        {
            this.k2 = k2;
            new Krankheitstage(k2,this).Show();
            //z.Show();

        }
        public void Urlaubstageswitch(Konto k2)
        {
            this.k2 = k2;
            new Urlaubstage(k2, this).Show();
            
        }
    }
}
