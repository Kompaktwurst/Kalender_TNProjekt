using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Kalender_Gold_Coorp
{
    public partial class Tagesplan : Form
    {
        int mov, movX, movy;
        private Konto k1;
        private DateTime Datum;
        static int laenge = 24;
        private Panel[] _Panels = new Panel[laenge];
        private Label[] _Labels = new Label[laenge];
        private Label[] __Labels = new Label[laenge];
        private List<string> Tagesplanliste;
        public Tagesplan(Konto k1_, DateTime Datum_)
        {
            InitializeComponent();
            k1 = k1_;
            Datum = Datum_;
            Auswahldatum.Text = Datum.ToShortDateString();
            Tagesplanliste = new List<string>();
            Form_init();
            Label_reset();
            Panel_reset();
            TermineLaden();
          

        }
        private void Panel_init()
        {
            _Panels[0] = panel1;
            _Panels[1] = panel2;
            _Panels[2] = panel3;
            _Panels[3] = panel4;
            _Panels[4] = panel5;
            _Panels[5] = panel6;
            _Panels[6] = panel7;
            _Panels[7] = panel8;
            _Panels[8] = panel9;
            _Panels[9] = panel10;
            _Panels[10] = panel11;
            _Panels[11] = panel12;
            _Panels[12] = panel13;
            _Panels[13] = panel14;
            _Panels[14] = panel15;
            _Panels[15] = panel16;
            _Panels[16] = panel17;
            _Panels[17] = panel18;
            _Panels[18] = panel19;
            _Panels[19] = panel20;
            _Panels[20] = panel21;
            _Panels[21] = panel22;
            _Panels[22] = panel23;
            _Panels[23] = panel24;


        }
        private void Panel_reset()
        {
            for (int i = 0; i < 24; i++)
            {
                _Panels[i].BackColor = Color.Transparent;

            }
            //Array in denen alle Labels drin sind fertig
            //Labels mit Labelreset ="" fertig
        }
        private void Label_init()
        {
            _Labels[0] = label1;
            _Labels[1] = label2;
            _Labels[2] = label3;
            _Labels[3] = label4;
            _Labels[4] = label5;
            _Labels[5] = label6;
            _Labels[6] = label7;
            _Labels[7] = label8;
            _Labels[8] = label9;
            _Labels[9] = label10;
            _Labels[10] = label11;
            _Labels[11] = label12;
            _Labels[12] = label13;
            _Labels[13] = label14;
            _Labels[14] = label15;
            _Labels[15] = label16;
            _Labels[16] = label17;
            _Labels[17] = label18;
            _Labels[18] = label19;
            _Labels[19] = label20;
            _Labels[20] = label21;
            _Labels[21] = label22;
            _Labels[22] = label23;
            _Labels[23] = label24;
            __Labels[0] = label25;
            __Labels[1] = label26;
            __Labels[2] = label27;
            __Labels[3] = label28;
            __Labels[4] = label29;
            __Labels[5] = label30;
            __Labels[6] = label31;
            __Labels[7] = label32;
            __Labels[8] = label33;
            __Labels[9] = label34;
            __Labels[10] = label35;
            __Labels[11] = label36;
            __Labels[12] = label37;
            __Labels[13] = label38;
            __Labels[14] = label39;
            __Labels[15] = label40;
            __Labels[16] = label41;
            __Labels[17] = label42;
            __Labels[18] = label43;
            __Labels[19] = label44;
            __Labels[20] = label45;
            __Labels[21] = label46;
            __Labels[22] = label47;
            __Labels[23] = label48;
           
        }
        private void Label_reset()
        {
            for (int i = 0; i < 24; i++)
            {
                _Labels[i].Text = "";
            }
        }
        private void Form_init()
        {
            Panel_init();
            Label_init();
           
        }
        private void TermineLaden()
        {
            Tagesplanliste = k1.GetTagesplan();
            Tagesplanliste.ForEach(delegate (string Termindate)
                {
                    string temp1;
                    int day, month, year;
                    temp1 = Termindate[0] + "" + Termindate[1];
                    day = Convert.ToInt32(temp1);
                    temp1 = Termindate[3] + "" + Termindate[4];
                    month = Convert.ToInt32(temp1);
                    temp1 = Termindate[6] + "" + Termindate[7] + "" + Termindate[8] + "" + Termindate[9];
                    year = Convert.ToInt32(temp1);
                    DateTime Termin = new DateTime(year, month, day);
                    if (Termin ==Datum)
                    {       
                        temp1 = Termindate[11] + "" + Termindate[12]+":"+Termindate[14] + "" + Termindate[15];
                        for (int i = 0; i < 24; i++)
                        {
                            if(__Labels[i].Text==temp1)
                            {  
                                _Panels[i].BackColor = Color.Gold;      
                                string[] p= Termindate.Split('%');
                                _Labels[i].Text = p[1];
                            }
                        }
                    }
                });
        }

        private void Panel_Click(object sender, EventArgs e) //Alle Panels reagieren auf dieses Ereignis
        {
            Panel clickedPanel = sender as Panel;
            if (clickedPanel.BackColor == Color.Transparent)
            {
                clickedPanel.BackColor = Color.DimGray;
                return;
            }
            if (clickedPanel.BackColor == Color.DimGray)
            {
                clickedPanel.BackColor = Color.Transparent;
                return;
            }
            if (clickedPanel.BackColor == Color.Gold)
            {
                DialogResult result = MessageBox.Show("Termin löschen[OK] oder Auswahl zurücksetzen [Cancel]",
                        "Termin Löschen", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                  
                }

            }
          
        }


        private void Beenden_Button_Click(object sender, EventArgs e)
        {
            k1.setTagesplan(Tagesplanliste);
            Close();
        }

        private void Clear_Button_Click(object sender, EventArgs e)
        {
            Label_reset();
            Panel_reset();
            Eventtxtb.Text = "";
            deleteday(Datum);
        }
        private void deleteday(DateTime test9)
        {
            string datumloeschen = test9.ToShortDateString();
            for (int i = 0; i < Tagesplanliste.Count; i++)
            {
                if (Tagesplanliste[i] == datumloeschen)
                {
                    Tagesplanliste.RemoveAt(i);
                    return;
                }
            }
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

        private void Eventtxtb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Speichern();
            }
        }

        private void panel32_MouseMove(object sender, MouseEventArgs e) //Move ermöglichen
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movy);
            }
        }

        private void Speichern()
        {
            for (int i = 0; i < 24; i++)
            {
                if (_Panels[i].BackColor == Color.DimGray)
                {
                    int k = 30 * i;
                    int b = k / 60;
                    int c = k % 60;
                    DateTime uhrzeit_ = new DateTime(Datum.Year, Datum.Month, Datum.Day, 7 + b, 0 + c, 0);
                    DateTime name = new DateTime(Datum.Year, Datum.Month, Datum.Day, uhrzeit_.Hour, uhrzeit_.Minute, 0);
                    string Datetimes_ = "" + name.ToString() + "%" + Eventtxtb.Text + "%";
                    Tagesplanliste.Add(Datetimes_);
                    MessageBox.Show(Datetimes_);
                }
            }

        }
        private void Bearbeiten_Button_Click(object sender, EventArgs e)
        {

            Speichern();
        }
    }
}

