using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace OrvosiNobeldijasok
{
    internal class Program
    {
        public static List<Díjazottak> nobelek = new List<Díjazottak>();

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("orvosi_nobeldijak.txt");
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(';');
                Díjazottak dijazott = new Díjazottak();
                dijazott.Év = int.Parse(sor[0]);
                dijazott.Név = sor[1];
                dijazott.SZületés_halál = sor[2];
                dijazott.orszagKod = sor[3];
                nobelek.Add(dijazott);
            }
            sr.Close();

            //3
            Console.WriteLine($"3. feladat: {nobelek.Count}");

            //4
            int max = 0;
            for (int i = 0; i < nobelek.Count; i++)
            {
                if (nobelek[i].Év > max)
                {
                    max = nobelek[i].Év;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"4.feladat legutóbbi díjátadó: {max}");

            //5
            Console.WriteLine();
            Console.WriteLine("5.feladat:");
            Console.WriteLine();
            Console.Write("országkód: ");
            int db = 0;
            string be = Console.ReadLine();
            bool vane = false;
            int index = 0;
            for (int i = 0; i < nobelek.Count; i++)
            {

                if (nobelek[i].orszagKod == be)
                {
                    vane = true;
                    db++;
                    index = i;
                }

            }
            if (vane == true)
            {
                if (db == 1)
                {
                    Console.WriteLine($"Év: {nobelek[index].Év}");
                    Console.WriteLine($"Név: {nobelek[index].Név}");
                    Console.WriteLine($"SZ/H: {nobelek[index].SZületés_halál}");

                }
                else
                {
                    Console.WriteLine($"díjazottak száma: {db}");
                }

            }
            else
            {
                Console.WriteLine($"A megadott országból nem volt díjazott");
            }
            //6
            var stat = new Dictionary<string, int>();

            foreach (var item in nobelek)
            {
                if (!stat.ContainsKey(item.orszagKod))
                {
                    stat.Add(item.orszagKod, 0);
                }

                stat[item.orszagKod]++;
            }

            foreach (var item in stat)
            {
                if (item.Value > 5)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            //7
            HashSet<string> set = new HashSet<string>();

            nobelek.ForEach(x =>
            {
                    set.Add(x.orszagKod);
                
            });




            foreach (var item in set)
            {

            }




            Console.ReadKey();
        }
    }
    class Elethossz
    {
        private int Tol { get; set; }
        private int Ig { get; set; }
        public int ElethosszEvekben => Tol == -1 || Ig == -1 ? -1 : Ig - Tol;

        public bool IsmertAzElethossz => ElethosszEvekben != -1;

        public Elethossz(string SzuletesHalalozas)
        {
            string[] m = SzuletesHalalozas.Split('-');
            try
            {
                Tol = int.Parse(m[0]);
            }
            catch (Exception)
            {
                Tol = -1;
            }
            try
            {
                Ig = int.Parse(m[1]);
            }
            catch (Exception)
            {
                Ig = -1;
            }
        }

    }
    public class Díjazottak
    {
        public int Év { get; set; }
        public string Név { get; set; }
        public string SZületés_halál { get; set; }
        public string orszagKod { get; set; }
    }
}
