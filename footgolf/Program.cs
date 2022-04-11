// See https://aka.ms/new-console-template for more information
using Footgolf;

Console.WriteLine("Hello, World!");

List<Record> list = new();

using (var sr = new StreamReader("fob2016.txt"))
{
    while (!sr.EndOfStream)
    {
        var t = sr.ReadLine()?.Split(";");

        if (t != null)
        {
            var pontok = new int[8];

            for (int i = 0; i < 8; i++)
            {
                pontok[i] = int.Parse(t[i + 3]);
            }

            list.Add(new Record
            {
                Nev = t[0],
                Kat = t[1],
                Csapat = t[2],
                Pontok = pontok
            });
        }
    }
}

foreach (var i in list)
{
    System.Console.WriteLine(i);
}

// 3. feladat
System.Console.WriteLine($"3. feladat: A versenyzok szama: {list.Count}");

// 4. feadat
int c = list.Count(x => x.Kat.Contains("Noi"));
double avg = c / (double)list.Count;
System.Console.WriteLine($"4. feladat: Noi versenyzok aranya: {avg * 100:f2}%");

// 6. feladat
var max = list.First();
var maxValue = max.Ossz;

list.Where(x => x.Kat.Contains("Noi")).ToList().ForEach(x =>
{
    var ossz = x.Ossz;
    if (maxValue < ossz)
    {
        max = x;
        maxValue = ossz;
    }
});

System.Console.WriteLine("6. feladat: A bajnok noi versenyzo");
System.Console.WriteLine($"\tNev: {max.Nev}");
System.Console.WriteLine($"\tEgyesulet: {max.Csapat}");
System.Console.WriteLine($"\tOsszpont: {maxValue}");

// 7. feladat

File.WriteAllLines("osszpontFF.txt", list.Where(x => x.Kat == "Felnott ferfi").Select(x => $"{x.Nev};{x.Ossz}").ToList());

// 8. feladat
var egyesulet = list.GroupBy(x => x.Csapat);


System.Console.WriteLine("8. feladat: Egyesulet statisztika:");
foreach (var i in egyesulet.Where(x => x.Key != "n.a.").Where(x => x.ToList().Count > 2))
{
    System.Console.WriteLine($"\t{i.Key}:{i.ToList().Count}");
}