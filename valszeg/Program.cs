using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace valszeg
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int min = 1000;
            int max = 0;
            while (false)
            {
                if (min != 1000)
                {
                    Console.WriteLine($"Legrovidebb: {min}");
                }
                if (max != 0)
                {
                    Console.WriteLine($"Leghosszabb: {max}");
                }
                List<int> nums = new List<int>();
                int x = 0;
                while (x != 6)
                {
                    x = rand.Next(6) + 1;
                    nums.Add(x);
                    Console.WriteLine(x);
                }

                for (int i = 1; i <= 6; i++)
                {
                    var db = Darab(i, nums);
                    Console.WriteLine($"{i}: {db} db - {db * 100 / (double)nums.Count:f2} %");
                }

                var y = Math.Pow(1.0 / 6.0, nums.Count);
                Console.WriteLine($"Eselye hogy {nums.Count}. kidobjuk a hatos az: {y:f6} - {y * 100:f6} %");

                if (nums.Count > max)
                {
                    max = nums.Count;
                }

                if (nums.Count < min)
                {
                    min = nums.Count;
                }

                Task.WaitAll(Task.Delay(1000));
                Console.Clear();
            }

            var f = new List<Person>();
            var l = new List<int>();
            for (int i = 0; i < f.Count; i++)
            {
                l.Add(f[i].Age);
            }
            var agelist = f.Select(x => x.Age).ToList();

            agelist.Sort();
            Array.Sort(agelist.ToArray());

            Console.ReadKey();
        }

        static int Darab(int x, List<int> nums)
        {
            int db = 0;
            for (int i = 0; i < nums.Count; i++)
            {
                if (nums[i] == x)
                {
                    db++;
                }
            }

            return db;
        }
    }
}
