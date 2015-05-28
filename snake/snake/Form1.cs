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
        int bonussay=0;
        int bonuscount = 0;
        bool bonus = false;
        int hiz = 200;
        bool duvar = true;
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
		private void oyun_yenile()
		{
            if (yil == null)
                yil = new yilan();

            panelYilan.Controls.Clear();
            List<PictureBox> pb = yil.PB;
            for (int i = 0; i < pb.Count; i++)
            {
                panelYilan.Controls.Add(pb[i]);
            }

			textBox2.Text = hiz.ToString();

            if (duvar)
            {
                checkBox1.Checked = true;
            }
            else {
                checkBox1.Checked = false;
            }




		}

		private void oyun_bitir()
		{   
            
			timer1.Stop();
            timer1.Enabled = false;
			string isim = textBox1.Text;
			puan_kaydet(isim,yil.PUAN);
            yil = null;
            oyun_yenile();

		}

		private void Form1_Load(object sender, EventArgs e)
		{
            oyun_yenile();
		}

		private void yem(int tur)
		{
            rnd = new Random();
			int width = panelYilan.Width;
			int height = panelYilan.Height;

            int x = rnd.Next(1, 20) * 20;
            int y = rnd.Next(1, 20) * 20;


            PictureBox picBox = new PictureBox();

            if (tur == 1)
            {
                Image yukleImg = Image.FromFile("yem.png");
                picBox.Image = yukleImg;
                picBox.Size = yukleImg.Size;
            }
            else {
                Image yukleImg = Image.FromFile("yem2.png");
                picBox.Image = yukleImg;
                picBox.Size = yukleImg.Size;
            }


			Point p = new Point(x, y);		
			

            if (tur == 1)
            {
                picBox.Tag = "Yem";
            }
            else {
                picBox.Tag = "BonusYem";
            }

			picBox.Location = p;

			panelYilan.Controls.Add(picBox);



		}

        public void puan_kaydet(string isim, int puan)
        {
            
            string tmp;
            string satir = null;
            bool sil = false;
            int silincek = 0;
            string[] dizi;
            

            StreamReader rdr = TextGuncelleme.dosyadanOku("puan.txt");
            int k=0;


                while (!String.IsNullOrEmpty(tmp = rdr.ReadLine()))
                {
                    dizi = tmp.Split(':');

                    if (dizi[0] == isim)
                    {

                        silincek = k;
                        sil = true;
                        satir = isim + ":" + puan.ToString();
                    }
                    else
                    {

                        satir = isim + ":" + puan.ToString();
                    }
                    k++;
                }


             if (k == 0) {
                    satir = isim + ":" + puan.ToString();
              }
             TextGuncelleme.okumayiKapat();
             if (sil) {
                 TextGuncelleme.secileniSil("puan.txt", silincek);
             }

             TextGuncelleme.dosyaYaz("puan.txt", satir);
             
            
        }

		private void labelBasla_Click(object sender, EventArgs e)
		{
            if (!String.IsNullOrEmpty(textBox1.Text) && !String.IsNullOrEmpty(textBox2.Text))
			{
                if (checkBox1.Checked)
                {
                    duvar = true;
                }
                else {
                    duvar = false;
                }

                hiz = Convert.ToInt32(textBox2.Text);
                timer1.Enabled = true;
				yil.AKTIF = true;
                timer1.Interval = hiz;
				timer1.Start();

			}



		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			List<PictureBox> pb = yil.PB;
			int enOndeki = pb.Count - 1; 
			Point p = new Point();
			p = pb[enOndeki].Location;


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




			if (duvar)
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


			for(int i=0; i < pb.Count-1; i++){
				if (pb[enOndeki].Location.X == pb[i].Location.X && pb[enOndeki].Location.Y == pb[i].Location.Y ) {
					oyun_bitir ();
                    return;
				}
			}


			if (yil.YEM) {
				yil.YEM = false;
                yem(1);
			}

            if(bonussay  >= 4 && !bonus){
                bonus = true;
                yem(0);
            }


            if (!yil.YEM) {

                foreach (Control c in panelYilan.Controls)
                {
                    if (c is PictureBox)
                    {
                        var l = c as PictureBox;
                        if (l.Tag != null && l.Tag.ToString() == "Yem" && l.Location.Y == pb[enOndeki].Location.Y && l.Location.X == pb[enOndeki].Location.X)
                        {
                                panelYilan.Controls.Remove(l);

                                Image yukleImg = Image.FromFile("snake.png");
                                Point newp = new Point(pb[pb.Count - 1].Location.X, pb[pb.Count - 1].Location.Y);
                                PictureBox newbox = new PictureBox();
                                newbox.Image = yukleImg;
                                newbox.Size = yukleImg.Size;

                                newbox.Location = newp;

                                pb.Add(newbox);
                                panelYilan.Controls.Add(newbox);


                                yil.PUAN = 10;
                                yil.YEM = true;

                                if (!bonus)
                                {
                                    bonussay += 1;
                                }


                                if (hiz > 130)
                                {
                                    hiz = hiz - 5;
                                    timer1.Interval = hiz;
                                }
                                else
                                {
                                    timer1.Interval = hiz;
                                }

                            
                        }

                        if (l.Tag != null && l.Tag.ToString() == "BonusYem" && l.Location.Y == pb[enOndeki].Location.Y && l.Location.X == pb[enOndeki].Location.X)
                        {
                            panelYilan.Controls.Remove(l);

                            Image yukleImg = Image.FromFile("snake.png");
                            Point newp = new Point(pb[pb.Count - 1].Location.X, pb[pb.Count - 1].Location.Y);
                            PictureBox newbox = new PictureBox();
                            newbox.Image = yukleImg;
                            newbox.Size = yukleImg.Size;

                            newbox.Location = newp;

                            pb.Add(newbox);
                            panelYilan.Controls.Add(newbox);


                            yil.PUAN = 30;


                            bonus = false;
                            bonuscount = 0;
                            bonussay = 0;
                            if (hiz > 130)
                            {
                                hiz = hiz - 5;
                                timer1.Interval = hiz;
                            }
                            else
                            {
                                timer1.Interval = hiz;
                            }

                        }
                        
                       

                    }
                    
                } 
                
            
            
            }

            if (bonus) {

                if (bonuscount == 60)
                {

                    foreach (Control c in panelYilan.Controls)
                    {
                        if (c is PictureBox)
                        {
                            var l = c as PictureBox;
                            if (l.Tag != null && l.Tag.ToString() == "BonusYem")
                            {
                                panelYilan.Controls.Remove(l);

                                bonus = false;
                                bonuscount = 0;
                                bonussay = 0;
                            }
                        }
                    }


                }
                else
                {
                    bonuscount += 1;
                }

            
            }

            


			labelPuan.Text = yil.PUAN.ToString ();
			yil.PB = pb;

		}

		#region keydownKontrol
		// formun kontrollerinden keyPress özelliğinin alınması
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
            if (yil.AKTIF)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        if (!yil.YON.Equals("sag"))
                            yil.YON = "sol";
                        break;
                    case Keys.Right:
                        if (!yil.YON.Equals("sol"))
                            yil.YON = "sag";
                        break;
                    case Keys.Down:
                        if (!yil.YON.Equals("yukari"))
                            yil.YON = "asagi";
                        break;
                    case Keys.Up:
                        if (!yil.YON.Equals("asagi"))
                            yil.YON = "yukari";
                        break;
                }
            }
            return false;
		}
		#endregion

		private void labelBitir_Click(object sender, EventArgs e)
		{
			oyun_bitir();
		}

      



	}
}