// See https://aka.ms/new-console-template for more information
using toto;

Console.WriteLine("Hello, World!");

// 2. feladat
var list = new List<Toto>();

using (var sr = new StreamReader("./toto.txt"))
{
    sr.ReadLine();
    while (!sr.EndOfStream)
    {
        string[] t = sr.ReadLine()?.Split(";") ?? new string[0];

        list.Add(new Toto
        {
            Year = int.Parse(t[0]),
            Week = int.Parse(t[1]),
            Round = int.Parse(t[2]),
            FullC = int.Parse(t[3]),
            Cost = int.Parse(t[4]),
            Result = t[5],
        });

        Console.WriteLine(list[list.Count - 1]);
    }
}

// 3. feladat
System.Console.WriteLine($"3. feladat: Fordulok szama: {list.Count}");

// 4. feladat
int sum = list.Sum(x => x.FullC);
System.Console.WriteLine($"4. feladat: Telitalalatos szelvenyek szama: {sum} db");

// 5. feladat
long costSum = 0;
list.ForEach(x =>
{
    costSum += x.FullC * (long)x.Cost;
});
long avg = costSum / list.Count;
System.Console.WriteLine($"5. feladat: Atlag: {avg} Ft");

// 6. feladat
Toto min = list.First(x => x.Cost > 0);
Toto max = list.First();

list.ForEach(x =>
{
    if (x.Cost > max.Cost)
    {
        max = x;
    }

    if (x.Cost < min.Cost && x.Cost > 0)
    {
        min = x;
    }
});

System.Console.WriteLine("6. feladat:");
System.Console.WriteLine($"\tLegnagyobb\n\tEv: {max.Year}\n\tHet: {max.Week}\n\tForduloszam: {max.Round}\n\tTelitalat: {max.FullC}\n\tOsszeg: {max.Cost}\n\tEredmeny{max.Result}");
System.Console.WriteLine();
System.Console.WriteLine($"\tLegkisebb\n\tEv: {min.Year}\n\tHet: {min.Week}\n\tForduloszam: {min.Round}\n\tTelitalat: {min.FullC}\n\tOsszeg: {min.Cost}\n\tEredmeny{min.Result}");

// 8. feladat
bool draw = false;

for (int i = 0; i < list.Count && !draw; i++)
{
    if (new EredmenyElemzo(list[i].Result).NemvoltDontetlenMerkozes)
    {
        draw = true;
    }
}

System.Console.WriteLine("8. feladat: " + (draw ? "Volt ahol nem volt dontetlen" : "Nem volt olyan ahol nem volt dontetlen"));


// 7. feladat
class EredmenyElemzo
{
    private string Eredmenyek;

    private int DontetlenekSzama
    {
        get
        {
            return Megszamol('X');
        }
    }

    private int Megszamol(char kimenet)
    {
        int darab = 0;
        foreach (var i in Eredmenyek)
        {
            if (i == kimenet) darab++;
        }
        return darab;
    }

    public bool NemvoltDontetlenMerkozes
    {
        get
        {
            return DontetlenekSzama == 0;
        }
    }

    public EredmenyElemzo(string eredmenyek) // konstruktor
    {
        Eredmenyek = eredmenyek;
    }
}