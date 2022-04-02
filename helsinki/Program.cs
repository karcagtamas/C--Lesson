using helsinki;

var list = new List<Helyezes>();

// 1. feladat
var rows = File.ReadAllLines("/home/karcagtamas/Repositories/helsinki/helsinki.txt");

// 2. feladat
rows.ToList().ForEach(r =>
{
    string[] t = r.Split(" ");

    list.Add(new Helyezes
    {
        Helyez = int.Parse(t[0]),
        Tagok = int.Parse(t[1]),
        Sport = t[2],
        VSzam = t[3]
    });
});

// 3. feladat
// int c = 0;

// c = list.Where(x => x.Helyez <= 3).Count();

System.Console.WriteLine($"3. feladat: {list.Count}");

// 4. feladat
int[] stat = new int[6];
list.ForEach(r =>
{
    stat[r.Helyez - 1]++;
});

System.Console.WriteLine("4. feladat");
for (int i = 0; i < 3; i++)
{
    System.Console.WriteLine($"{i + 1}. helyezes: {stat[i]} darab");
}

var GetPontByHelyez = (int x) =>
{
    switch (x)
    {
        case 1: return 7;
        case 2: return 5;
        case 3: return 4;
        case 4: return 3;
        case 5: return 2;
        case 6: return 1;
        default: return 0;
    }
};

// 5. feladat
int sum = list.Sum((x) => GetPontByHelyez(x.Helyez));

System.Console.WriteLine($"5. feladat: Pontok osszege: {sum}");


var sp = new Dictionary<string, int>();

// 6. feladat
list.ForEach(x =>
{
    if (x.Helyez <= 3)
    {
        if (sp.ContainsKey(x.Sport))
        {
            sp[x.Sport]++;
        }
        else
        {
            sp.Add(x.Sport, 1);
        }
    }
});

string? msp = string.Empty;
int max = 0;

foreach (var i in sp)
{
    if (i.Value > max)
    {
        max = i.Value;
        msp = i.Key;
    }
}

System.Console.WriteLine("6. feladat");
if (string.IsNullOrEmpty(msp))
{
    System.Console.WriteLine("Nem volt sportag");
}

System.Console.WriteLine($"Legtobb ermes sport: {msp} {sp[msp]} db eremmel");

// 7. feladat
var sw = new StreamWriter("./helsink2.txt");

list.ForEach(x =>
{
    var name = x.Sport == "kajakkenu" ? "kajak-kenu" : x.Sport;

    sw.WriteLine($"{x.Helyez} {x.Tagok} {GetPontByHelyez(x.Helyez)} {name} {x.VSzam}");
});
sw.Flush();
sw.Close();

// 8. feladat
var h = list[0];
int index = 0;

for (int i = 1; i < list.Count; i++)
{
    if (h.Tagok < list[i].Tagok)
    {
        h = list[i];
        index = i;
    }
}

System.Console.WriteLine("8. feladat");
System.Console.WriteLine($"Helyezes: {h.Helyez}");
System.Console.WriteLine($"Sportag: {list[index].Sport}");
System.Console.WriteLine($"Versenyszam: {h.VSzam}");
System.Console.WriteLine($"Sportolok szama: {h.Tagok}");