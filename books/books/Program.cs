// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

List<Book> books = new()
{
    new Book { Id = 1, Name = "Harry Potter 1", Pages = 305, Release = 2001, Weight = 1.5, Writer = "JKR" },
    new Book { Id = 2, Name = "Harry Potter 2", Pages = 355, Release = 2003, Weight = 1.7, Writer = "JKR" },
    new Book { Id = 3, Name = "LOTR - Fellowship", Pages = 600, Release = 1999, Weight = 1.9, Writer = "Tolkien" },
    new Book { Id = 4, Name = "LOTR - Two tower", Pages = 720, Release = 2002, Weight = 2.4, Writer = "Tolkien" },
    new Book { Id = 5, Name = "Book 1", Pages = 120, Release = 1998, Weight = 1.7, Writer = "Pista" },
    new Book { Id = 6, Name = "Korte", Pages = 255, Release = 1963, Weight = 0.9, Writer = "Jani" },
    new Book { Id = 7, Name = "Alma", Pages = 152, Release = 1896, Weight = 1, Writer = "Jani" },
    new Book { Id = 8, Name = "Sci-fi", Pages = 555, Release = 1985, Weight = 1.6, Writer = "Karcsi" },
    new Book { Id = 9, Name = "Urhajok", Pages = 111, Release = 2008, Weight = 3.2, Writer = "Pista" },
    new Book { Id = 10, Name = "Horror haz", Pages = 32, Release = 2021, Weight = 0.4, Writer = "Pista" },
};

new BookProgram(books).Run();

Console.ReadKey();

internal class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Writer { get; set; }
    public int Pages { get; set; }
    public double Weight { get; set; }
    public int Release { get; set; }
}

internal class BookProgram
{
    private List<Book> books;
    public BookProgram(List<Book> list)
    {
        this.books = list;
    }

    public void Run()
    {
        // 1. feladat - konyven darabszama
        Console.WriteLine($"{books.Count} darab konyv van");

        // 2. feladat - 2009 vagy utana
        int count = 0;
        books.ForEach(b =>
        {
            if (b.Release >= 2000)
            {
                count++;

                Console.WriteLine($"{b.Name}-{b.Writer}");
            }
        });
        Console.WriteLine($"{count} darab 2000 vagy utana kijott konyv van");

        // 4. feladat - Weight sum
        double sum = books.Sum(x => x.Weight);
        Console.WriteLine($"Ossz tomeg: {sum}");
        Console.WriteLine($"Atlag tomeg: {sum / books.Count:f2}");

        // 5. feladat - Max book pages
        int max = books.Max(x => x.Pages);
        int id = books.Where(x => x.Pages == max).First().Id;
        Console.WriteLine($"Legtobb oldal szam: {max}, ID: {id}");

        // 6. feladat - Min book pages
        int min = books.Min(x => x.Pages);
        int index = books.FindIndex(x => x.Pages == min);
        Console.WriteLine($"Legkisebb konyv index: {index}");

        // 7. feladat - Min %
        int pSum = books.Sum(x => x.Pages);
        double v = (double)books[index].Pages / pSum * 100;
        Console.WriteLine($"Szazalek: {v:f2}");

        // 8. feladat
        int minEv = books.Min(x => x.Release);
        int maxEv = books.Max(x => x.Release);
        Console.WriteLine($"{maxEv} - {minEv}");

        // 9. feladat
        books.ForEach(x =>
        {
            if (x.Release % 3 == 0)
            {
                Console.WriteLine(x.Name);
            }
        });

        // 10. feladat
        bool f = books.Any(x => (x.Release % 4 == 0 && x.Release % 100 != 0) || x.Release % 400 == 0);

        Console.WriteLine(f ? "Volt" : "Nem volt");

        // 11. feladat
        StreamWriter sw = new StreamWriter("export.csv", false);

        books.ForEach(x =>
        {
            sw.WriteLine($"{x.Id};{x.Name};{x.Writer}");
        });

        sw.Flush();
        sw.Close();

        // 11. feladat
        Dictionary<string, List<string>> t = new();

        for (int i = 0; i < books.Count; i++)
        {
            if (t.ContainsKey(books[i].Writer))
            {
                t[books[i].Writer].Add(books[i].Name);
            }
            else
            {
                t.Add(books[i].Writer, new List<string> { books[i].Name });
            }
        }

        foreach (var i in t)
        {
            Console.WriteLine($"Iro: {i.Key}");

            i.Value.ForEach(v =>
            {
                Console.WriteLine($"\tKonyv: {v}");
            });
        }
    }
}