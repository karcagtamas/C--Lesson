namespace Footgolf;

public class Record
{
    public string Nev { get; set; } = "";
    public string Kat { get; set; } = "";
    public string Csapat { get; set; } = "";
    public int[] Pontok { get; set; } = new int[0];

    public int Ossz
    {
        get
        {
            var sorted = Pontok.ToList().OrderByDescending(x => x);

            int sum = sorted.Take(6).Sum();
            int plus = sorted.TakeLast(2).Where(x => x != 0).Count() * 10;

            return sum + plus;
        }
    }

    public override string ToString()
    {
        return $"Nev={Nev}, Kat={Kat}, Csapat={Csapat}, Pontok={string.Join(',', Pontok)}";
    }


}