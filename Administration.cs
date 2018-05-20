using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kalender_Gold_Coorp
{
    public partial class Administration : Form
    {
        Verwaltung_ verwaltung;
        Konto k1;
        int mov, movX, movy;
           
        public Administration(Verwaltung_ verwaltung)
        {
            this.verwaltung = verwaltung;
                InitializeComponent();
            for (int i = 0; i < verwaltung.GetAnzahlKonten(); i++)
            {
                k1 = verwaltung.GetKonto(i);
                listBox1.Items.Add(k1.GetBenutzername());

            }
            listBox1.SelectedIndex = 0;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            k1 = verwaltung.GetKonto(listBox1.SelectedIndex);
        } //Mitarbeiter Auswahl

        private void Passwort_ändern_Btn_Click(object sender, EventArgs e)
        {
            Passchange();
        }   //Passwort des Ausgewählten Mitarbeiters ändern

        private void Beenden_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

 
        private void panel32_MouseMove(object sender, MouseEventArgs e) //Move ermöglichen
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movy);
            }
        }

        private void Administration_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void newpasswordtxtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Passchange();
            }
        }

        private void Passchange()
        {
            k1.setPasswort(newpasswordtxtb.Text);
            newpasswordtxtb.Text = "";
        }
        private void panel32_MouseDown(object sender, MouseEventArgs e) //Move ermöglichen
        {
            mov = 1;
            movX = e.X;
            movy = e.Y;
        }

        private void panel32_MouseUp(object sender, MouseEventArgs e) //Move ermöglichen
        {
            mov = 0;
        }
    }
}
