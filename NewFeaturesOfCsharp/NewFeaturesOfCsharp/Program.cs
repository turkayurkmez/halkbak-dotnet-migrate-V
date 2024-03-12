// See https://aka.ms/new-console-template for more information



#region global usings
//global ve implicit using: ortak tüm namespace'ler ya projede tanımlı ya da global-usings.cs dosyasında
using NewFeaturesOfCsharp;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Threading.Channels;


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

#region struct üzerinde değişiklikler

var comments = new string[2];
ProductRecord productRecord = new ProductRecord("Ürün A", 1, new string[2]);
ProductRecord productRecord2 = new ProductRecord("Ürün A", 1, new string[2]);

productRecord.Comments[0] = "Çeyizim için aldım. Henüz açmadım";
Console.WriteLine($"productRecord == productRecord2: {productRecord == productRecord2}");
Console.WriteLine($"GetHashcode karşılaştırılıyor : {productRecord.GetHashCode() == productRecord2.GetHashCode()}");
Console.WriteLine($"ReferenceEquals: {ReferenceEquals(productRecord, productRecord2)}");

Console.WriteLine("1. Ürünün yorumları");
productRecord.Comments.ToList().ForEach(c => Console.WriteLine(c));

Console.WriteLine("2. Ürünün yorumları");
productRecord2.Comments.ToList().ForEach(c => Console.WriteLine(c));



List<Employee> employees = new List<Employee>
{
    new(){ Name="Türkay", Address= new Address("Sümer mah.","26140","Eskişehir")},
    new(){ Name="Derya", Address= new Address("Osmanağa mah.","34001","İstanbul")},

};

var searchingAddress = new Address("Osmanağa mah.", "34001", "İstanbul");
var employee = employees.Where(e => e.Address == searchingAddress).FirstOrDefault();

//Address address = new Address("Bilmem ne", "0001", "Samsun");
//address.City = "Adana";

Console.WriteLine($"Bu adresin sahibi {employee.Name}");
#endregion

#region  Karışık değişken tanımlama ve yeniden oluşturma
int x, y;
(x, y) = (5, 10);
(string a, string b) = ("Türkay", "Ürkmez");
(x, bool isOk) = (6, false);


Tuple<int, int> divide(int number1, int number2)
{
    Tuple<int, int> tuple = Tuple.Create(number1 / number2, number1 % number2);
    return tuple;
}

(int, int) groupingDivide(int number1, int number2)
{
    return (number1 / number2, number1 % number2);
}


var (result, mod) = divide(16, 3);
var (resultOfDivide, modOfDivide) = groupingDivide(17, 2);



#endregion

#region Property pattern genişletildi

object sampleEmployee = new Employee
{
    Name = "Türkay Ürkmez",
    Address = new Address("Atalar cd.", "34268", "İstanbul")
};

if (sampleEmployee is Employee { Address: { City: "İstanbul" } })
{
    Console.WriteLine(((Employee)sampleEmployee).Name);
}

if (sampleEmployee is Employee { Address.City: "İstanbul" })
{
    Console.WriteLine(((Employee)sampleEmployee).Name);

}


var smEmployee = (Employee)sampleEmployee;
if (smEmployee.Address.City == "İstanbul")
{
    Console.WriteLine(smEmployee.Name);
}
#endregion

#region Caller Expression Attribute

void CheckCondition(bool condition, [CallerArgumentExpression("condition")] string? message = null)
{
    Console.WriteLine($"Parametreye gönderilen koşul: {message}. Sonuç ise {condition}");
}


CheckCondition(5 > 3);
CheckCondition(false);
(int p, int q) = (6, 9);
CheckCondition(q < p);
#endregion

#region Exception Guards

void saveEmployee(Employee employee)
{
    //if (employee is null)
    //{
    //    throw new ArgumentNullException();
    //}

    ArgumentNullException.ThrowIfNull(employee);

}

#endregion