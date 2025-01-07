using CSHARP25010703;
using System.Text;

const string PRJDIR = "E:\\PROJECTS\\CSHARP25010703\\src";

List<Orszag> orszagok = [];

StreamReader sr = new($"{PRJDIR}\\adatok-utf8.txt", Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    string[] adatSor = sr.ReadLine().Split(';');
    orszagok.Add(new(
        orszagnev: adatSor[0],
        terulet: int.Parse(adatSor[1]),
        nepesseg: adatSor[2][^1] == 'g' 
            ? int.Parse(adatSor[2][..^1]) * 10000
            : int.Parse(adatSor[2]),
        fovaros: adatSor[3],
        fovarosNepesseg: int.Parse(adatSor[4]) * 1000));
}

Console.WriteLine($"3. feladat");
Console.WriteLine($"A beolvasott országok száma: {orszagok.Count}");

Console.WriteLine("4. feladat");
int kns = orszagok.Single(o => o.Orszagnev == "Kína").Nepsuruseg;
Console.WriteLine($"Kína népsűrűsége = {kns} fő/km^2");

Console.WriteLine("5. feladat");
int kik = orszagok.Single(o => o.Orszagnev == "Kína").Nepesseg
    - orszagok.Single(o => o.Orszagnev == "India").Nepesseg;
Console.WriteLine($"Kína lakossága {kik} fővel volt több");

Console.WriteLine("6. feladat");
var hln = orszagok.OrderByDescending(o => o.Nepesseg).ToArray()[2];
Console.WriteLine($"A 3. legnépesebb ország {hln.Orszagnev}, a lakossága {hln.Nepesseg} fő");


Console.WriteLine("7. feladat");
Console.WriteLine("A következő országok lakossákának több, mint 30%-a fővárosban lakik");
var koncentraltak = orszagok.Where(o => o.FVbenKoncentralt);
foreach (var orszag in koncentraltak)
    Console.WriteLine($"\t{orszag.Orszagnev} ({orszag.Fovaros})");

