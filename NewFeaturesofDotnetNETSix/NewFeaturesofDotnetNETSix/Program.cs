// See https://aka.ms/new-console-template for more information
using NewFeaturesofDotnetNETSix;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");
/*
 * Dynamic PGO (Profile-Guided Optimization)
 *   JSON Serileştime, Dosyaya yazma ve okuma işlemleri gibi derleyici performansına dayalı ilem hızları %26'ya kadar hızlanabiliyor.
 *   
 */

#region JSonSerializer, IAsyncEnumarable interface'ini destekliyor.

async IAsyncEnumerable<int> Show(int maxNumber)
{
    for (int i = 0; i < maxNumber; i++)
    {
        yield return i;
    }
}

using Stream stream = Console.OpenStandardOutput();
var data = new { ItemValue = Show(8) };

//dikkat: SerializeAsync sayesinde, içerisinde IAsyncEnumarable olan data nesnesi serileştiriliyor:
await JsonSerializer.SerializeAsync(stream, data);
Console.WriteLine();
Console.WriteLine("...........................................");
Console.WriteLine();
//dikkat:Burada da bir jeson değeri geri serialize ediliyor:

var readableStream = new MemoryStream(Encoding.UTF8.GetBytes("[1,2,3,4,5,6,7,8,9]"));
await foreach (var item in JsonSerializer.DeserializeAsyncEnumerable<int>(readableStream))
{
    Console.Write(item + "-");
}
Console.WriteLine();
Console.WriteLine("...............................................");

ClassRoom classRoom = new ClassRoom();
await foreach (var student in classRoom)
{
    Console.WriteLine(student.Name);

}


#endregion


#region System.LINQ'in yeni özellikleri

#region yeni fonksiyon: TryGetNonEnumeratedCount


var collection = Enumerable.Range(1, 10);
var numbers = collection.TryGetNonEnumeratedCount(out int count) ? count
                                                                 : 0;

Console.WriteLine();
Console.WriteLine($"TryGetNonEnumeratedCount metodu .net 6'da geldi.\nOluşan numbers koleksiyonunun eleman sayısı:{numbers}");
#endregion

#region ...By ile biten fonksiyonlar

var customers = new CustomerService().GetCustomers();
var maxBudget = customers.Max(c => c.Budget);
var customer = customers.FirstOrDefault(c => c.Budget == maxBudget);
Console.WriteLine($"En yüksek bütçeli: {customer.Name}");

Console.WriteLine($"Aynı hesap maxby ile:{customers.MaxBy(c => c.Budget).Name} ");

Console.WriteLine();
Console.WriteLine("Hizmet verdiğimiz ülkeler:");
var countries = customers.DistinctBy(x => x.Country);
countries.ToList().ForEach(c => Console.Write(c.Country + ", "));
#endregion

#region Chunks...
Console.WriteLine();
Console.WriteLine("---------- Chunk ---------------- ");
var chunks = collection.Chunk(size: 3);
foreach (var item in chunks)
{
    Console.WriteLine(string.Join(",", item));
}
Console.WriteLine();
Console.WriteLine("------------------------------------");
#endregion

#region Index ve Range artık LINQ içerisinde kullanılabiliyor.

var last = collection.ElementAt(^2);
Console.WriteLine($"Sondan ikinci eleman: {last}");
Console.WriteLine($"İlk üç eleman:  {string.Join(",", collection.Take(..3))}");
Console.WriteLine($"4. elemandan sondan ikinci elemana:  {string.Join(",", collection.Take(4..^2))}");
Console.WriteLine($"Son 4 elman:  {string.Join(",", collection.Take(^4..))}");





#endregion

var firstOrNegative = collection.FirstOrDefault(x => x > 10, -1);
Console.WriteLine($"Sonuç: {firstOrNegative}");
var singleOrNegative = collection.SingleOrDefault(x => x == 11, -1);
Console.WriteLine($"Sonuç: {singleOrNegative}");

#endregion

#region Yeni tip: DateOnly ve TimeOnly
customer.RegisteredDate = new DateOnly(2024, 1, 31);

TimeOnly timeOnly = new TimeOnly(1, 15);
//timeOnly.

#endregion