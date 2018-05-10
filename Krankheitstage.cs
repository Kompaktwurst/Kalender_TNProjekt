﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kalender_Gold_Coorp
{
    public partial class Krankheitstage : Form
    {
        Konto k1;
        Verwaltung_ verwaltung;
        bool Selected = false;
        List<DateTime> Krankheitstage_Liste;
        int mov, movX, movy;
       
        public Krankheitstage(Konto k1_,Verwaltung_ verwaltung)
        {
            k1 = k1_;
            this.verwaltung = verwaltung;
            InitializeComponent();
            Krankheitstage_Liste = new List<DateTime>();
            Krankheitstage_Laden();
        }
        private void Krankheitstage_Laden()
        {
            Krankheitstage_Liste = k1.GetKrankheitstage();
            for (int i = 0; i < 30; i++)
            {
                try
                {
                    listBox1.Items.Add(Krankheitstage_Liste[i].ToShortDateString());
                }
                catch (Exception) { }
            }

        }
        private void Löschen_Click(object sender, EventArgs e)
        {
            if (Selected == true)
            {
                string temp = SelectedDatum.Text;
                int day = Convert.ToInt32(temp[0] + "" + temp[1]);
                int month = Convert.ToInt32(temp[3] + "" + temp[4]);
                int year = Convert.ToInt32(temp[6] + "" + temp[7] + "" + temp[8] + "" + temp[9]);
                DateTime temp1 = new DateTime(year, month, day);
              
                if (temp1.CompareTo(DateTime.Today) == 1)
                {

                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    Krankheitstage_Liste.Remove(temp1);
                    SelectedDatum.Text = "";
                    Selected = false;
                
                }
                else
                {
                    if (temp1.CompareTo(DateTime.Today) == 0)
                    {
                        MessageBox.Show("Man kann den Krankheitstag von heute nicht zurückziehen");
                    }
                    else
                    {
                        MessageBox.Show("Man kann den Krankheitstag der bereits verstrichen ist nicht zurückziehen");
                    }

                }
            }
            else
            {
                MessageBox.Show("Kein Tag ausgewählt");

            }

        } //Ausgewählten Tag Löschen
        private void Krankheitstage_FormClosing(object sender, FormClosingEventArgs e)
        {
            k1.SetKrankheitstage(Krankheitstage_Liste);
          
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedDatum.Text = listBox1.SelectedItem.ToString();
                Selected = true;
            }
            catch (Exception)
            {

            }
        }

        private void Beenden_button_Click(object sender, EventArgs e)
        {
            Close();
 
        }

        private void Urlaubstage_Button_Click(object sender, EventArgs e)
        {

            
            Close();
        }
        private void panel_MouseMove(object sender, MouseEventArgs e) //Move ermöglichen
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movy);
            }
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
    }
}
