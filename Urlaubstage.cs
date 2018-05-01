using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Kalender_Gold_Coorp
{
    public partial class Urlaubstage : Form
    {
        Konto k1;
        Verwaltung_ verwaltung;
        bool Selected=false;
        List<DateTime> Urlaubstage_Liste;
        int mov, movX, movy;
       
        public Urlaubstage(Konto k1_,Verwaltung_ verwaltung)
        {
            k1 = k1_;
            this.verwaltung = verwaltung;
            InitializeComponent();
            Urlaubstage_Liste = new List<DateTime>();
            Urlaubstage_Laden();
            
            
        }
       

        private void Urlaubstage_Laden()
        {
            Urlaubstage_Liste = k1.GetUrlaubstage();
           for(int i=0;i<30;i++)
            {
                try
                {
                    listBox1.Items.Add(Urlaubstage_Liste[i].ToShortDateString());
                }
                catch (Exception) { }
            }
           
        } //Urlaubstage Laden

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectedDatum.Text = listBox1.SelectedItem.ToString();
                Selected = true;
            }
            catch(Exception)
            {

            }
        } //Tag auswählen

        private void Löschen_Click(object sender, EventArgs e)
        {
            if (Selected == true)
            {
                string temp = SelectedDatum.Text;
                int day = Convert.ToInt32(temp[0] + "" + temp[1]);
                int month = Convert.ToInt32(temp[3] + "" + temp[4]);
                int year = Convert.ToInt32(temp[6] + "" + temp[7] + "" + temp[8] + "" + temp[9]);
                DateTime temp1 = new DateTime(year, month, day);

                if (temp1.CompareTo(DateTime.Today)==1)
                {
                    
                    listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                    Urlaubstage_Liste.Remove(temp1);
                    SelectedDatum.Text = "";
                    Selected = false;
                }
                else
                {
                    if (temp1.CompareTo(DateTime.Today) == 0)
                    {
                        MessageBox.Show("Man kann den Urlaub von heute nicht zurückziehen");
                    }
                    else
                    {
                        MessageBox.Show("Man kann den Urlaub der bereits verstrichen ist nicht zurückziehen");
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Kein Tag ausgewählt");

            }
            
        } //Ausgewählten Tag Löschen
   

        private void Urlaubstage_FormClosing(object sender, FormClosingEventArgs e)
        {
            k1.SetUrlaubstage(Urlaubstage_Liste);
           
          
        } //Bearbeitete Urlaubstage Speichern beim beenden

        private void Beenden_button_Click(object sender, EventArgs e)
        {
            Close();
        } //Form Beenden

        private void Krankheitstage_Button_Click(object sender, EventArgs e)
        {
           
            Close();
        } //Zu Krankheitstage wechseln
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
   

