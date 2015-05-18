using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace snake
{
    class yilan
    {
        private string yon;
        List<PictureBox> pb = new List<PictureBox>();
        private Image yukleImg;

        private bool aktif = false;

        private bool duvar = true;

        private bool yem = true;

        private int hiz = 1000;

        public yilan()
        {
            yukleImg = Image.FromFile("snake.png");
            yon = "sag";
            Point p = new Point(0, 0);
			for (int i = 0; i < 8; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Image = yukleImg;
                picBox.Size = yukleImg.Size;
                picBox.Location = p;
                pb.Add(picBox);
                p.X += 20;
            } 
        }

        public List<PictureBox> PB
        {
            get { return pb; }
            set { pb = value; }
        }

        public string YON
        {
            get { return yon; }
            set { yon = value; }
        }

		public bool AKTIF
        {
            get { return aktif; }
            set { aktif = value; }
        }

        public bool DUVAR
        {
            get { return duvar; }
            set { duvar = value; }
        }
        
        public bool YEM
        {
            get { return yem; }
            set { yem = value; }
        }

        public int HIZ
        {
            get { return hiz; }
            set { hiz = value; }
        }

        public void HizDegis(int sayi)
        {
            hiz=sayi;

        }
    }
}