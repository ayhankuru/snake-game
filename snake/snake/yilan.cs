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

        List<PictureBox> pb = new List<PictureBox>();

        private Image yukleImg;

        private bool aktif = false;

        private bool yem = true;

		private int puan = 0;

		private string yon;

        public yilan()
        {
            yukleImg = Image.FromFile("snake.png");
            Point p = new Point(0, 0);
			for (int i = 0; i < 3; i++)
            {
                PictureBox picBox = new PictureBox();
                picBox.Image = yukleImg;
                picBox.Size = yukleImg.Size;
                picBox.Location = p;
                pb.Add(picBox);
                p.X += 20;
            }

            yon = "sag";
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

     
        public bool YEM
        {
            get { return yem; }
            set { yem = value; }
        }

      
		public int PUAN
		{
            get { return puan; }
            set { puan += value; }
		}

    }
}