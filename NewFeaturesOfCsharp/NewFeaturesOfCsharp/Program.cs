// See https://aka.ms/new-console-template for more information



#region global usings
//global ve implicit using: ortak tüm namespace'ler ya projede tanımlı ya da global-usings.cs dosyasında
using System.Linq.Expressions;


Console.WriteLine("Hello, World!");
DataTable dataTable = new DataTable();
Sample sample = new Sample();
#endregion

#region anonim tip ve lambda iyileştirmeleri


//anonim tiplerde doğal yakalayıcılar.
//.net 6.0 öncesi:
Func<int, bool> isEven = (int number) => number % 2 == 0;
var isOdd = (int number) => number % 2 == 1;

var parse = (string value) => int.Parse(value);
LambdaExpression isEvenExpr = (int number) => number % 2 == 0;


Func<int> read = Console.Read;
Action<string> write = Console.Write;

var read2 = Console.Read;

//var write2 = Console.Write; !! Çalışmaz! Çünkü Console sınıfının birden fazla overload'u var!!
//Lamdba işlemlerine dönüş değeri tanımlanabilir
var output = object (bool isSuccess) => isSuccess ? 1 : "İşlem Başarısız";
#endregion





