using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Forms.VisualStyles;
using Timer = System.Timers.Timer;

namespace HayvanCiftligi
{
    interface IUretim
    {
        int uretimMiktari { get; set; }
        int satisFiyati { get; set; }
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        abstract class Canli
        {
            public abstract int Can { get; set; }
            public abstract int CanAzalmaMiktari { get; set; }

            public virtual int CanAzalimi()
            {
                int CanAzalmaMiktari = 0;
                return CanAzalmaMiktari;
            }

            public virtual void Yasam()
            {
                int can = Can;
                SoundPlayer olumSesi = new SoundPlayer();
                olumSesi.SoundLocation = @"C:\Users\Miraç\source\repos\HayvanCiftligi\HayvanCiftligi\";
                if (can == 0)
                {
                    olumSesi.Play();
                }
            }
        }

        class Tavuk : Canli, IUretim
        {
            public override int Can { get; set; }
            public override int CanAzalmaMiktari { get; set; }

            private int uretim = 3;
            private int fiyat = 1;

            public int uretimMiktari
            {
                get { return uretim; }
                set { uretim = value; }
            }
            public int satisFiyati
            {
                get { return fiyat; }
                set { fiyat = value; }
            }

            public override void Yasam()
            {
                int can = Can;
                SoundPlayer tavukSesi = new SoundPlayer();
                tavukSesi.SoundLocation = @"C:\Users\Miraç\source\repos\HayvanCiftligi\HayvanCiftligi\ordek.wav";
                if (can == 0)
                {
                    tavukSesi.Play();
                }
            }

            public override int CanAzalimi()
            {
                int CanAzalmaMiktari = 2;
                return CanAzalmaMiktari;
            }

        }
        class Ordek : Canli, IUretim
        {
            public override int Can { get; set; }
            public override int CanAzalmaMiktari { get; set; }

            private int uretim = 5;
            private int fiyat = 3;
            public int uretimMiktari
            {
                get { return uretim; }
                set { uretim = value; }
            }
            public int satisFiyati
            {
                get { return fiyat; }
                set { fiyat = value; }
            }

            public override void Yasam()
            {
                int can = Can;
                SoundPlayer ordekSesi = new SoundPlayer();
                ordekSesi.SoundLocation = @"C:\Users\Miraç\source\repos\HayvanCiftligi\HayvanCiftligi\ordek.wav";
                if (can == 0)
                {
                    ordekSesi.Play();
                }

            }

            public override int CanAzalimi()
            {
                int CanAzalmaMiktari = 3;
                return CanAzalmaMiktari;
            }

        }
        class Inek : Canli, IUretim
        {
            public override int Can { get; set; }
            public override int CanAzalmaMiktari { get; set; }

            private int uretim = 8;
            private int fiyat = 5;
            public int uretimMiktari
            {
                get { return uretim; }
                set { uretim = value; }
            }
            public int satisFiyati
            {
                get { return fiyat; }
                set { fiyat = value; }
            }
            public override void Yasam()
            {
                int can = Can;
                SoundPlayer inekSesi = new SoundPlayer();
                inekSesi.SoundLocation = @"C:\Users\Miraç\source\repos\HayvanCiftligi\HayvanCiftligi\inek.wav";
                if (can == 0)
                {
                    inekSesi.Play();
                }
            }

            public override int CanAzalimi()
            {
                int CanAzalmaMiktari = 8;
                return CanAzalmaMiktari;
            }

        }
        class Keci : Canli,IUretim
        {
            public override int Can { get; set; }
            public override int CanAzalmaMiktari { get; set; }

            private int uretim = 7;
            private int fiyat = 8;
            public int uretimMiktari
            {
                get { return uretim; }
                set { uretim = value; }
            }
            public int satisFiyati
            {
                get { return fiyat; }
                set { fiyat = value; }
            }

            public override void Yasam()
            {
                int can = Can;
                SoundPlayer keciSesi = new SoundPlayer();
                keciSesi.SoundLocation = @"C:\Users\Miraç\source\repos\HayvanCiftligi\HayvanCiftligi\keci.wav";
                if (can == 0)
                {
                    keciSesi.Play();
                }
            }

            public override int CanAzalimi()
            {
                int CanAzalmaMiktari = 6;
                return CanAzalmaMiktari;
            }

        }

        private int zaman = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
            zaman++;
            label12.Text = Convert.ToString(zaman);
            Tavuk tavuk = new Tavuk();
            Ordek ordek = new Ordek();
            Inek inek = new Inek();
            Keci keci = new Keci();

            tavuk.Can = progressBar1.Value;
            ordek.Can = progressBar2.Value;
            inek.Can = progressBar3.Value;
            keci.Can = progressBar4.Value;

            if (tavuk.Can >= 2)
            {
                progressBar1.Value = progressBar1.Value - tavuk.CanAzalimi();
                tavuk.Can = progressBar1.Value;
                label17.Text = "CANLI";
            }
            else if (tavuk.Can < 2)
            {
                progressBar1.Value = 0;
                tavuk.Can = progressBar3.Value;
                label17.Text = "ÖLÜ";
                tavuk.Yasam();
            }

            if (ordek.Can >= 3)
            {
                progressBar2.Value = progressBar2.Value - ordek.CanAzalimi();
                ordek.Can = progressBar2.Value;
                label18.Text = "CANLI";
            }
            else if (ordek.Can < 3)
            {
                progressBar2.Value = 0;
                ordek.Can = progressBar3.Value;
                label18.Text = "ÖLÜ";
                ordek.Yasam();
            }

            if (inek.Can >= 8)
            {
                progressBar3.Value = progressBar3.Value - inek.CanAzalimi();
                inek.Can = progressBar3.Value;
                label19.Text = "CANLI";
            }
            else if (inek.Can < 8)
            {                
                progressBar3.Value = 0;
                inek.Can = progressBar3.Value;
                label19.Text = "ÖLÜ";
                inek.Yasam();                  
            }

            if (keci.Can >= 6)
            {
                progressBar4.Value = progressBar4.Value - keci.CanAzalimi();
                keci.Can = progressBar4.Value;
                label16.Text = "CANLI";
            }
            else if (keci.Can < 6)
            {
                progressBar4.Value = 0;
                keci.Can = progressBar3.Value;
                label16.Text = "ÖLÜ";
                keci.Yasam();
            }

            if (progressBar1.Value != 0)
            {
                int tavukUrunu = zaman / tavuk.uretimMiktari;
                label6.Text = tavukUrunu.ToString();
            }

            if (progressBar2.Value != 0)
            {
                int ordekUrunu = zaman / ordek.uretimMiktari;
                label8.Text = ordekUrunu.ToString();
            }

            if (progressBar3.Value != 0)
            {
                int inekUrunu = zaman / inek.uretimMiktari;
                label7.Text = inekUrunu.ToString();
            }

            if (progressBar4.Value != 0)
            {
                int keciUrunu = zaman / keci.uretimMiktari;
                label9.Text = keciUrunu.ToString();
            }

            label13.Text = kasa.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value != 0)
            {
                progressBar1.Value = 100;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (progressBar3.Value != 0)
            {
                progressBar3.Value = 100;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (progressBar2.Value != 0)
            {
                progressBar2.Value = 100;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (progressBar4.Value != 0)
            {
                progressBar4.Value = 100;
            }
        }

        int kasa = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            kasa = Int32.Parse(label6.Text) + kasa;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            kasa = Int32.Parse(label8.Text) + kasa;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            kasa = Int32.Parse(label7.Text) + kasa;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kasa = Int32.Parse(label9.Text) + kasa;
        }
    }
}
