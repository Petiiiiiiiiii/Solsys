using CA231024;
using System.Linq;
using System.Text;

var bolygok = new List<Bolygo>();

var sr = new StreamReader(
    path:@"..\..\..\src\solsys.txt",
    encoding: Encoding.UTF8);

while (!sr.EndOfStream)
    bolygok.Add(new Bolygo(sr.ReadLine()));

Console.WriteLine("3. feladat:");

Console.WriteLine($"\t3.1: {bolygok.Count()} bolygó van a naprendszerben");

var f4 = bolygok
    .Average(b => b.HoldakSzama);

Console.WriteLine($"\t3.2: a naprendszerben egy bolygónak átlagosan {f4:0.00} holdja van!");

var f5 = bolygok
    .Where(b => b.Arany == bolygok.Max(b => b.Arany))
    .First();

Console.WriteLine($"\t3.3: a legnagyobb térfogatú bolygó a {f5.BolygoNeve}");

Console.Write("\t3.4 Írd be a keresett bolygó nevét: ");
var keresett = Console.ReadLine();

var f6 = bolygok
    .Where(b => b.BolygoNeve.Contains(keresett));

if (f6.Count() >= 1)
{
    Console.WriteLine("\t\tVan ilyen nevű bolygó a naprendszerben!");
}
else 
{
    Console.WriteLine("\t\tNincs ilyen nevű bolygó a naprednszerben!");
}

Console.Write("\t3.5 Írj be egy egész számot: ");
int keresettSzam = int.Parse(Console.ReadLine());

var f7 = bolygok
    .Where(b => b.HoldakSzama > keresettSzam)
    .ToList();

Console.WriteLine($"\t\ta következő bolygóknak van {keresettSzam}-nál/nél több holdja:");
Console.Write("\t\t[");
foreach (var f in f7)
    if(f == f7.Last())
        Console.Write($"'{f.BolygoNeve}'");
    else
        Console.Write($"'{f.BolygoNeve}', ");
Console.Write("]");