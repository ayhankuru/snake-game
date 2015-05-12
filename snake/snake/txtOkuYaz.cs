using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace snake
{
    class txtOkuYaz
    {
        public static FileStream dosyam;
        public static StreamWriter yazma;
        public static StreamReader okuma;
        public static void dosyaYaz(string yol, string metin)
        {
            dosyam = new FileStream(yol, FileMode.Append, FileAccess.Write);
            yazma = new StreamWriter(dosyam);
            yazma.WriteLine(metin);
            yazma.Close();
            dosyam.Close();
        }

        public static void dosyaEkle(string yol, string metin)
        {
            dosyam = new FileStream(yol, FileMode.Append, FileAccess.Write);
            yazma = new StreamWriter(dosyam);
            yazma.Write(metin);
            yazma.Close();
            dosyam.Close();
        }

        public static StreamReader dosyadanOku(string yol)
        {
            dosyam = new FileStream(yol, FileMode.Open, FileAccess.Read);
            okuma = new StreamReader(dosyam, Encoding.GetEncoding("iso-8859-9"));
            return okuma;
        }
        public static void okumayiKapat()
        {
            okuma.Close();
            dosyam.Close();
        }
    }
}
