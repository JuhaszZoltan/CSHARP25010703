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
        fovarosNepesseg: int.Parse(adatSor[4])));
}

Console.WriteLine($"4. feladat");
Console.WriteLine($"A beolvasott országok száma: {orszagok.Count}");