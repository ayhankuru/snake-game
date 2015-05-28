using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace snake
{
    class TextGuncelleme
    {
        public static FileStream dosyam;
        public static StreamWriter yazma;
        public static StreamReader okuma;

        public static void dosyaYaz(string path, string text)
        {
            dosyam = new FileStream(path, FileMode.Append, FileAccess.Write);
            yazma = new StreamWriter(dosyam);
            yazma.WriteLine(text);
            yazma.Close();
            dosyam.Close();
        }
        public static StreamReader dosyadanOku(string path)
        {
            dosyam = new FileStream(path, FileMode.Open, FileAccess.Read);
            okuma = new StreamReader(dosyam, Encoding.GetEncoding("iso-8859-9")); // "windows-1254"
            return okuma;
        }
        public static void okumayiKapat()
        {
            okuma.Close();
            dosyam.Close();
        }

        public static void secileniSil(string path, int index)
        {
            int i = 0;
            List<string> lst = new List<string>();
            string str;
            StreamReader rdr = dosyadanOku(path);
            while (true)
            {
                if (i != index)
                {
                    if (!String.IsNullOrEmpty(str = rdr.ReadLine()))
                        lst.Add(str);
                    else
                        break;
                }
                else
                    str = rdr.ReadLine();
                i++;
            }
            okumayiKapat();
            FileStream f = new FileStream(path, FileMode.Truncate, FileAccess.Write);
            yazma = new StreamWriter(f);
            for (i = 0; i < lst.Count; i++)
                yazma.WriteLine(lst[i]);

            yazma.Close();
            f.Close();
        }
    }
}