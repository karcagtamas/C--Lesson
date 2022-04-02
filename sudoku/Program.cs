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