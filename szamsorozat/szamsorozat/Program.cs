using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamsorozat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>();

            // 1. feladat
            using (var sr = new StreamReader("sorozat.txt"))
            {
                while (!sr.EndOfStream)
                {
                    list.Add(int.Parse(sr.ReadLine()));
                    Console.WriteLine(list[list.Count - 1]);
                }
            }

            // 2. feladat
            Console.WriteLine($"2. feladat: Elemek szama a sorozatban: {list.Count}db");

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }

            // 3. feladat
            Console.WriteLine("3. feladat: Paratlan szamok:");

            List<int> pList = new List<int>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 1)
                {
                    pList.Add(list[i]);
                }
            }

            int osszeg = pList.Sum((x) => x);
            double atlag = (double)osszeg / pList.Count;


            Console.WriteLine($"\tOsszege: {osszeg}");
            Console.WriteLine($"\tDarabszama: {pList.Count}");
            Console.WriteLine($"\tAtlaga: {atlag}");

            // 4. feladat
            Kiir("reszfajl.txt", list, 0, 2);

            // 5. feladat
            Console.WriteLine("5. feladat:");
            Console.Write("\tKerem az allomany nevet: ");
            string fajlnev = Console.ReadLine();
            Console.Write("\tKerem a kezdo indexet: ");
            int start = int.Parse(Console.ReadLine());
            Console.Write("\tKerem a reszsorozat hosszat: ");
            int hossz = int.Parse(Console.ReadLine());

            Kiir(fajlnev, list, start, hossz);

            // 6. feladat
            int maxIndex = 0;
            int maxDb = 1;

            int jelenlegIndex = 0;
            int jelenlegDb = 1;

            for (int i = 1; i < list.Count; i++)
            {
                if (list[i - 1] < list[i])
                {
                    jelenlegDb++;
                } 
                else
                {
                    if (jelenlegDb > maxDb)
                    {
                        maxDb = jelenlegDb;
                        maxIndex = jelenlegIndex;
                    }

                    jelenlegDb = 1;
                    jelenlegIndex = i;
                }
            }

            Console.WriteLine("6. feladat: Elso leghosszabb szig. mon. novekvo sorozat:");
            Console.WriteLine($"\tHossza: {maxDb}");
            Console.WriteLine($"\tKezdo indexe: {maxIndex}");

            // 7. feladat
            Kiir("leghosszabb.txt", list, maxIndex, maxDb);

            Console.WriteLine(SpigotPi(100000));

            Console.ReadKey();
        }

        static void Kiir(string fajlnev, List<int> szamok, int start, int hossz)
        {
            StreamWriter sw = new StreamWriter(fajlnev, false, Encoding.UTF8);

            for (int i = start; i < start + hossz; i++)
            {
                sw.WriteLine(szamok[i]);
            }

            sw.Flush();
            sw.Close();
        }

        static string SpigotPi(int digits)
        {
            int N, i, j, q, carry, num;
            string result;
            N = digits * 3 + 2;
            int[] x = new int[N];
            int[] r = new int[N];
            result = "";
            for (j = 0; j < N; j++)
            {
                x[j] = 20;
            }
            for (i = 0; i < digits; i++)
            {
                carry = 0;
                for (j = 0; j < N; j++)
                {
                    x[j] = x[j] + carry;
                    num = N - j - 1;
                    q = x[j] / (num * 2 + 1);
                    r[j] = x[j] % (num * 2 + 1);
                    carry = q * num;
                }
                if (i < digits - 1)
                {
                    result = result + x[N - 1] / 10;
                }
                r[N - 1] = x[N - 1] % 10;
                for (j = 0; j < N; j++)
                {
                    x[j] = r[j] * 10;
                }
            }
            return result;
        }
    }
}
