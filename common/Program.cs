using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace common
{
    public class Program
    {
        static string[] ops = { "==", "!=", ">", "<", ">=", "<=", "?", "$" };

        static void Main(string[] args)
        {
            // Gen();

            var list = Read("src.txt");

            int c = list.Count(x => !x.Compute());
            Console.WriteLine($"DB: {c}");

            int c2 = list
                .Where(x => !x.IsWrong)
                .Count(x => !x.Compute());
            Console.WriteLine($"DB: {c2}");

            Test();
            Console.ReadKey();
        }

        static void Gen(string name = "src.txt", int c = 100)
        {
            List<string> l = new List<string>();
            var r = new Random();

            for (int i = 0; i < c; i++)
            {
                int x = r.Next(1, 101);
                int y = r.Next(1, 101);
                int op = r.Next(ops.Length);

                l.Add($"{x} {ops[op]} {y}");
            }

            File.WriteAllLines(name, l);
        }

        static List<Task> Read(string fileName)
        {
            return File.ReadAllLines(fileName).Select(r =>
            {
                var t = r.Split(' ');

                return new Task
                {
                    X = int.Parse(t[0]),
                    Y = int.Parse(t[2]),
                    Operator = t[1]
                };
            })
                .ToList();
        }

        static void Test()
        {
            string a = "ALMA";
            var t = a.Split(' ');
            double.Parse("1.0");


            List<string> s = new List<string>();

            foreach (var item in s)
            {

            }


            bool f = true;
            for (int i = 0; i < s.Count && f; i++)
            {
                var item = s[i];

                if (item =="$")
                {
                    f = false;
                }

                
            }

            Dictionary<string, string> dict = new Dictionary<string, string>();

            dict.Add("A", "A");

            if (!dict.ContainsKey("A"))
            {
                dict.Add("A", "A");
            }

            dict.Add("B", "B");

            // dict["C"] = dict["C"];

            foreach (var i in dict)
            {
                Console.WriteLine($"{i.Key} = {i.Value}");
            }

            HashSet<string> set = new HashSet<string>();

            set.Add("A");
            set.Add("B");
            set.Add("C");
            set.Add("A");

            foreach (var i in set)
            {
                Console.WriteLine($"{i}");
            }

            

        }
    }

    public class Task
    {
        public int X { get; set; }
        public int Y { get; set; }

        public string Operator { get; set; }

        /*public bool IsWrong()
        {
            return Operator == "?" || Operator == "$";
        }*/

        public bool IsWrong { get { return Operator == "?" || Operator == "$"; } }


        public bool Compute()
        {
            switch (Operator)
            {
                case "==":
                    return X == Y;
                case "!=":
                    return X != Y;
                case "<":
                    return X < Y;
                case ">":
                    return X > Y;
                case "<=":
                    return X <= Y;
                case ">=":
                    return X >= Y;
            }

            return false;
        }
    }
}
