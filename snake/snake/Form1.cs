using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace snake
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        yilan yil;
        Random rnd;
        private void labelBasla_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void labelBasla_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void labelBitir_MouseHover(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void labelBitir_MouseLeave(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }
        public void oyun_basla(){

            yil = new yilan();
            panelYilan.Controls.Clear();
            List<PictureBox> pb = yil.PB;
            for (int i = 0; i < pb.Count; i++)
            {
                panelYilan.Controls.Add(pb[i]);
            }


			textBox2.Text = yil.HIZ.ToString();

			if (yil.DUVAR) checkBox1.Checked = true;
			else checkBox1.Checked = false;
        
        }

        public void oyun_bitir() {

            timer1.Stop(); 
            string isim = textBox1.Text;
       
            //scoreyaz(isim,yil.SCORE);
            textBox1.Text = "";
            oyun_basla();
            yil.AKTIF = false;

        }

        public void yem()
        {
            int width = panelYilan.Width;
            int height = panelYilan.Height;

            int x = random_sayi();
            int y = random_sayi();

            

             Image yukleImg = Image.FromFile("snake.png");

             Point p = new Point(x, y);
             PictureBox picBox = new PictureBox();
             picBox.Image = yukleImg;
             picBox.Size = yukleImg.Size;
             picBox.Tag = "Yem";
             picBox.Location = p;

             panelYilan.Controls.Add(picBox);
             
        

        }

        public int random_sayi()
        {
            rnd = new Random();
            List<PictureBox> pb = yil.PB;
            List<int> dizi = new List<int>();
            bool check=true;
            int numb, lo=0;
            for (int i = 0; i < pb.Count; i++)
            {
                dizi.Add(pb[i].Location.X);
                dizi.Add(pb[i].Location.Y);
            }

            int[] blacklist = dizi.ToArray();

            numb = rnd.Next(1, 20) * 20;

            while (check) {

                if (blacklist[lo] == numb)
                {
                    if (lo == blacklist.Count()) {
                        numb = rnd.Next(1, 20) * 20;
                        lo = 0;
                    }
                }
                else {
                    check=false;
                }

                lo++;
            }


            return numb;
        }

        public void scoreyaz(string isim,int puan) {


            StreamReader rdr = txtOkuYaz.dosyadanOku("score.txt");
            string tmp;

            string[] yeniDizi;
            string dump ="";
            string rep = "";

            string readText = File.ReadAllText("score.txt");

            if (String.IsNullOrWhiteSpace(readText))
            {
                rep = isim + ":" + puan.ToString() + ":0";
                dump += rep + System.Environment.NewLine;

                txtOkuYaz.okumayiKapat();
                txtOkuYaz.dosyaEkle("score.txt", dump);
            }
            else {
                while (!String.IsNullOrEmpty(tmp = rdr.ReadLine()))
                {
                    yeniDizi = tmp.Split(':');

                    if (yeniDizi[0] == isim)
                    {
                        yeniDizi[1] = puan.ToString();

                        if (puan > Convert.ToInt32(yeniDizi[2]))
                        {
                            yeniDizi[2] = puan.ToString();
                        }

                        rep = string.Join(":", Array.ConvertAll(yeniDizi, item => item.ToString()));

                        dump += rep + System.Environment.NewLine;
                    }
                    else
                    {
                        rep = isim + ":" + puan.ToString() + ":0";
                        dump += rep + System.Environment.NewLine;
                    }

                }
                txtOkuYaz.okumayiKapat();
                txtOkuYaz.dosyaEkle("score.txt", dump);
            
            }
          
            
           
           

           
        }

        private void labelBasla_Click(object sender, EventArgs e)
        {

            if (checkBox1.Checked)
                yil.DUVAR = true;
            else
                yil.DUVAR = false;
            
                

            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
            {
                yil.HizDegis(Convert.ToInt32(textBox2.Text));
                yil.AKTIF = true;
                timer1.Interval = yil.HIZ;
                timer1.Start();

               


            }
            else {
                MessageBox.Show("Bütün alanların dolu olduğundan emin olun");
            }


          
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            List<PictureBox> pb = yil.PB;
            int enOndeki = pb.Count - 1; 
            Point p = new Point();
            p = pb[enOndeki].Location;

			for(int i=0; i < pb.Count-1; i++){

				if (pb[enOndeki].Location.X == pb[i].Location.X && pb[enOndeki].Location.Y == pb[i].Location.Y ) {
					oyun_bitir ();
				}

			}


            switch (yil.YON)
            {
                case "sag":
                    p.X += 20;
                    break;
                case "sol":
                    p.X -= 20;
                    break;
                case "asagi":
                    p.Y += 20;
                    break;
                default: 
                    p.Y -= 20; 
                    break;
            }

            for (int i = 0; i < enOndeki; i++)
                pb[i].Location = pb[i + 1].Location;

            pb[enOndeki].Location = p;

            if (yil.DUVAR)
            {


                if (pb[enOndeki].Location.X < 0)
                {
                    pb[enOndeki].Location = new Point(panelYilan.Width - 20, pb[enOndeki].Location.Y);
                }
                else if (pb[enOndeki].Location.X >= panelYilan.Width)
                {
                    pb[enOndeki].Location = new Point(0, pb[enOndeki].Location.Y);
                }
                else if (pb[enOndeki].Location.Y < 0)
                {
                    pb[enOndeki].Location = new Point(pb[enOndeki].Location.X, panelYilan.Height - 20);
                }
                else if (pb[enOndeki].Location.Y >= panelYilan.Height)
                {
                    pb[enOndeki].Location = new Point(pb[enOndeki].Location.X, 0);
                }

            }
            else {

                if (pb[enOndeki].Location.X < 0 ||
                    pb[enOndeki].Location.X >= panelYilan.Width ||
                    pb[enOndeki].Location.Y < 0 ||
                    pb[enOndeki].Location.Y >= panelYilan.Height)
                {
                    oyun_bitir();
                }
            
            }
            
        }

        #region keydownKontrol
        // formun kontrollerinden keyPress özelliğinin alınması
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (yil.AKTIF)
            {
                switch(keyData)
                {
                    case Keys.Left:
                        if(!yil.YON.Equals("sag"))
                            yil.YON = "sol";
                        break;
                    case Keys.Right:
                        if(!yil.YON.Equals("sol"))
                            yil.YON = "sag";
                        break;
                    case Keys.Down:
                        if(!yil.YON.Equals("yukari"))
                            yil.YON = "asagi";
                        break;
                    default:
                        if(!yil.YON.Equals("asagi"))
                            yil.YON = "yukari";
                        break;
                }
                return true;
            }
            return false;
        }
        #endregion

        private void labelBitir_Click(object sender, EventArgs e)
        {
            oyun_bitir();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
			oyun_basla();
        }

        

        

       
    }
}
