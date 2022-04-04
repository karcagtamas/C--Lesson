// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var list = new List<Feladvany>();

using (var sr = new StreamReader("feladvanyok.txt"))
{
    while (!sr.EndOfStream)
    {
        list.Add(new(sr.ReadLine() ?? ""));
    }
}

list.ForEach(x => System.Console.WriteLine(x.Kezdo));

// 3. feladat
System.Console.WriteLine($"3. feladat: Feladavanyok szam: {list.Count}");

// 4. feladat
int x = 0;

do
{
    System.Console.Write("Adjon meg egy szamot (4-9): ");
    int.TryParse(Console.ReadLine(), out x);
} while (x < 4 || x > 9);

List<Feladvany> xlist = list.Where(f => f.Meret == x).ToList();
System.Console.WriteLine($"4. feladat: {xlist.Count}");

// 5. feladat
Random rnd = new Random();
int random = rnd.Next(xlist.Count);

Feladvany feladvany = xlist[random];
System.Console.WriteLine("5. feladat: ");
feladvany.Kirajzol();

// 6. feladat
System.Console.WriteLine($"6. feladat: Kitoltottseg: {feladvany.FillStatus() * 100:f0}%");

// 7. feladat
System.Console.WriteLine("7. feladat:");
feladvany.Kirajzol();

// 8. feladat
File.WriteAllLines($"sudoku{x}.txt", xlist.Select(f => f.Kezdo).ToList());

class Feladvany
{
    public string Kezdo { get; private set; }
    public int Meret { get; private set; }

    public Feladvany(string sor)
    {
        Kezdo = sor;
        Meret = Convert.ToInt32(Math.Sqrt(sor.Length));
    }

    public void Kirajzol()
    {
        for (int i = 0; i < Kezdo.Length; i++)
        {
            if (Kezdo[i] == '0')
            {
                Console.Write(".");
            }
            else
            {
                Console.Write(Kezdo[i]);
            }
            if (i % Meret == Meret - 1)
            {
                Console.WriteLine();
            }
        }
    }

    public double FillStatus()
    {
        int c = 0;
        foreach (var i in Kezdo)
        {
            if (i != '0')
            {
                c++;
            }
        }

        return (double)c / Kezdo.Length;
    }
}
