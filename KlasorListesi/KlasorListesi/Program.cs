using System;

using System.IO;

namespace KlasorListesi
{
    class Program
    {
        static void Main(string[] args)
        {
            DosyaListele(new DirectoryInfo(@"C:\Users\umutcan.horozoglu\Desktop\aa"));

            Console.ReadLine();

        }
        static string GetMimeType(string fileName)
        {
            string mimeType = "application/unknown";
            string ext = System.IO.Path.GetExtension(fileName).ToLower();
            Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext);
            if (regKey != null && regKey.GetValue("Content Type") != null)
                mimeType = regKey.GetValue("Content Type").ToString();
            return mimeType;
        }

        static void DosyaListele(DirectoryInfo Adres)
        {
            FileInfo[] Dosya = Adres.GetFiles();
            for (int i = 0; i < Dosya.Length; i++)
            {
                float boyut = Dosya[i].Length;
                string tur = Path.GetExtension(Dosya[i].ToString());
                string type = mime(tur);
                //string type=  GetMimeType(Dosya[i].ToString()).ToString();
                Console.Write("{0}. " + Dosya[i] + "   " + type + "    " + (boyut / 1024).ToString("0.00") + " KB", i + 1);
                //Console.Write("{0}."+Dosya[i]+"   "+ type+"    "+(boyut/1024).ToString("0.00")+" KB",i+1);
                Console.WriteLine();
            }
        }
        static string mime(string type)
        {

            string mimet = "";
            switch (type)
            {
                case ".pptx":
                    mimet = "Microsoft PowerPoint";
                    break;
                case ".xlsx":
                    mimet = "Microsoft Excel";
                    break;
                case ".docx":
                case ".doc":
                    mimet = "Microsoft Word";
                    break;
                case ".txt":
                    mimet = "Metin Belgesi";
                    break;

                default:
                    mimet = "Tanımsız Dosya";
                    break;

            }
            return mimet;
        }
    }
}
