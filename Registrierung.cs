using System;
using System.Windows.Forms;

namespace Kalender_Gold_Coorp
{
    public partial class Registrierung : Form
    {
        Konto k1;
        KontoSpeicher k2;
        int mov,movX,movy;
        public Registrierung(Konto k1_, KontoSpeicher k2_)
        {
            InitializeComponent();
            k1 = k1_;
            k2 = k2_;
            label4.Text = k1.GetBenutzername();
        }

        private void button1_Click(object sender, EventArgs e) //OK click
        {
            k1.SetGeburtstag(textBox1.Text);
            k1.SetAbteilung(textBox2.Text);
            k1.SetBeruf(textBox3.Text);
                k2.AddKonto(k1);
            Close();
                
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Registrierung_FormClosing(object sender, FormClosingEventArgs e)
        {
            Enter_Dates_Button.Enabled = false;
            Beenden_button.Enabled = false;
        }
        private void panel_MouseDown(object sender, MouseEventArgs e) //Move ermöglichen
        {
            mov = 1;
            movX = e.X;
            movy = e.Y;
        }

        private void panel_MouseUp(object sender, MouseEventArgs e) //Move ermöglichen
        {
            mov = 0;
        }
        private void panel_MouseMove(object sender, MouseEventArgs e) //Move ermöglichen
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movy);
            }
        }
    }
}
